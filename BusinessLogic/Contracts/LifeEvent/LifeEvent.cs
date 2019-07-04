using System;

namespace PersonDiary.Contracts.LifeEventContract
{
    public class LifeEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Eventdate { get; set; }
        public string Personfullname { get; set; }
        public int PersonId { get; set; }

    }
}
