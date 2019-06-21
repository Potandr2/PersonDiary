using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Contracts.PersonContract
{
    public class DeletePersonRequest:Request
    {
        public int Id { get; set; }
    }
}
