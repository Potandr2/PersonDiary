namespace PersonDiary.Interfaces
{
    public interface IUnitOfWork
    {
        IPersonRepository Persons { get; }
        ILifeEventRepository LifeEvents { get; }
        void Save();
    }
}
