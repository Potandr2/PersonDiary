using AutoMapper;
using NUnit.Framework;
using PersonDiary.Contracts.PersonContract;
using PersonDiary.Interfaces;
using PersonDiary.Mapping;
using PersonDiary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using LifeEventContract = PersonDiary.Contracts.LifeEventContract.LifeEvent;
using PersonContract = PersonDiary.Contracts.PersonContract.Person;




namespace PersonDiary.BusinessLogic.Test
{

    public class PersonModelTest
    {
        IUnitOfWorkFactory factory;
        IPersonRepository repoPerson;
        PersonModel modelPerson;
        IMapper mapper;
        [SetUp]
        public void Setup()
        {
            mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            }).CreateMapper();
            factory = new UnitOfWorkFactory();
            repoPerson = factory.CreateUnitOfWork().Persons;
            modelPerson = new PersonModel(factory, mapper);
        }
        [Test, Order(0)]
        public void Create()
        {
            var suffix = DateTime.Now.ToString("dd.MM.yyyy_mm_HH_ss");

            var resp = modelPerson.Create(new UpdatePersonRequest()
            {
                Person = new PersonContract()
                {
                    Name = $"PersonCreateTest_Name{suffix}",
                    Surname = $"PersonCreateTest_Surame{suffix}",
                    LifeEvents = new List<LifeEventContract>() {
                        new LifeEventContract() { Name = $"CreateTest_LifeEvent1_{suffix}", Eventdate = DateTime.Now },
                        new LifeEventContract() { Name = $"CreateTest_LifeEvent2_{suffix}", Eventdate = DateTime.Now }
                    }
                }
            });
            Assert.IsTrue(resp.Messages.Count == 0);
        }
        [Test, Order(1)]
        public void Update()
        {
            var model_tmp = new PersonModel(factory, mapper);
            var updated = "_Updated";
            var person_last = model_tmp.GetItems(new GetPersonListRequest() { PageSize = RepositoryDefaults.PageSize }).Persons.Last();
            person_last.Name += updated;
            person_last.Surname += updated;

            modelPerson.Update(new UpdatePersonRequest() { Person = person_last });
            var person_check = modelPerson.GetItem(new GetPersonRequest() { Id = person_last.Id }).Person;
            Assert.IsTrue(person_check.Name.Contains(updated) && person_check.Surname.Contains(updated));
        }
        [Test, Order(2)]
        public void Delete()
        {
            Create();
            var person_last = modelPerson.GetItems(new GetPersonListRequest() { PageSize = RepositoryDefaults.PageSize }).Persons.Last();
            modelPerson.Delete(new DeletePersonRequest() { Id = person_last.Id });
            Assert.IsNull(repoPerson.GetItem(person_last.Id));
        }
        [Test, Order(3)]
        public void GetItems()
        {
            var cntRepo = repoPerson.GetItems(0, RepositoryDefaults.PageSize).ToList().Count;
            var cntModel = modelPerson.GetItems(new GetPersonListRequest() { PageSize = RepositoryDefaults.PageSize }).Persons.Count;
            Assert.AreEqual(cntRepo, cntModel);
        }
        [Test, Order(4)]
        public void GetItemsWithLifeEvents()
        {
            var repoLifeEvents = factory.CreateUnitOfWork().LifeEvents;
            modelPerson.GetItems(new GetPersonListRequest()).Persons.ForEach(p =>
           {
               var person = factory.CreateUnitOfWork().Persons.GetItem(p.Id);
               Assert.AreEqual(
                   repoLifeEvents.GetPersonItems(p.Id).Count(),
                   person.LifeEvents.Count
                   );
           });
        }
    }
}