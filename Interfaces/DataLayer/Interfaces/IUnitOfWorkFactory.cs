using System;
using System.Collections.Generic;
using System.Text;

namespace PersonDiary.Interfaces
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork CreateUnitOfWork();
    }
}
