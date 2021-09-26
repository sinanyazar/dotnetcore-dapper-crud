using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetT(int entityId);
        List<T> List();
    }
}