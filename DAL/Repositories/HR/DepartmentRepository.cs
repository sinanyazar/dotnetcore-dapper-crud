using System.Collections.Generic;
using DAL.Dapper;
using Entity.Models.HR;

namespace DAL.Repositories.HR
{
    public class DepartmentRepository : IRepository<Department>
    {
        public void Delete(int entityId)
        {
            using(SQL<Department> _sql = new SQL<Department>())
            {
                const string query = @"Delete From HumanResources.Department
                                    Where DepartmentID=@DepartmentID";
                _sql.Execute(query,
                new 
                {
                    DepartmentID = entityId
                });
            }
        }

        public Department Get(int entityId)
        {
            using(SQL<Department> _sql = new SQL<Department>())
            {
                const string query = @"Select * From HumanResources.Department
                                    Where DepartmentID=@DepartmentID";
                                    
                return _sql.QueryFirstOrDefault(query,
                new 
                {
                    DepartmentID = entityId
                });
            }
        }

        public void Insert(Department entity)
        {
            using(SQL<Employee> _sql = new SQL<Employee>())
            {
                const string query =  @"
                    INSERT INTO HumanResources.Department
                        (Name,
                        GroupName,
                        ModifiedDate)
                    VALUES
                        (@Name,
                        @GroupName,
                        GETDATE())";

                _sql.Execute(query, entity);
            }
        }

        public IEnumerable<Department> List()
        {
            using(SQL<Department> _sql = new SQL<Department>())
            {
                const string query = @"Select * From HumanResources.Department";

                return _sql.Query(query);
            }
        }

        public void Update(Department entity)
        {
            using(SQL<Employee> _sql = new SQL<Employee>())
            {
                const string query =  @"
                    UPDATE [HumanResources].[Department]
                    SET [Name] = @Name
                        ,[GroupName] = @GroupName
                        ,[ModifiedDate] = GETDATE()
                    WHERE DepartmentID=@DepartmentID";

                _sql.Execute(query, entity);
            }
        }
    }
}