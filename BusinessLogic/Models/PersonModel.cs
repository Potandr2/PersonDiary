using System;
using System.Linq;
using System.Collections.Generic;
using PersonDiary.Interfaces;
using PersonDiary.Contracts.PersonContract;
using PersonContract = PersonDiary.Contracts.PersonContract.Person;
using AutoMapper;


namespace PersonDiary.BusinessLogic
{
    public class PersonModel
    {
        private readonly IUnitOfWork unit;
        private IPersonRepository repoPerson;
        private IMapper mapper;
        public PersonModel(IUnitOfWork unit,IMapper mapper)
        {
            if (unit == null)
                throw new ArgumentNullException("Unit and persons repository is null");
            this.unit = unit;
            repoPerson = unit.Persons;

            this.mapper = mapper;
        }
        public GetPersonListResponse GetItems(GetPersonListRequest request)
        {
            var resp = new GetPersonListResponse();
            try {
                resp.Persons = mapper.Map<List<PersonContract>>(
                    repoPerson.GetItems(request.withLifeEvents).ToList()
                    );
            }
            catch (Exception e) { resp.Messages.Add(new Contracts.Message() { Text = e.Message, Type = Contracts.MessageTypeEnum.Error }); };
            return resp;

        }
        public GetPersonResponse GetItem(GetPersonRequest request)
        {
            var resp = new GetPersonResponse();
            try
            {
                resp.Person = mapper.Map<PersonContract>(
                    repoPerson.GetItems(request.withLifeEvents).FirstOrDefault(p => p.Id == request.Id)
                );
            }
            catch (Exception e) { resp.Messages.Add(new Contracts.Message() { Text = e.Message, Type = Contracts.MessageTypeEnum.Error }); };
            return resp;
        }
        public UpdatePersonResponse Create(UpdatePersonRequest request)
        {
            var resp = new UpdatePersonResponse();
            try { 
                var item = mapper.Map<Entities.Person>(request.Person);
                repoPerson.Create(item);
                unit.Save();
                resp.Person = mapper.Map<Person>(repoPerson.GetItem(item.Id));
            }
            catch(Exception e) { resp.Messages.Add(new Contracts.Message() { Text = e.Message, Type = Contracts.MessageTypeEnum.Error }); };
            return resp;
        }
        public UpdatePersonResponse Update(UpdatePersonRequest request)
        {
            var resp = new UpdatePersonResponse();
            try
            {
                var item = mapper.Map<Entities.Person>(request.Person);
                unit.Persons.Update(item);
                unit.Save();
            }
            catch (Exception e) { resp.Messages.Add(new Contracts.Message() { Text = e.Message, Type = Contracts.MessageTypeEnum.Error }); };
            return resp;
        }
        public DeletePersonResponse Delete(DeletePersonRequest request)
        {
            var resp = new DeletePersonResponse();
            try
            {
                repoPerson.Delete(request.Id);
                unit.Save();
            }
            catch (Exception e) { resp.Messages.Add(new Contracts.Message() { Text = e.Message, Type = Contracts.MessageTypeEnum.Error }); };
            return resp;
        }
        public PersonUploadResponse Upload(PersonUploadRequest request)
        {
            var resp = new PersonUploadResponse();
            try
            {
                var person = unit.Persons.GetItem(request.PersonId);
                person.Biography = request.Biography;
                unit.Persons.Update(person);
                unit.Save();
            }catch(Exception e) { resp.Messages.Add(new Contracts.Message() { Text = e.Message, Type = Contracts.MessageTypeEnum.Error }); };
            return resp;
        }
        public byte[] Download(GetPersonRequest request)
        {
            var resp = new PersonDownloadResponse();
            var person = unit.Persons.GetItem(request.Id);
            return person.Biography;

        }
        public DeletePersonResponse DeleteBiography(DeletePersonRequest request)
        {
            var resp = new DeletePersonResponse();
            try
            {
                var person = unit.Persons.GetItem(request.Id);
                person.Biography = null;
                unit.Persons.Update(person);
                unit.Save();
            }
            catch (Exception e) { resp.Messages.Add(new Contracts.Message() { Text = e.Message, Type = Contracts.MessageTypeEnum.Error }); };
            return resp;
        }

    }
}
