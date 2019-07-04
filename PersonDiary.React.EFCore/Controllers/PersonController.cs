using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonDiary.BusinessLogic;
using PersonDiary.Contracts.PersonContract;
using PersonDiary.Interfaces;

namespace PersonDiary.React.EFCore.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public PersonController(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }
        // GET: api/Person
        [HttpGet]
        public GetPersonListResponse Get(string json)
        {
            return new PersonModel(unit, mapper).GetItems(JsonConvert.DeserializeObject<GetPersonListRequest>(json));
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public GetPersonResponse Get(int id)
        {
            return new PersonModel(unit, mapper).GetItem(new GetPersonRequest() { Id = id, withLifeEvents = true });
        }

        // POST: api/Person
        [HttpPost]
        public UpdatePersonResponse Post([FromBody]  UpdatePersonRequest request)
        {
            return new PersonModel(unit, mapper).Create(request);
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public UpdatePersonResponse Put(int id, [FromBody] UpdatePersonRequest request)
        {
            return new PersonModel(unit, mapper).Update(request);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public DeletePersonResponse Delete(int id)
        {
            return new PersonModel(unit, mapper).Delete(new DeletePersonRequest() { Id = id });
        }

    }
}
