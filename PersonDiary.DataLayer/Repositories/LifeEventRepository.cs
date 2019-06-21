using System;
using System.Collections.Generic;
using PersonDiary.Interfaces;
using PersonDiary.Contexts;
using PersonDiary.Entities;
using Microsoft.EntityFrameworkCore;

namespace PersonDiary.Repositories
{
    public class LifeEventRepository : ILifeEventRepository
    {
        private SqlContext db;
        public LifeEventRepository(SqlContext db)
        {
            this.db = db;
        }
        public IEnumerable<LifeEvent> GetItems()
        {
            return db.LifeEvents;
        }
        public LifeEvent GetItem(int id)
        {
            return db.LifeEvents.Find(id);
        }
        public void Create(LifeEvent item)
        {
            db.LifeEvents.Add(item);
        }
        public void Update(LifeEvent item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            LifeEvent LifeEvent = db.LifeEvents.Find(id);
            if (LifeEvent != null)
                db.LifeEvents.Remove(LifeEvent);
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
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
