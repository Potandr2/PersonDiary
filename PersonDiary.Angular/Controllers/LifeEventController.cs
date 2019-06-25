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
using Newtonsoft.Json;

namespace LifeEventDiary.Angular.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeEventController : ControllerBase
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;
        public LifeEventController(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }
        // GET: api/LifeEvent
        [HttpGet]
        public GetLifeEventListResponse Get()
        {
            return new LifeEventModel(unit, mapper).GetItems(new GetLifeEventListRequest());
        }

        // GET: api/LifeEvent/5
        [HttpGet("{id}")]
        public GetLifeEventResponse Get(int id)
        {
            return new LifeEventModel(unit, mapper).GetItem(new GetLifeEventRequest() { Id = id });
        }

        // POST: api/LifeEvent
        [HttpPost]
        public UpdateLifeEventResponse Post([FromBody]  UpdateLifeEventRequest request)
        {
            return new LifeEventModel(unit, mapper).Create(request);
        }

        // PUT: api/LifeEvent/5
        [HttpPut("{id}")]
        public UpdateLifeEventResponse Put(int id, [FromBody] UpdateLifeEventRequest request)
        {
            return new LifeEventModel(unit, mapper).Update(request);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public DeleteLifeEventResponse Delete(DeleteLifeEventRequest request)
        {
            return new LifeEventModel(unit, mapper).Delete(request);
        }
    }
}
