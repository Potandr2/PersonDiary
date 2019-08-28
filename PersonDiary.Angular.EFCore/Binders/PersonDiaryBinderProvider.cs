using Microsoft.AspNetCore.Mvc.ModelBinding;
using PersonDiary.Contracts.PersonContract;

namespace PersonDiary.Angular.EFCore.Binders
{
    public class PersonDiaryBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(GetPersonListRequest))
                return new GerPersonListRequestDiaryBinder();

            return null;
        }
    }
}
