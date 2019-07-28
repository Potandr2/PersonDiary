using System.Threading.Tasks;
namespace PersonDiary.Interfaces
{
    public interface IUnitOfWork
    {
        IPersonRepository Persons { get; }
        ILifeEventRepository LifeEvents { get; }
        void Save();
        Task<int> SaveAsync();
    }
}
