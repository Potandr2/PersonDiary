using System.Collections.Generic;
namespace PersonDiary.Entities
{
    //Класс сущности персоны
    public class Person
    {
        public int Id { get; set; }
        //имя
        public string Name { get; set; }
        //фамилия
        public string Surname { get; set; }
        //события в жизни персоны
        public List<LifeEvent> LifeEvents { get; set; }
        //.doc/.docx файл биографии персоны
        public byte[] Biography { get; set; }
    }
}
