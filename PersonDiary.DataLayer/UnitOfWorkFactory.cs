using PersonDiary.Interfaces;

namespace PersonDiary.Repositories
{
    /// <summary>
    /// Фабрика объектов UnitOfWork 
    /// </summary>
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork CreateUnitOfWork()
        {
            return new UnitOfWork();
        }
    }
}
