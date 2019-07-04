using Microsoft.EntityFrameworkCore;
using PersonDiary.Contexts;
using PersonDiary.Entities;
using PersonDiary.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonDiary.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private SqlContext db;
        public PersonRepository(SqlContext db)
        {
            this.db = db;
        }
       
        public IEnumerable<Person> GetItems()
        {
            return db.Persons;
        }
        public Person GetItem(int id)
        {
            return db.Persons.Include(p => p.LifeEvents).FirstOrDefault(p => p.Id == id);
        }
        public void Create(Person item)
        {
            db.Persons.Add(item);
        }
        public void Update(Person item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
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
