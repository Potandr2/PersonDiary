using System.Collections.Generic;

namespace PersonDiary.Contracts
{
    //Класс предок для всех ответов бизнес логики
    public class Response<T> where T : Response<T>
    {
        public List<Message> Messages { get; set; } = new List<Message>();
        public T AddMessage(Message message)
        {
            Messages.Add(message);
            return (T)this;
        }
    }
}
