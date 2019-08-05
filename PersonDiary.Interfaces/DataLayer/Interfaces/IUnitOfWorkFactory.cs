using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Interfaces
{
    /// <summary>
    /// Абстрактная фабрика для объектов UnitOfWork
    /// </summary>
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork();
    }
}
