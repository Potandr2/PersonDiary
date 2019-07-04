namespace PersonDiary.Contracts
{
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
