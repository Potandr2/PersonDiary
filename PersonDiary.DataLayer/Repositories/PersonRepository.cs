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
    //Класс-реализация репозитория персон для MS SQL и EF Core
    public class PersonRepository : IPersonRepository
    {
        private SqlContext db;
        public PersonRepository(SqlContext db)
        {
            this.db = db;
        }
        public IEnumerable<Person> GetItems(int PageNo, int PageSize)
        {
            return db.Persons.OrderByDescending(p => p.Id).Skip(PageNo * PageSize).Take(PageSize);
        }
        public async Task<IEnumerable<Person>> GetItemsAsync(int PageNo, int PageSize)
        {
            return await db.Persons.OrderByDescending(p => p.Id).Skip(PageNo * PageSize).Take(PageSize).ToListAsync();
        }
        public Person GetItem(int id)
        {
            return db.Persons.Include(p => p.LifeEvents).FirstOrDefault(p => p.Id == id);
        }
        public async Task<Person> GetItemAsync(int id)
        {
            return await db.Persons.Include(p => p.LifeEvents).FirstOrDefaultAsync(p => p.Id == id);
        }
        public void Create(Person item)
        {
            db.Persons.Add(item);
        }
        public void Update(Person item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        /// <summary>
        /// Удаление персоны, удаление дочерних коллекций сделает EFCore, т.к. связь между сущностями жёсткая (not null)
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            Person Person = db.Persons.Find(id);
            if (Person != null)
                db.Persons.Remove(Person);
        }
        public void Save()
        {
            db.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await db.SaveChangesAsync();
        }
        public int Count{
            get {return db.Persons.Count(); }
        }
        public async Task<int> CountAsync()
        {
            return await db.Persons.CountAsync();
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
