using Microsoft.EntityFrameworkCore;
using PersonDiary.Contexts;
using PersonDiary.Entities;
using PersonDiary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonDiary.Repositories
{
    //реализация репозитория событий персоны для MS SQL и EF Core
    public class LifeEventRepository : ILifeEventRepository
    {
        private SqlContext db;
        public LifeEventRepository(SqlContext db)
        {
            this.db = db;
        }
        public IEnumerable<LifeEvent> GetItems(int PageNo, int PageSize)
        {
            return db.LifeEvents.OrderByDescending(p => p.Id).Skip(PageNo * PageSize).Take(PageSize);
        }
        public async Task<IEnumerable<LifeEvent>> GetItemsAsync(int PageNo, int PageSize)
        {
            return await db.LifeEvents.OrderByDescending(p => p.Id).Skip(PageNo * PageSize).Take(PageSize).ToListAsync();
        }
        public IEnumerable<LifeEvent> GetPersonItems(int PersonId)
        {
            return db.LifeEvents.Where(i => i.PersonId == PersonId);
        }
        public LifeEvent GetItem(int id)
        {
            return db.LifeEvents.Include(le => le.Person).FirstOrDefault(le => le.Id == id);
        }
        public async Task<LifeEvent> GetItemAsync(int id)
        {
            return await db.LifeEvents.Include(le => le.Person).FirstOrDefaultAsync(le => le.Id == id);
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
        public async Task<int> SaveAsync()
        {
           return await db.SaveChangesAsync();
        }
        public int Count
        {
            get { return db.LifeEvents.Count(); }
        }
        public Task<int> CountAsync
        {
            get { return db.LifeEvents.CountAsync(); }
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
