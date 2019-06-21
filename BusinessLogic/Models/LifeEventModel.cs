using System;
using System.Linq;
using PersonDiary.Interfaces;
using PersonDiary.Contracts;
using System.Collections.Generic;
using PersonDiary.Contracts.LifeEventContract;
using LifeEventContract = PersonDiary.Contracts.LifeEventContract.LifeEvent;
using AutoMapper;

namespace LifeEventDiary.BusinessLogic
{
    public class LifeEventModel
    {
        private readonly IUnitOfWork unit;
        private ILifeEventRepository repoLifeEvent;
        private IMapper mapper;
        public LifeEventModel(IUnitOfWork unit, IMapper mapper)
        {
            if (unit == null)
                throw new ArgumentNullException("Unit and LifeEvents repository is null");
            this.unit = unit;
            repoLifeEvent = unit.LifeEvents;

            this.mapper = mapper;
        }
        
        public GetLifeEventResponse GetItem(GetLifeEventRequest request)
        {
            var resp = new GetLifeEventResponse();
            try
            {
                resp.LifeEvent = mapper.Map<LifeEventContract>(
                    repoLifeEvent.GetItems().FirstOrDefault(p => p.Id == request.Id)
                );
            }
            catch (Exception e) { resp.Messages.Add(new  Message() { Text = e.Message, Type = MessageTypeEnum.Error }); };
            return resp;
        }
        public GetLifeEventListResponse GetItems(GetLifeEventListRequest request)
        {
            var resp = new GetLifeEventListResponse();
            try
            {
                resp.LifeEvents = mapper.Map<List<LifeEventContract>>(
                    repoLifeEvent.GetItems().ToList()
                    );
            }
            catch (Exception e) { resp.Messages.Add(new Message() { Text = e.Message, Type = MessageTypeEnum.Error }); };
            return resp;

        }
        public UpdateLifeEventResponse Create(UpdateLifeEventRequest request)
        {
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
            var resp = new DeleteLifeEventResponse();
            try
            {
                repoLifeEvent.Delete(request.Id);
                unit.Save();
            }
            catch (Exception e) { resp.Messages.Add(new Message() { Text = e.Message, Type = MessageTypeEnum.Error }); };
            return resp;
        }
        public void UploadBiography()
        {
        }
    }
}
