using System.Collections.Generic;

namespace PersonDiaryInterfaces.Entities
{
    public class PersonData
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<LifeEvent> LifeEvents { get; set; }
    }
}
