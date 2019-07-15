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
        IUnitOfWork unit;
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

            unit = new UnitOfWork();
            repoPerson = unit.Persons;
            modelPerson = new PersonModel(unit, mapper);
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
            var model_tmp = new PersonModel(new UnitOfWork(), mapper);
            var updated = "_Updated";
            var person_last = model_tmp.GetItems(new GetPersonListRequest()).Persons.Last();
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
            var person_last = modelPerson.GetItems(new GetPersonListRequest()).Persons.Last();
            modelPerson.Delete(new DeletePersonRequest() { Id = person_last.Id });
            Assert.IsNull(repoPerson.GetItem(person_last.Id));
        }
        [Test, Order(3)]
        public void GetItems()
        {
            
            var cntRepo = repoPerson.GetItems().ToList().Count;
            var cntModel = modelPerson.GetItems(new GetPersonListRequest()).Persons.Count;
            Assert.AreEqual(cntRepo, cntModel);
        }
        [Test, Order(4)]
        public void GetItemsWithLifeEvents()
        {
            var repoLifeEvents = unit.LifeEvents;
            modelPerson.GetItems(new GetPersonListRequest()).Persons.ForEach(p =>
            {
                Assert.AreEqual(
                    repoLifeEvents.GetItems().Where(le => le.PersonId == p.Id).Count(),
                    p.LifeEvents.Count
                    );
            });
        }
    }
}