using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonDiary.BusinessLogic;
using PersonDiary.Contracts.LifeEventContract;
using Newtonsoft.Json;
using PersonDiary.Interfaces;
using System.Threading.Tasks;

namespace LifeEventDiary.Angular.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeEventController : ControllerBase
    {
        private readonly IUnitOfWorkFactory factory;
        private readonly IMapper mapper;
        //Впрыскиваем зависимости объектов уровня доступа к данным для впрыска в модель
        public LifeEventController(IUnitOfWorkFactory factory, IMapper mapper)
        {
            this.factory = factory;
            this.mapper = mapper;
        }
        // GET: api/LifeEvent
        [HttpGet]
        public async Task<GetLifeEventListResponse> Get(string json)
        {
            return await new LifeEventModel(factory, mapper).GetItemsAsync(JsonConvert.DeserializeObject<GetLifeEventListRequest>(json));
        }

        // GET: api/LifeEvent/5
        [HttpGet("{id}")]
        public async Task<GetLifeEventResponse> Get(int id)
        {
            return await new LifeEventModel(factory, mapper).GetItemAsync(new GetLifeEventRequest() { Id = id });
        }

        // POST: api/LifeEvent
        [HttpPost]
        public async Task<UpdateLifeEventResponse> Post([FromBody]  UpdateLifeEventRequest request)
        {
            return await new LifeEventModel(factory, mapper).CreateAsync(request);
        }

        // PUT: api/LifeEvent/5
        [HttpPut("{id}")]
        public async Task<UpdateLifeEventResponse> Put(int id, [FromBody] UpdateLifeEventRequest request)
        {
            return await new LifeEventModel(factory, mapper).UpdateAsync(request);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<DeleteLifeEventResponse> Delete(int id)
        {
            return await new LifeEventModel(factory, mapper).DeleteAsync(new DeleteLifeEventRequest() { Id = id });
        }
    }
}
