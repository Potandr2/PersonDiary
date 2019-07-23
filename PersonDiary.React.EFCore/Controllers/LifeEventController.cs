using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PersonDiary.BusinessLogic;
using PersonDiary.Contracts.LifeEventContract;
using Newtonsoft.Json;
using PersonDiary.Interfaces;
using System.Threading.Tasks;
using System.Linq;

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
        public async Task<GetLifeEventListResponse> Get(string json)
        {
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
            
            return resp;
        }
        
        // GET: api/LifeEvent/5
        [HttpGet("{id}")]
        public async Task<GetLifeEventResponse> Get(int id)
        {
            return await Task.Run(()=>new LifeEventModel(unit, mapper).GetItem(new GetLifeEventRequest() { Id = id }));
        }

        // POST: api/LifeEvent
        [HttpPost]
        public async Task<UpdateLifeEventResponse> Post([FromBody]  UpdateLifeEventRequest request)
        {
            return await Task.Run(()=>new LifeEventModel(unit, mapper).Create(request));
        }

        // PUT: api/LifeEvent/5
        [HttpPut("{id}")]
        public async Task<UpdateLifeEventResponse> Put(int id, [FromBody] UpdateLifeEventRequest request)
        {
            return await Task.Run(()=>new LifeEventModel(unit, mapper).Update(request));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<DeleteLifeEventResponse> Delete(int id)
        {
            return new DeleteLifeEventResponse().AddMessage(new Contracts.Message("asdfasdf")); //await Task.Run(()=>new LifeEventModel(unit, mapper).Delete(new DeleteLifeEventRequest() { Id = id }));
        }
    }
}
