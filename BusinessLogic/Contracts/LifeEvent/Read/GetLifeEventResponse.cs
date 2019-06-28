using System;
using System.Collections.Generic;
using System.Text;


namespace PersonDiary.Contracts.LifeEventContract
{
    public class GetLifeEventResponse: Response
    {
        public LifeEvent lifeevent { get; set; }
    }
}
