using System;
using System.Collections.Generic;
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

        public IResult Delete(Employee entity)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<Employee> Get(int entityId)
        {
            try
            {
                return new SuccessDataResult<Employee>(_service.Get(entityId));
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<Employee>(ex.Message);
            }
        }

        public IResult Insert(Employee entity)
        {
            throw new System.NotImplementedException();
        }

        public IDataResult<IEnumerable<Employee>> List()
        {
            try
            {
                return new SuccessDataResult<IEnumerable<Employee>>(_service.List());
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<IEnumerable<Employee>>(ex.Message);
            }
        }

        public IResult Update(Employee entity)
        {
            throw new System.NotImplementedException();
        }
    }
}