using System;
using System.Collections.Generic;
using System.Linq;

namespace PersonDiary.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetItems(int PageNo,int PageSize);
        T GetItem(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
        int Count { get; }
    }
}
