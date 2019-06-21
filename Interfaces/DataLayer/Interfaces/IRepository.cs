using System;
using System.Collections.Generic;

namespace PersonDiary.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetItems();
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}
