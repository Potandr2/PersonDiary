using System.Collections.Generic;
namespace PersonDiary.Interfaces.Entities
{
    public class PersonData
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<LifeEvent> LifeEvents { get; set; }
    }
}
