using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Contracts.LifeEventContract
{
    public class GetLifeEventRequest:Request
    {
        public int Id { get; set; }
    }
}
