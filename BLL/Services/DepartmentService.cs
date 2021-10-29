using System;
using System.Collections.Generic;
using BLL.Constant;
using Core.Utilities;
using DAL.Repositories.HR;
using Entity.Models.HR;

namespace BLL.Services
{
    public class DepartmentService : IService<Department>
    {
        private DepartmentRepository _repository;

        public DepartmentService(DepartmentRepository repository)
        {
            _repository = repository;
        }

        public IResult Delete(int entityId)
        {
            if (entityId > 0)
            {
                try
                {
                    _repository.Delete(entityId);
                    return new SuccessResult(Messages.DepartmentDeleted);
                }
                catch (Exception ex)
                {
                    return new ErrorDataResult<Department>(ex.Message);
                }
            }
            else
                return new ErrorResult(Messages.DepartmentIDNotFound);
        }

        public IDataResult<Department> Get(int entityId)
        {
            try
            {
                var result = _repository.Get(entityId);

                if (result != null)
                    return new SuccessDataResult<Department>(result, Messages.DepartmentListed);
                else
                    return new ErrorDataResult<Department>(Messages.DepartmentNotFound);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Department>(ex.Message);
            }
        }

        public IResult Insert(Department entity)
        {
            if(entity == null)
                return null;
            else
            {
                try
                {
                    _repository.Insert(entity);
                    return new SuccessResult(Messages.DepartmentAdded);
                }
                catch (Exception ex)
                {
                    return new ErrorDataResult<Department>(ex.Message);
                }
            }
        }

        public IDataResult<IEnumerable<Department>> List()
        {
            try
            {
                var result = _repository.List();
                
                if (result != null)
                    return new SuccessDataResult<IEnumerable<Department>>(result,Messages.DepartmentsListed);
                else
                    return new ErrorDataResult<IEnumerable<Department>>(Messages.DepartmentNotFound);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Department>>(ex.Message);
            }
        }

        public IResult Update(Department entity)
        {
            if (entity == null)
                return null;
            else
            {
                try
                {
                    _repository.Update(entity);
                    return new SuccessResult(Messages.DepartmentUpdated);
                }
                catch (Exception ex)
                {
                    return new ErrorDataResult<Department>(ex.Message);
                }
            }
        }
    }
}