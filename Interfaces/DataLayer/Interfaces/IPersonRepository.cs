using PersonDiary.Entities;
using System.Collections.Generic;
namespace PersonDiary.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        IEnumerable<Person> GetItems(bool withLifeEVents=false);
    }
}
