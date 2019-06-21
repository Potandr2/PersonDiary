using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Contracts
{
    public class Response
    {
        public List<Message> Messages { get; set; } = new List<Message>();
    }
}
