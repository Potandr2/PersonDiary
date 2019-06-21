using System.Collections.Generic;
namespace PersonDiary.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<LifeEvent> LifeEvents { get; set; }

        public byte[] Biography { get; set; }
    }
}
