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
        /// <summary>
        /// Выборка списка событий постранично
        /// </summary>
        /// <param name="PageNo"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public IEnumerable<LifeEvent> GetItems(int PageNo, int PageSize)
        {
            return db.LifeEvents.OrderByDescending(p => p.Id).Skip(PageNo * PageSize).Take(PageSize);
        }
        /// <summary>
        /// Выборка списка событий постранично асинхронно
        /// </summary>
        /// <param name="PageNo"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<LifeEvent>> GetItemsAsync(int PageNo, int PageSize)
        {
            return await db.LifeEvents.OrderByDescending(p => p.Id).Skip(PageNo * PageSize).Take(PageSize).ToListAsync();
        }
        /// <summary>
        /// Выборка списка событий по персоне
        /// </summary>
        /// <param name="PageNo"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public IEnumerable<LifeEvent> GetPersonItems(int PersonId)
        {
            return db.LifeEvents.Where(i => i.PersonId == PersonId);
        }
        /// <summary>
        /// Выборка события по id
        /// </summary>
        /// <param name="PageNo"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public LifeEvent GetItem(int id)
        {
            return db.LifeEvents.Include(le => le.Person).FirstOrDefault(le => le.Id == id);
        }
        /// <summary>
        /// Выборка события по id асинхронно
        /// </summary>
        /// <param name="PageNo"></param>
        /// <param name="PageSize"></param>
        /// <returns></returns>
        public async Task<LifeEvent> GetItemAsync(int id)
        {
            return await db.LifeEvents.Include(le => le.Person).FirstOrDefaultAsync(le => le.Id == id);
        }
        /// <summary>
        /// создание события
        /// </summary>
        /// <param name="item"></param>
        public void Create(LifeEvent item)
        {
            db.LifeEvents.Add(item);
        }
        /// <summary>
        /// обновление события
        /// </summary>
        /// <param name="item"></param>
        public void Update(LifeEvent item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        /// <summary>
        /// удаление события
        /// </summary>
        /// <param name="item"></param>
        public void Delete(int id)
        {
            LifeEvent LifeEvent = db.LifeEvents.Find(id);
            if (LifeEvent != null)
                db.LifeEvents.Remove(LifeEvent);
        }
        /// <summary>
        /// Сохранение изменений
        /// </summary>
        public void Save()
        {
            db.SaveChanges();
        }
        /// <summary>
        /// Сохранение изменений асинхронно
        /// </summary>
        public async Task<int> SaveAsync()
        {
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// Выборка
        /// </summary>
        public int Count
        {
            get { return db.LifeEvents.Count(); }
        }
        public Task<int> CountAsync()
        {
            return db.LifeEvents.CountAsync();
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
