using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Contracts.LifeEventContract
{
    public class UpdateLifeEventRequest:Request
    {
        public LifeEvent LifeEvent { get; set; }
    }
}
