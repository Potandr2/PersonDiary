using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonDiary.Interfaces;
using AutoMapper;
using PersonDiary.BusinessLogic;
using PersonDiary.Contracts.LifeEventContract;

namespace LifeEventDiary.Angular.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeEventController : ControllerBase
    {
        LifeEventModel model;
        public LifeEventController(IUnitOfWork unit, IMapper mapper)
        {
            model = new LifeEventModel(unit, mapper);
        }
        // GET: api/LifeEvent
        [HttpGet]
        public GetLifeEventListResponse Get(GetLifeEventListRequest request)
        {
            return model.GetItems(request);
        }

        // GET: api/LifeEvent/5
        [HttpGet("{id}")]
        public GetLifeEventResponse Get(GetLifeEventRequest request)
        {
            return model.GetItem(request);
        }

        // POST: api/LifeEvent
        [HttpPost]
        public UpdateLifeEventResponse Post([FromBody]  UpdateLifeEventRequest request)
        {
            return model.Create(request);
        }

        // PUT: api/LifeEvent/5
        [HttpPut("{id}")]
        public UpdateLifeEventResponse Put(int id, [FromBody] UpdateLifeEventRequest request)
        {
            return model.Update(request);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public DeleteLifeEventResponse Delete(DeleteLifeEventRequest request)
        {
            return model.Delete(request);
        }
    }
}
