using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Contracts.LifeEventContract
{
    public class GetLifeEventListResponse:Response<GetLifeEventListResponse>
    {
        public List<LifeEvent> LifeEvents { get; set; }
    }
}
