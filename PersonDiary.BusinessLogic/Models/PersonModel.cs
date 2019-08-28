using AutoMapper;
using PersonDiary.Contracts.PersonContract;
using PersonDiary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonContract = PersonDiary.Contracts.PersonContract.Person;


namespace PersonDiary.BusinessLogic
{
    //Модель Персоны, реализует CRUD функционал для персоны.
    public class PersonModel
    {
        private readonly IUnitOfWorkFactory factory;
        private readonly IMapper mapper;
        //Впрыскиваем зависимости объектов уровня доступа к данным 
        public PersonModel(IUnitOfWorkFactory factory, IMapper mapper)
        {
            if (mapper == null)
                throw new ArgumentNullException("Mapper in PersonModel is null");
            if (factory == null)
                throw new ArgumentNullException("UnitOfWorkFactory in PersonModel is null");

            this.factory = factory;
            this.mapper = mapper;
        }
        /// <summary>
        /// Осуществляет постраничную выборку списка персон
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetPersonListResponse GetItems(GetPersonListRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model GetPersonListRequest is invalid");

            request.PageSize = (request.PageSize == 0) ? RepositoryDefaults.PageSize : request.PageSize;

            var resp = new GetPersonListResponse();
            var unit = factory.CreateUnitOfWork();
            try
            {
                resp.Persons = mapper.Map<List<PersonContract>>(
                    unit.Persons.GetItems(request.PageNo, request.PageSize).ToList()
                    );
                resp.Count = unit.Persons.Count;
            }
            catch (Exception e) { resp.AddMessage(new Contracts.Message(e.Message)); };
            return resp;
        }
        /// <summary>
        /// Осуществляет постраничную выборку списка персон асинхронно/ 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetPersonListResponse> GetItemsAsync(GetPersonListRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model GetPersonListRequest is invalid");

