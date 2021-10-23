using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(int entityId);
        T Get(int entityId);
        IEnumerable<T> List();
    }
}