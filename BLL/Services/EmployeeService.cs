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
        private EmployeeRepository _service;

        public EmployeeService(EmployeeRepository service)
        {
            _service = service;
        }

        public IResult Delete(int entityId)
        {
            if (entityId > 0)
            {
                try
                {
                    _service.Delete(entityId);
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
                return new SuccessDataResult<Employee>(_service.Get(entityId), Messages.EmployeeListed);
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
            
            int id = _service.GetLastId();
            if (id > 0)
            {
                entity.BusinessEntityID = id + 1;

                try
                {
                    _service.Insert(entity);
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
                return new SuccessDataResult<IEnumerable<Employee>>(_service.List(),Messages.EmployeesListed);
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
            
            try
            {
                _service.Update(entity);
                return new SuccessResult(Messages.EmployeeUpdated);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Employee>(ex.Message);
            }
        }
    }
}