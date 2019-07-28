namespace PersonDiary.Contracts.LifeEventContract
{
    public class GetLifeEventListRequest : Request
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
    }
}
