namespace PersonDiary.Contracts.PersonContract
{
    public class GetPersonListRequest : Request
    {
        public bool withLifeEvents { get; set; }
    }
}
