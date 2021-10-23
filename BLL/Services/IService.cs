using System.Collections.Generic;
using Core.Utilities;

namespace BLL.Services
{
    public interface IService<T>
    {
        IResult Insert(T entity);
        IResult Update(T entity);
        IResult Delete(int entityId);
        IDataResult<T> Get(int entityId);
        IDataResult<IEnumerable<T>> List();
    }
}