using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonDiary.BusinessLogic;
using PersonDiary.Contracts.PersonContract;
using PersonDiary.Interfaces;
using System.Threading.Tasks;

namespace PersonDiary.React.EFCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IUnitOfWorkFactory factory;
        private readonly IMapper mapper;
        //Впрыскиваем зависимости фабрики объектов уровня доступа к данным для впрыска в модель и маппера контрактов
        public PersonController(IUnitOfWorkFactory factory, IMapper mapper)
        {
            this.factory = factory;
            this.mapper = mapper;
        }
        // Выборка списка персон постранично
        // GET: api/Person
        [HttpGet]
        public async Task<GetPersonListResponse> Get(string json)
        {
            return await new PersonModel(factory, mapper).GetItemsAsync(JsonConvert.DeserializeObject<GetPersonListRequest>(json));
        }
        // Выборка данных персоны
        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<GetPersonResponse> Get(int id)
        {
            return await new PersonModel(factory, mapper).GetItemAsync(new GetPersonRequest() { Id = id, withLifeEvents = true });
        }
        //Создание персоны
        // POST: api/Person
        [HttpPost]
        public async Task<UpdatePersonResponse> Post([FromBody]  UpdatePersonRequest request)
        {
            return await new PersonModel(factory, mapper).CreateAsync(request);
        }
        //Обновление персоны
        // PUT: api/Person/5
        [HttpPut("{id}")]
        public async Task<UpdatePersonResponse> Put(int id, [FromBody] UpdatePersonRequest request)
        {
            return await new PersonModel(factory, mapper).UpdateAsync(request);
        }
        //Удаление персоны
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<DeletePersonResponse> Delete(int id)
        {
            return await new PersonModel(factory, mapper).DeleteAsync(new DeletePersonRequest() { Id = id });
        }

    }
}