namespace PersonDiary.Contracts
{
    //Сообщение которые получает клиент в ответе из бизнес логики
    public class Message
    {
        public Message() { }
        public Message(string text)
        {
            this.Type = MessageTypeEnum.Error;
            this.Text = text;
        }
        public string Text { get; set; }
        public MessageTypeEnum Type { get; set; }
    }
}
