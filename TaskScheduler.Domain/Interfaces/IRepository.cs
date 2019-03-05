using System;
using System.Collections.Generic;
using System.Text;

namespace TaskScheduler.Domain.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T Update(T entity);
        bool Remove(string id);
    }
}
