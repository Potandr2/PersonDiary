using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PersonDiary.BusinessLogic;
using PersonDiary.Contracts.PersonContract;
using PersonDiary.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace PersonDiary.Angular.EFCore.Controllers
{
    //Контроллер для работы с файлами персон, работа с файлами выделена вотдельный контроллер согласно принципу SPR(SOLID)
    [Route("api/[controller]")]
    [ApiController]
    public class PersonFileController : ControllerBase
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;
        private readonly IHostingEnvironment hostingEnvironment;

        public PersonFileController(IUnitOfWork unit, IMapper mapper, IHostingEnvironment hostingEnvironment)
        {

            this.unit = unit;
            this.mapper = mapper;
            this.hostingEnvironment = hostingEnvironment;
        }
        // GET: api/PersonFile
        [HttpGet]
        public IEnumerable<string> Get()
        {
            throw new NotImplementedException("file list not implemented");
        }

        // GET: api/PersonFile/5
        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            byte[] bytes = await new PersonModel(unit, mapper).DownloadAsync(new GetPersonRequest() { Id = id });
            return File(bytes, "application/octet-stream", "biographi.docx");
        }
        // POST: api/PersonFile
        [HttpPost]
        [Consumes("application/json", "multipart/form-data")]
        public async Task<PersonUploadResponse> Post(string json)
        {
            PersonUploadRequest request = JsonConvert.DeserializeObject<PersonUploadRequest>(json);
            return await UploadBiographyAsync(request);
        }
        // PUT: api/PersonFile/5
        [HttpPut("{id}")]
        public async Task<PersonUploadResponse> Put(int id)
        {
            return await UploadBiographyAsync(new PersonUploadRequest() { PersonId = id });
        }
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<DeletePersonResponse> Delete(int id)
        {
            return await Task.Run(() => new PersonModel(unit, mapper).DeleteBiography(new DeletePersonRequest() { Id = id }));
        }
        private async Task<PersonUploadResponse> UploadBiography(PersonUploadRequest request)
        {
            try
            {
                var file = Request.Form.Files[0];

                if (file.Length == 0) return new PersonUploadResponse().AddMessage(new Contracts.Message("Zero files proveided"));
                if (!file.FileName.Contains(".doc")) return new PersonUploadResponse().AddMessage(new Contracts.Message("Only .doc/docx file types allowed"));
                using (var binaryReader = new BinaryReader(file.OpenReadStream()))
                {
                    request.Biography = binaryReader.ReadBytes((int)file.Length);
                    return await new PersonModel(unit, mapper).UploadAsync(request);
                }
            }
            catch (Exception e)
            {
                return new PersonUploadResponse().AddMessage(new Contracts.Message(e.Message));
            }
        }
        private async Task<PersonUploadResponse> UploadBiographyAsync(PersonUploadRequest request)
        {
            return await UploadBiographyAsync(request);
        }
    }
}
