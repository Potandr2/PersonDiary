using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Contracts.PersonContract
{
    public class GetPersonRequest:Request
    {
        public int Id { get; set; }
        public bool WithLifeEvents { get; set; }
    }
}
