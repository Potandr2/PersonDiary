using System.Collections.Generic;

namespace PersonDiary.Contracts.LifeEventContract
{
    public class GetLifeEventListResponse : Response<GetLifeEventListResponse>
    {
        public List<LifeEvent> LifeEvents { get; set; }
    }
}
