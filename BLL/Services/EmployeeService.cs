using DAL.Repositories.HR;
using Entity.Models.HR;
using System.Collections.Generic;

namespace BLL.Services
{
    public class EmployeeService : IService<Employee>
    {
        private EmployeeRepository _service;

        public EmployeeService(EmployeeRepository service)
        {
            _service = service;
        }
        public bool Delete(Employee entity)
        {
            throw new System.NotImplementedException();
        }

        public Employee Get(int entityId)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Employee entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Employee> List()
        {
            return _service.List();
        }

        public bool Update(Employee entity)
        {
            throw new System.NotImplementedException();
        }
    }
}