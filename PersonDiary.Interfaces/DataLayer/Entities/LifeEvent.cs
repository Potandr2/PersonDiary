using System;

namespace PersonDiary.Entities
{
    //Сущность события в жизни персоны
    public class LifeEvent
    {
        public int Id { get; set; }
        //имя
        public string Name { get; set; }
        //дата события
        public DateTime EventDate { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
}
