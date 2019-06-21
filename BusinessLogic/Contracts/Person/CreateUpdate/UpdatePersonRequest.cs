using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Contracts.PersonContract
{
    public class UpdatePersonRequest:Request
    {
        public Person Person { get; set; }
    }
}
