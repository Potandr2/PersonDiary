using AutoMapper;
using PersonDiary.Contracts;
using PersonDiary.Contracts.LifeEventContract;
using PersonDiary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using LifeEventContract = PersonDiary.Contracts.LifeEventContract.LifeEvent;

namespace PersonDiary.BusinessLogic
{
    //Модель события персоны
    public class LifeEventModel
    {
        private readonly IUnitOfWork unit;
        private ILifeEventRepository repoLifeEvent;
        private IMapper mapper;
        //Впрыскиваем зависимости объектов уровня доступа к данным
        public LifeEventModel(IUnitOfWork unit, IMapper mapper)
        {
            if (unit == null)
                throw new ArgumentNullException("Unit in LifeEventModel is null");
            if (mapper == null)
                throw new ArgumentNullException("Mapper in LifeEventModel is null");
            this.unit = unit;
            repoLifeEvent = unit.LifeEvents;

            this.mapper = mapper;
        }

        public GetLifeEventResponse GetItem(GetLifeEventRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("LifeEventModel model GetLifeEventRequest  is invalid");
            var resp = new GetLifeEventResponse();
            try
            {
                resp.lifeevent = mapper.Map<LifeEventContract>(
                    repoLifeEvent.GetItem(request.Id)
                );
            }
            catch (Exception e) { resp.Messages.Add(new Message() { Text = e.Message, Type = MessageTypeEnum.Error }); };
            return resp;
        }
        public GetLifeEventListResponse GetItems(GetLifeEventListRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("LifeEventModel model GetLifeEventListRequest  is invalid");
            var resp = new GetLifeEventListResponse();
            try
            {
                resp.LifeEvents = mapper.Map<List<LifeEventContract>>(
                    repoLifeEvent.GetItems(request.PageNo,request.PageSize).ToList()
                );
            }
            catch (Exception e) { resp.Messages.Add(new Message() { Text = e.Message, Type = MessageTypeEnum.Error }); };
            return resp;

        }
        public UpdateLifeEventResponse Create(UpdateLifeEventRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("LifeEventModel model UpdateLifeEventRequest  is invalid");
            var resp = new UpdateLifeEventResponse();
            try
            {
                var item = mapper.Map<PersonDiary.Entities.LifeEvent>(request.LifeEvent);
                repoLifeEvent.Create(item);
                unit.Save();
            }
            catch (Exception e) { resp.Messages.Add(new Message() { Text = e.Message, Type = MessageTypeEnum.Error }); };
            return resp;
        }
        public UpdateLifeEventResponse Update(UpdateLifeEventRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("LifeEventModel model UpdateLifeEventRequest  is invalid");
            var resp = new UpdateLifeEventResponse();
            try
            {
                var item = mapper.Map<PersonDiary.Entities.LifeEvent>(request.LifeEvent);
                unit.LifeEvents.Update(item);
                unit.Save();
            }
            catch (Exception e) { resp.Messages.Add(new Message() { Text = e.Message, Type = MessageTypeEnum.Error }); };
            return resp;
        }
        public DeleteLifeEventResponse Delete(DeleteLifeEventRequest request)
        {
            if (request == null)
                throw new ArgumentNullException("LifeEventModel model DeleteLifeEventRequest  is invalid");
            var resp = new DeleteLifeEventResponse();
            try
            {
                repoLifeEvent.Delete(request.Id);
                unit.Save();
            }
            catch (Exception e) { resp.Messages.Add(new Message() { Text = e.Message, Type = MessageTypeEnum.Error }); };
            return resp;
        }
        
    }
}
