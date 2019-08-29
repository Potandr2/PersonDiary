using AutoMapper;
using PersonDiary.Contracts;
using PersonDiary.Contracts.LifeEventContract;
using PersonDiary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifeEventContract = PersonDiary.Contracts.LifeEventContract.LifeEvent;

namespace PersonDiary.BusinessLogic
{
    //Модель события персоны
    public class LifeEventModel
    {
        private readonly IUnitOfWorkFactory factory;
        private readonly IMapper mapper;
        //Впрыскиваем зависимости объектов уровня доступа к данным
        public LifeEventModel(IUnitOfWorkFactory factory, IMapper mapper)
        {
            this.factory = factory ?? throw new ArgumentNullException("UnitOfWorkFactory in LifeEventModel is null");
            this.mapper = mapper ?? throw new ArgumentNullException("Mapper in LifeEventModel is null");
        }
        /// <summary>
        /// Осуществляет постраничную выборку списка событий в жизни персоны
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetLifeEventListResponse GetItems(GetLifeEventListRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("LifeEventModel model GetLifeEventListRequest  is invalid");
            var resp = new GetLifeEventListResponse();
            try
            {
                resp.LifeEvents = mapper.Map<List<LifeEventContract>>(
                    factory.CreateUnitOfWork().LifeEvents.GetItems(request.PageNo, request.PageSize).ToList()
                );
            }
            catch (Exception e) { resp.Messages.Add(new Message(e.Message)); }
            return resp;

        }
        /// <summary>
        /// Осуществляет постраничную выборку списка событий в жизни персоны, асинхронно
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetLifeEventListResponse> GetItemsAsync(GetLifeEventListRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("LifeEventModel model GetLifeEventListRequest  is invalid");
            var resp = new GetLifeEventListResponse();
            try
            {
                resp.LifeEvents = mapper.Map<List<LifeEventContract>>(
                    await factory.CreateUnitOfWork().LifeEvents.GetItemsAsync(request.PageNo, request.PageSize)
                );
            }
            catch (Exception e) { resp.Messages.Add(new Message(e.Message)); }
            return resp;

        }
        /// <summary>
        /// Осуществляет выборку события в жизни персоны
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public GetLifeEventResponse GetItem(GetLifeEventRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("LifeEventModel model GetLifeEventRequest  is invalid");
            var resp = new GetLifeEventResponse();
            try
            {
                resp.lifeevent = mapper.Map<LifeEventContract>(
                    factory.CreateUnitOfWork().LifeEvents.GetItem(request.Id)
                );
            }
            catch (Exception e) { resp.Messages.Add(new Message(e.Message)); }
            return resp;
        }
        /// <summary>
        /// Осуществляет выборку события в жизни персоны асинхронно
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<GetLifeEventResponse> GetItemAsync(GetLifeEventRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("LifeEventModel model GetLifeEventRequest  is invalid");
            var resp = new GetLifeEventResponse();
            try
            {
                resp.lifeevent = mapper.Map<LifeEventContract>(
                    await factory.CreateUnitOfWork().LifeEvents.GetItemAsync(request.Id)
                );
            }
            catch (Exception e) { resp.Messages.Add(new Message(e.Message)); }
            return resp;
        }
        /// <summary>
        /// Создаёт новое событие 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateLifeEventResponse Create(UpdateLifeEventRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("LifeEventModel model UpdateLifeEventRequest  is invalid");
            var resp = new UpdateLifeEventResponse();
            try
            {
                var item = mapper.Map<PersonDiary.Entities.LifeEvent>(request.LifeEvent);
                var unit = factory.CreateUnitOfWork();
                unit.LifeEvents.Create(item);
                unit.Save();
            }
            catch (Exception e) { resp.Messages.Add(new Message(e.Message)); }
            return resp;
        }
        /// <summary>
        /// Создаёт новое событие асинхронно
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateLifeEventResponse> CreateAsync(UpdateLifeEventRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("LifeEventModel model UpdateLifeEventRequest  is invalid");
            var resp = new UpdateLifeEventResponse();
            try
            {
                var item = mapper.Map<PersonDiary.Entities.LifeEvent>(request.LifeEvent);
                var unit = factory.CreateUnitOfWork();
                unit.LifeEvents.Create(item);
                await unit.SaveAsync();
            }
            catch (Exception e) { resp.Messages.Add(new Message(e.Message)); }
            return resp;
        }
        /// <summary>
        /// Обновляет событие в жизни персоны
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public UpdateLifeEventResponse Update(UpdateLifeEventRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("LifeEventModel model UpdateLifeEventRequest  is invalid");
            var resp = new UpdateLifeEventResponse();
            try
            {
                var item = mapper.Map<PersonDiary.Entities.LifeEvent>(request.LifeEvent);
                var unit = factory.CreateUnitOfWork();
                unit.LifeEvents.Update(item);
                unit.Save();
            }
            catch (Exception e) { resp.Messages.Add(new Message(e.Message)); }
            return resp;
        }
        /// <summary>
        /// Обновляет событие в жизни персоны асинхронно
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<UpdateLifeEventResponse> UpdateAsync(UpdateLifeEventRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("LifeEventModel model UpdateLifeEventRequest  is invalid");
            var resp = new UpdateLifeEventResponse();
            try
            {
                var item = mapper.Map<PersonDiary.Entities.LifeEvent>(request.LifeEvent);
                var unit = factory.CreateUnitOfWork();
                unit.LifeEvents.Update(item);
                await unit.SaveAsync();
            }
            catch (Exception e) { resp.Messages.Add(new Message(e.Message)); }
            return resp;
        }
        /// <summary>
        /// Удаляет событие из жизни персоны
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public DeleteLifeEventResponse Delete(DeleteLifeEventRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("LifeEventModel model DeleteLifeEventRequest  is invalid");
            var resp = new DeleteLifeEventResponse();
            try
            {
                var unit = factory.CreateUnitOfWork();
                unit.LifeEvents.Delete(request.Id);
                unit.Save();
            }
            catch (Exception e) { resp.Messages.Add(new Message(e.Message)); }
            return resp;
        }
        /// <summary>
        /// Удаляет событие из жизни персоны асинхронно
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<DeleteLifeEventResponse> DeleteAsync(DeleteLifeEventRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("LifeEventModel model DeleteLifeEventRequest  is invalid");
            var resp = new DeleteLifeEventResponse();
            try
            {
                var unit = factory.CreateUnitOfWork();
                unit.LifeEvents.Delete(request.Id);
                await unit.SaveAsync();
            }
            catch (Exception e) { resp.Messages.Add(new Message(e.Message)); }
            return resp;
        }

    }
}
