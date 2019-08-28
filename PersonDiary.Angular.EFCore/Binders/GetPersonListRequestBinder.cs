using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using PersonDiary.Contracts.PersonContract;
using System.Threading.Tasks;

namespace PersonDiary.Angular.EFCore.Binders
{
    public class GerPersonListRequestDiaryBinder : IModelBinder
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
