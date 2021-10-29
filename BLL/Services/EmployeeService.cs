using System;
using System.Collections.Generic;
using BLL.Constant;
using Core.Utilities;
using DAL.Repositories.HR;
using Entity.Models.HR;

namespace BLL.Services
{
    public class EmployeeService : IService<Employee>
    {
        private EmployeeRepository _repository;

        public EmployeeService(EmployeeRepository repository)
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
                    return new SuccessResult(Messages.EmployeeDeleted);
                }
                catch (Exception ex)
                {
                    return new ErrorDataResult<Employee>(ex.Message);
                }
            }
            else
                return new ErrorResult(Messages.BusinessEntityIDNotFound);
        }

        public IDataResult<Employee> Get(int entityId)
        {
            try
            {
                var result = _repository.Get(entityId);
                
                if(result != null)
                    return new SuccessDataResult<Employee>(result, Messages.EmployeeListed);
                else
                    return new ErrorDataResult<Employee>(Messages.EmployeeNotFound);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Employee>(ex.Message);
            }
        }

        public IResult Insert(Employee entity)
        {
            if(entity == null)
                return null;
            
            int id = _repository.GetLastId();
            if (id > 0)
            {
                entity.BusinessEntityID = id + 1;

                try
                {
                    _repository.Insert(entity);
                    return new SuccessResult(Messages.EmployeeAdded);
                }
                catch (Exception ex)
                {
                    return new ErrorDataResult<Employee>(ex.Message);
                }
            }
            else
                return new ErrorResult(Messages.LastIdDidntGet);
        }

        public IDataResult<IEnumerable<Employee>> List()
        {
            try
            {
                var result = _repository.List();

                if (result != null)
                    return new SuccessDataResult<IEnumerable<Employee>>(result,Messages.EmployeesListed);
                else
                    return new ErrorDataResult<IEnumerable<Employee>>(Messages.EmployeeNotFound);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Employee>>(ex.Message);
            }
        }

        public IResult Update(Employee entity)
        {
            if (entity == null)
                return null;
            else
            {
                try
                {
                    _repository.Update(entity);
                    return new SuccessResult(Messages.EmployeeUpdated);
                }
                catch (Exception ex)
                {
                    return new ErrorDataResult<Employee>(ex.Message);
                }
            }
        }
    }
}