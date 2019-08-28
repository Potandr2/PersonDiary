using AutoMapper;
using NUnit.Framework;
using PersonDiary.BusinessLogic;
using PersonDiary.Contracts.LifeEventContract;
using PersonDiary.Contracts.PersonContract;
using PersonDiary.Interfaces;
using PersonDiary.Mapping;
using PersonDiary.Repositories;
using System;
using System.Linq;
using LifeEventContract = PersonDiary.Contracts.LifeEventContract.LifeEvent;

namespace LifeEventDiary.BusinessLogic.Test
{

    public class LifeEventModelTest
    {
        IUnitOfWorkFactory factory;
        ILifeEventRepository repoLifeEvent;
        LifeEventModel modelLifeEvent;
        IMapper mapper;
        [SetUp]
        public void Setup()
        {
            mapper = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            }).CreateMapper();

            factory = new UnitOfWorkFactory();
            repoLifeEvent = factory.CreateUnitOfWork().LifeEvents;
            modelLifeEvent = new LifeEventModel(factory, mapper);
        }
        [Test, Order(0)]
        public void Create()
        {
            var person_last = new PersonModel(new UnitOfWorkFactory(), mapper).GetItems(new GetPersonListRequest() { PageSize = RepositoryDefaults.PageSize }).Persons.Last();

            var suffix = DateTime.Now.ToString("dd.MM.yyyy_mm_HH_ss");

            var resp = modelLifeEvent.Create(new UpdateLifeEventRequest()
            {
                LifeEvent = new LifeEventContract()
                {
                    Name = $"LifeEventCreateTest_Name{suffix}",
                    Eventdate = DateTime.Now,
                    PersonId = person_last.Id
                }
            }); ;
            Assert.IsTrue(resp.Messages.Count == 0);
        }
        [Test, Order(1)]
        public void Update()
        {
            var model_tmp = new LifeEventModel(new UnitOfWorkFactory(), mapper);
            var updated = "_Updated";
            var LifeEvent_last = model_tmp.GetItems(new GetLifeEventListRequest() { PageSize = RepositoryDefaults.PageSize }).LifeEvents.Last();
            LifeEvent_last.Name += updated;

            modelLifeEvent.Update(new UpdateLifeEventRequest() { LifeEvent = LifeEvent_last });
            var LifeEvent_check = modelLifeEvent.GetItem(new GetLifeEventRequest() { Id = LifeEvent_last.Id }).lifeevent;
            Assert.IsTrue(LifeEvent_check.Name.Contains(updated));
        }
        [Test, Order(2)]
        public void Delete()
        {
            Create();
            var LifeEvent_last = modelLifeEvent.GetItems(new GetLifeEventListRequest() { PageSize = RepositoryDefaults.PageSize }).LifeEvents.Last();
            modelLifeEvent.Delete(new DeleteLifeEventRequest() { Id = LifeEvent_last.Id });
            Assert.IsNull(repoLifeEvent.GetItem(LifeEvent_last.Id));
        }
        [Test, Order(3)]
        public void GetItems()
        {
            var cntRepo = repoLifeEvent.GetItems(0, RepositoryDefaults.PageSize).ToList().Count;
            var cntModel = modelLifeEvent.GetItems(new GetLifeEventListRequest() { PageSize = RepositoryDefaults.PageSize }).LifeEvents.Count;
            Assert.AreEqual(cntRepo, cntModel);

        }

    }
}
