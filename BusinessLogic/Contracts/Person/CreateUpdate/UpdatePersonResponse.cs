using PersonDiary.Contracts.PersonContract;

namespace PersonDiary.Contracts.PersonContract
{
    public class UpdatePersonResponse:Response
    {
        public Person Person { get; set; }
    }
}
