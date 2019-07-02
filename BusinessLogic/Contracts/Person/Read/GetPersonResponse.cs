
namespace PersonDiary.Contracts.PersonContract
{
    public class GetPersonResponse : Response<GetPersonResponse>
    {
        public Person Person { get; set; }
    }
}
