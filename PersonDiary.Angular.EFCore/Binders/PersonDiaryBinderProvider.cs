using Microsoft.AspNetCore.Mvc.ModelBinding;
using PersonDiary.Contracts.PersonContract;
using PersonDiary.Contracts.LifeEventContract;

namespace PersonDiary.Angular.EFCore.Binders
{
    public class PersonDiaryBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType == typeof(GetPersonListRequest))
                return new GerPersonListRequestDiaryBinder ();
            if (context.Metadata.ModelType == typeof(GetLifeEventListRequest))
                return new GerLifeEventListRequestDiaryBinder();

            return null;
        }
    }
}
