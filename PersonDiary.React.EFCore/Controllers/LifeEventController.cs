using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonDiary.BusinessLogic;
using PersonDiary.Contracts.LifeEventContract;
using PersonDiary.Interfaces;

namespace PersonDiary.React.EFCore.Controllers
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
        public DeleteLifeEventResponse Delete(int id)
        {
            return new LifeEventModel(unit, mapper).Delete(new DeleteLifeEventRequest() { Id = id });
        }
    }
}
