namespace PersonDiary.Contracts.PersonContract
{
    public class UpdatePersonRequest : Request
    {
        public Person Person { get; set; }
    }
}
