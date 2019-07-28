using PersonDiary.Entities;
using System.Collections.Generic;

namespace PersonDiary.Interfaces
{
    public interface ILifeEventRepository : IRepository<LifeEvent>
    {
        //Чтение событий персоны по её id
        IEnumerable<LifeEvent> GetPersonItems(int PersonId);
    }
}
