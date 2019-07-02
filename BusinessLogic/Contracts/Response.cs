using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Contracts
{
    public class Response<T> where T: Response<T>
    {
        public List<Message> Messages { get; set; } = new List<Message>();
        public T AddMessage(Message message)
        {
            Messages.Add(message);
            return (T) this;
        }
    }
}
