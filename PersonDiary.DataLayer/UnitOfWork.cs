using PersonDiary.Contexts;
using PersonDiary.Interfaces;
using System;

namespace PersonDiary.Repositories
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private SqlContext db = new SqlContext();
        private PersonRepository repoPerson;
        private LifeEventRepository repoLifeEvent;

        public IPersonRepository Persons
        {
            get
            {
                if (repoPerson == null)
                    repoPerson = new PersonRepository(db);
                return repoPerson;
            }
        }

        public ILifeEventRepository LifeEvents
        {
            get
            {
                if (repoLifeEvent == null)
                    repoLifeEvent = new LifeEventRepository(db);
                return repoLifeEvent;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
