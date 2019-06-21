using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Contracts
{
    public class Message
    { 
        public string Text { get; set; }
        public MessageTypeEnum Type { get; set; }
    }
}
