using PersonDiary.Entities;
namespace PersonDiary.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория персон, тут мы возможно добавим методы расширяющие родительский интерфейс
    /// </summary>
    public interface IPersonRepository : IRepository<Person>
    {

    }
}
