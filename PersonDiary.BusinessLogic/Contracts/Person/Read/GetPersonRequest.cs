namespace PersonDiary.Contracts.PersonContract
{
    public class GetPersonRequest : Request
    {
        public int Id { get; set; }
        public bool withLifeEvents { get; set; }
    }
}
