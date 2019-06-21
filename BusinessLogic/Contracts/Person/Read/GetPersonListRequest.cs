using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Contracts.PersonContract
{
    public class GetPersonListRequest:Request
    {
        public bool withLifeEvents { get; set; }
    }
}
