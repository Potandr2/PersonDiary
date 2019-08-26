using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonDiary.Contracts.PersonContract;
using Newtonsoft.Json;

namespace PersonDiary.Angular.EFCore.Binders
{
    public class GerPersonListRequestDiaryBinder :IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var jsonString = bindingContext.ActionContext.HttpContext.Request.Query["json"];
            GetPersonListRequest result = JsonConvert.DeserializeObject<GetPersonListRequest>(jsonString);
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
