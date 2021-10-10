using System.Collections.Generic;
using DAL.Dapper;
using Entity.Models.HR;

namespace DAL.Repositories.HR
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public void Delete(Employee entity)
        {
            throw new System.NotImplementedException();
        }

        public Employee Get(int entityId)
        {
            using(SQL<Employee> _sql = new SQL<Employee>())
            {
                const string query = @"Select * From HumanResources.Employee 
                                    Where BusinessEntityID = @BusinessEntityID";

                return _sql.QueryFirst(query, entityId);
            }
        }

        public void Insert(Employee entity)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Employee> List()
        {
            using(SQL<Employee> _sql = new SQL<Employee>())
            {
                const string query = @"Select * From HumanResources.Employee";

                return _sql.Query(query);
            }
        }

        public void Update(Employee entity)
        {
            throw new System.NotImplementedException();
        }
    }
}