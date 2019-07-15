using PersonDiary.Entities;
using System.Collections.Generic;

namespace PersonDiary.Interfaces
{
    public interface ILifeEventRepository : IRepository<LifeEvent>
    {
        IEnumerable<LifeEvent> GetPersonItems(int PersonId);
    }
}
