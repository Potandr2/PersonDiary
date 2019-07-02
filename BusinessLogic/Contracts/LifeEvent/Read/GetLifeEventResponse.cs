using System;
using System.Collections.Generic;
using System.Text;


namespace PersonDiary.Contracts.LifeEventContract
{
    public class GetLifeEventResponse: Response<GetLifeEventResponse>
    {
        public LifeEvent lifeevent { get; set; }
    }
}
