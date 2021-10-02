using System.Collections.Generic;

namespace BLL.Services
{
    public interface IService<T>
    {
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        T Get(int entityId);
        IEnumerable<T> List();
    }
}