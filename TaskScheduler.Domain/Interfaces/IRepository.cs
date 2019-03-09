using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskScheduler.Domain.Interfaces
{
    public interface IDocumentRepository<T>
    {
        Task<IQueryable<T>> List();
        Task<T> Get(string id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Remove(string id);
    }
}
