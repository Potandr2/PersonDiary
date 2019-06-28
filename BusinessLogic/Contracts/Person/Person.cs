using System;
using System.Collections.Generic;
using System.Text;
using PersonDiary.Contracts.LifeEventContract;

namespace PersonDiary.Contracts.PersonContract
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<LifeEvent> LifeEvents { get; set; }
        public bool HasFile { get; set; }

    }
}