            request.PageSize = (request.PageSize == 0) ? RepositoryDefaults.PageSize : request.PageSize;
            var unit = factory.CreateUnitOfWork();
            var resp = new GetPersonListResponse();
            try
            {
                resp.Persons = mapper.Map<List<PersonContract>>(
                    await unit.Persons.GetItemsAsync(request.PageNo, request.PageSize)
                   );
                resp.Count = await unit.Persons.CountAsync();
            }
            catch (Exception e) { resp.AddMessage(new Contracts.Message(e.Message)); };
            return resp;

        }
        /// <summary>
        /// Осуществляет выборку персоны из бд вместе с дочерними коллекциями (eager loading)
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetPersonResponse GetItem(GetPersonRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model GetPersonRequest  is invalid");
            var resp = new GetPersonResponse();
            try
            {
                resp.Person = mapper.Map<PersonContract>(
                    factory.CreateUnitOfWork().Persons.GetItem(request.Id)
                );
            }
            catch (Exception e) { resp.AddMessage(new Contracts.Message(e.Message)); };
            return resp;
        }
        /// <summary>
        /// Осуществляет выборку персоны из бд вместе с дочерними коллекциями (eager loading) асинхронно
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetPersonResponse> GetItemAsync(GetPersonRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model GetPersonRequest  is invalid");
            var resp = new GetPersonResponse();
            try
            {
                resp.Person = mapper.Map<PersonContract>(
                   await factory.CreateUnitOfWork().Persons.GetItemAsync(request.Id)
                );
            }
            catch (Exception e) { resp.AddMessage(new Contracts.Message(e.Message)); };
            return resp;
        }
        /// <summary>
        /// Создаёт новую персону
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdatePersonResponse Create(UpdatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model UpdatePersonRequest  is invalid");
            var resp = new UpdatePersonResponse();
            try
            {
                var unit = factory.CreateUnitOfWork();
                var item = mapper.Map<Entities.Person>(request.Person);
                unit.Persons.Create(item);
                unit.Save();
                resp.Person = mapper.Map<Person>(unit.Persons.GetItem(item.Id));
            }
            catch (Exception e) { resp.AddMessage(new Contracts.Message(e.Message)); };
            return resp;
        }
        /// <summary>
        /// Создаёт новую персону асинхронно
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdatePersonResponse> CreateAsync(UpdatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model UpdatePersonRequest  is invalid");
            var resp = new UpdatePersonResponse();
            try
            {
                var unit = factory.CreateUnitOfWork();
                var item = mapper.Map<Entities.Person>(request.Person);
                unit.Persons.Create(item);
                await unit.SaveAsync();
                resp.Person = mapper.Map<Person>(unit.Persons.GetItem(item.Id));
            }
            catch (Exception e) { resp.AddMessage(new Contracts.Message(e.Message)); };
            return resp;
        }
        /// <summary>
        /// Обновляет данные персоны
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdatePersonResponse Update(UpdatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model UpdatePersonRequest  is invalid");
            var resp = new UpdatePersonResponse();
            try
            {
                var unit = factory.CreateUnitOfWork();
                var item = mapper.Map<Entities.Person>(request.Person);
                unit.Persons.Update(item);
                unit.Save();
            }
            catch (Exception e) { resp.AddMessage(new Contracts.Message(e.Message)); };
            return resp;
        }
        /// <summary>
        /// Обновляет данные персоны асинхронно
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdatePersonResponse> UpdateAsync(UpdatePersonRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model UpdatePersonRequest  is invalid");
            var resp = new UpdatePersonResponse();
            try
            {
                var unit = factory.CreateUnitOfWork();
                var item = mapper.Map<Entities.Person>(request.Person);
                unit.Persons.Update(item);
                await unit.SaveAsync();
            }
            catch (Exception e) { resp.AddMessage(new Contracts.Message(e.Message)); };
            return resp;
        }
        /// <summary>
        /// Удаляет данные персоны
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeletePersonResponse Delete(DeletePersonRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model DeletePersonRequest  is invalid");
            var resp = new DeletePersonResponse();
            try
            {
                var unit = factory.CreateUnitOfWork();
                unit.Persons.Delete(request.Id);
                unit.Save();
            }
            catch (Exception e) { resp.AddMessage(new Contracts.Message(e.Message)); };
            return resp;
        }
        /// <summary>
        /// Удаляет данные персоны асинхронно 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeletePersonResponse> DeleteAsync(DeletePersonRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model DeletePersonRequest  is invalid");
            var resp = new DeletePersonResponse();
            try
            {
                var unit = factory.CreateUnitOfWork();
                unit.Persons.Delete(request.Id);
                await unit.SaveAsync();
            }
            catch (Exception e) { resp.AddMessage(new Contracts.Message(e.Message)); };
            return resp;
        }
        /// <summary>
        /// Загружает файл биографии персоны.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public PersonUploadResponse Upload(PersonUploadRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model PersonUploadRequest  is invalid");
            var resp = new PersonUploadResponse();
            try
            {
                var unit = factory.CreateUnitOfWork();
                var person = unit.Persons.GetItem(request.PersonId);
                person.Biography = request.Biography;
                unit.Persons.Update(person);
                unit.Save();
            }
            catch (Exception e) { resp.AddMessage(new Contracts.Message(e.Message)); };
            return resp;
        }
        /// <summary>
        /// Загружает файл биографии персоны асинхронно.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PersonUploadResponse> UploadAsync(PersonUploadRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model PersonUploadRequest  is invalid");
            var resp = new PersonUploadResponse();
            try
            {
                var unit = factory.CreateUnitOfWork();
                var person = await unit.Persons.GetItemAsync(request.PersonId);
                person.Biography = request.Biography;
                unit.Persons.Update(person);
                unit.Save();
            }
            catch (Exception e) { resp.AddMessage(new Contracts.Message(e.Message)); };
            return resp;
        }
        /// <summary>
        /// Отдаёт клиенту на скачивание файл биографии персоны
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public byte[] Download(GetPersonRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model GetPersonRequest  is invalid");
            var person = factory.CreateUnitOfWork().Persons.GetItem(request.Id);
            return person.Biography;

        }
        /// <summary>
        /// Отдаёт клиенту на скачивание файл биографии персоны асинхронно
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<byte[]> DownloadAsync(GetPersonRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model GetPersonRequest  is invalid");
            var person = await factory.CreateUnitOfWork().Persons.GetItemAsync(request.Id);
            return person.Biography;

        }
        /// <summary>
        /// Удаляет файл биографии персоны
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeletePersonResponse DeleteBiography(DeletePersonRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model DeletePersonRequest  is invalid");
            var resp = new DeletePersonResponse();
            try
            {
                var unit = factory.CreateUnitOfWork();
                var person = unit.Persons.GetItem(request.Id);
                person.Biography = null;
                unit.Persons.Update(person);
                unit.Save();
            }
            catch (Exception e) { resp.AddMessage(new Contracts.Message(e.Message)); };
            return resp;
        }
        /// <summary>
        /// Отдаёт клиенту на скачивание файл биографии персоны, асинхронно
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeletePersonResponse> DeleteBiographyAsync(DeletePersonRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("Person model DeletePersonRequest  is invalid");
            var resp = new DeletePersonResponse();
            try
            {
                var unit = factory.CreateUnitOfWork();
                var person = await unit.Persons.GetItemAsync(request.Id);
                person.Biography = null;
                unit.Persons.Update(person);
                await unit.SaveAsync();
            }
            catch (Exception e) { resp.AddMessage(new Contracts.Message(e.Message)); };
            return resp;
        }

    }
}
