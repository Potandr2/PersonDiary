using System.Threading.Tasks;
namespace PersonDiary.Interfaces
{
    /// <summary>
    /// интерфейс Unit of Work
    /// </summary>
    public interface IUnitOfWork
    {
        IPersonRepository Persons { get; }
        ILifeEventRepository LifeEvents { get; }
        void Save();
        Task<int> SaveAsync();
    }
}
