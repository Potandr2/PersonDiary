using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using PersonDiary.Contracts.LifeEventContract;
using Newtonsoft.Json;

namespace PersonDiary.Angular.EFCore.Binders
{
    public class GerLifeEventListRequestDiaryBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var jsonString = bindingContext.ActionContext.HttpContext.Request.Query["json"];
            GetLifeEventListRequest result = JsonConvert.DeserializeObject<GetLifeEventListRequest>(jsonString);
            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
