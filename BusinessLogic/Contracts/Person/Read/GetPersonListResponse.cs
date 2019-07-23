using System.Collections.Generic;

namespace PersonDiary.Contracts.PersonContract
{
    public class GetPersonListResponse : Response<GetPersonListResponse>
    {
        public List<Person> Persons { get; set; }
        public int Count {get;set;}
    }
}
