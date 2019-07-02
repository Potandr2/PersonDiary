using PersonDiary.Contracts.PersonContract;

namespace PersonDiary.Contracts.PersonContract
{
    public class UpdatePersonResponse:Response<UpdatePersonResponse>
    {
        public Person Person { get; set; }
    }
}
