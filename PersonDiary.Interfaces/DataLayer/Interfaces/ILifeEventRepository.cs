using PersonDiary.Entities;
using System.Collections.Generic;

namespace PersonDiary.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория событий в жизни персоны
    /// </summary>
    public interface ILifeEventRepository : IRepository<LifeEvent>
    {
        //Чтение событий персоны по её id
        IEnumerable<LifeEvent> GetPersonItems(int PersonId);
    }
}
