using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonDiary.BusinessLogic;
using PersonDiary.Contracts.LifeEventContract;
using Newtonsoft.Json;
using PersonDiary.Interfaces;
using System.Threading.Tasks;


namespace PersonDiary.React.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LifeEventController : ControllerBase
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;
        //Впрыскиваем зависимости объектов уровня доступа к данным для впрыска в модель
        public LifeEventController(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }
        // GET: api/LifeEvent
        [HttpGet]
        public async Task<GetLifeEventListResponse> Get(string json)
        {
            /*
            var resp = await Task.Run(() => new LifeEventModel(unit, mapper).GetItems(JsonConvert.DeserializeObject<GetLifeEventListRequest>(json)));
            await Task.Run(() =>
                resp.LifeEvents.ForEach(l =>
                {
                    var person = new PersonModel(unit, mapper).GetItem(
                        new Contracts.PersonContract.GetPersonRequest() { Id = l.PersonId, withLifeEvents = false }
                    ).Person;
                    l.Personfullname = $"{person.Surname} {person.Name}";
                })
            );
             */
            var resp = await new LifeEventModel(unit, mapper).GetItemsAsync(JsonConvert.DeserializeObject<GetLifeEventListRequest>(json));
            return resp;
        }


        // GET: api/LifeEvent/5
        [HttpGet("{id}")]
        public async Task<GetLifeEventResponse> Get(int id)
        {
            return await new LifeEventModel(unit, mapper).GetItemAsync(new GetLifeEventRequest() { Id = id });
        }

        // POST: api/LifeEvent
        [HttpPost]
        public async Task<UpdateLifeEventResponse> Post([FromBody]  UpdateLifeEventRequest request)
        {
            return await new LifeEventModel(unit, mapper).CreateAsync(request);
        }

        // PUT: api/LifeEvent/5
        [HttpPut("{id}")]
        public async Task<UpdateLifeEventResponse> Put(int id, [FromBody] UpdateLifeEventRequest request)
        {
            return await new LifeEventModel(unit, mapper).UpdateAsync(request);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<DeleteLifeEventResponse> Delete(int id)
        {
            return await new LifeEventModel(unit, mapper).DeleteAsync(new DeleteLifeEventRequest() { Id = id });
        }
    }
}
