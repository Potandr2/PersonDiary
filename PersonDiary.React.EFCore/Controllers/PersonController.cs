using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonDiary.BusinessLogic;
using PersonDiary.Contracts.PersonContract;
using PersonDiary.Interfaces;
using System.Threading.Tasks;
using System;

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
        public async Task<GetPersonListResponse> Get(string json)
        {
            return await Task.Run(()=> new PersonModel(unit, mapper).GetItems(JsonConvert.DeserializeObject<GetPersonListRequest>(json)));
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<GetPersonResponse> Get(int id)
        {
            return await Task.Run(()=> new PersonModel(unit, mapper).GetItem(new GetPersonRequest() { Id = id, withLifeEvents = true }));
        }

        // POST: api/Person
        [HttpPost]
        public async Task<UpdatePersonResponse> Post([FromBody]  UpdatePersonRequest request)
        {
            return await Task.Run(()=> new PersonModel(unit, mapper).Create(request));
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public async Task<UpdatePersonResponse> Put(int id, [FromBody] UpdatePersonRequest request)
        {
            if (DateTime.Now.Second > 30)
            {
                return new UpdatePersonResponse();
            }
            else
            {
               return new UpdatePersonResponse().AddMessage(new Contracts.Message("asdfasdf"));
            }
            return new UpdatePersonResponse();//await Task.Run(()=>new PersonModel(unit, mapper).Update(request));
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<DeletePersonResponse> Delete(int id)
        {
            return new DeletePersonResponse().AddMessage(new Contracts.Message("asdfasdf"));// await Task.Run(() => new PersonModel(unit, mapper).Delete(new DeletePersonRequest() { Id = id }));
        }

    }
}
