using System;

namespace PersonDiary.Entities
{
    public class LifeEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime EventDate { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
