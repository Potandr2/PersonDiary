using System.Collections.Generic;

namespace PersonDiary.Contracts.PersonContract
{
    public class GetPersonListResponse : Response
    {
        public List<Person> Persons { get; set; }
    }
}
