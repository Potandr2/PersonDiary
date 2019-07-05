namespace PersonDiary.Contracts.PersonContract
{
    public class GetPersonListRequest : Request
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
