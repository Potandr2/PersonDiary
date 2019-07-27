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
        //Впрыскиваем зависимости объектов уровня доступа к данным для впрыска в модель
        public PersonController(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }
        // GET: api/Person
        [HttpGet]
        public async Task<GetPersonListResponse> Get(string json)
        {
            return await new PersonModel(unit, mapper).GetItemsAsync(JsonConvert.DeserializeObject<GetPersonListRequest>(json));
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<GetPersonResponse> Get(int id)
        {
            return await new PersonModel(unit, mapper).GetItemAsync(new GetPersonRequest() { Id = id, withLifeEvents = true });
        }

        // POST: api/Person
        [HttpPost]
        public async Task<UpdatePersonResponse> Post([FromBody]  UpdatePersonRequest request)
        {
            return await new PersonModel(unit, mapper).CreateAsync(request);
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public async Task<UpdatePersonResponse> Put(int id, [FromBody] UpdatePersonRequest request)
        {
            return await new PersonModel(unit, mapper).UpdateAsync(request);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<DeletePersonResponse> Delete(int id)
        {
            return await new PersonModel(unit, mapper).DeleteAsync(new DeletePersonRequest() { Id = id });
        }

    }
}