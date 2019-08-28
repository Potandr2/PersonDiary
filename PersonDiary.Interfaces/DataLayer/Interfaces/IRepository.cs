using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonDiary.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IDisposable
    {
        //постраничное чтение данных из репозитория
        IEnumerable<T> GetItems(int PageNo, int PageSize);
        Task<IEnumerable<T>> GetItemsAsync(int PageNo, int PageSize);
        T GetItem(int id);
        Task<T> GetItemAsync(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
        Task<int> SaveAsync();
        //Количество данных в репозитории, для постраничного вывода.
        int Count { get; }
        Task<int> CountAsync();

    }
}
