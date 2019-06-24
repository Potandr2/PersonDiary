using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonDiary.Entities;
using PersonDiary.Interfaces;
using AutoMapper;
using PersonDiary.BusinessLogic;
using PersonDiary.Contracts.PersonContract;

namespace PersonDiary.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        PersonModel model;
        public PersonController(IUnitOfWork unit, IMapper mapper)
        {
            model = new PersonModel(unit, mapper);
        }
        // GET: api/Person
        [HttpGet]
        public GetPersonListResponse Get(GetPersonListRequest request)
        {
            return model.GetItems(request);
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public GetPersonResponse Get(GetPersonRequest request)
        {
            return model.GetItem(request);
        }

        // POST: api/Person
        [HttpPost]
        public UpdatePersonResponse Post([FromBody]  UpdatePersonRequest request)
        {
            return model.Create(request);
        }

        // PUT: api/Person/5
        [HttpPut("{id}")]
        public UpdatePersonResponse Put(int id, [FromBody] UpdatePersonRequest request)
        {
            return model.Update(request);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public DeletePersonResponse  Delete(DeletePersonRequest request)
        {
            return model.Delete(request);
        }
    }
}
