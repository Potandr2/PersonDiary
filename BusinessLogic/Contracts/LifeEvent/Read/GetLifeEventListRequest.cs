using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Contracts.LifeEventContract
{
    public class GetLifeEventListRequest:Request
    {
        public LifeEvent LifeEvent { get; set; }
    }
}
