using System.Collections.Generic;
using DAL.Dapper;
using Entity.Models.HR;

namespace DAL.Repositories.HR
{
    public class EmployeeRepository : IRepository<Employee>
    {
        public void Delete(int entityId)
        {
            using(SQL<Employee> _sql = new SQL<Employee>())
            {
                const string query = @"Delete From HumanResources.Employee 
                                    Where BusinessEntityID = @BusinessEntityID";
                _sql.Execute(query, 
                new 
                {
                    BusinessEntityID = entityId
                });
            }
        }

        public Employee Get(int entityId)
        {
            using(SQL<Employee> _sql = new SQL<Employee>())
            {
                const string query = @"Select * From HumanResources.Employee 
                                    Where BusinessEntityID = @BusinessEntityID";

                return _sql.QueryFirstOrDefault(query, 
                new 
                {
                    BusinessEntityID = entityId
                });
            }
        }

        public void Insert(Employee entity)
        {
            using(SQL<Employee> _sql = new SQL<Employee>())
            {
                const string query =  @"
                    INSERT INTO [HumanResources].[Employee]
                        ([BusinessEntityID],
                        [NationalIDNumber],
                        [LoginID],
                        [JobTitle],
                        [BirthDate],
                        [MaritalStatus],
                        [Gender],
                        [HireDate],
                        [SalariedFlag],
                        [VacationHours],
                        [SickLeaveHours],
                        [CurrentFlag],
                        [ModifiedDate])
                    VALUES
                        (@BusinessEntityID,
                        @NationalIDNumber,
                        @LoginID,
                        @JobTitle,
                        @BirthDate,
                        @MaritalStatus,
                        @Gender,
                        @HireDate,
                        @SalariedFlag,
                        @VacationHours,
                        @SickLeaveHours,
                        @CurrentFlag,
                        GETDATE())";

                _sql.Execute(query, entity);
            }
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
            using(SQL<Employee> _sql = new SQL<Employee>())
            {
                const string query =  @"
                    UPDATE [HumanResources].[Employee]
                    SET [JobTitle] = @JobTitle
                        ,[BirthDate] = @BirthDate
                        ,[MaritalStatus] = @MaritalStatus
                        ,[Gender] = @Gender
                        ,[HireDate] = @HireDate
                        ,[SalariedFlag] = @SalariedFlag
                        ,[VacationHours] = @VacationHours
                        ,[SickLeaveHours] = @SickLeaveHours
                        ,[CurrentFlag] = @CurrentFlag
                        ,[ModifiedDate] = GETDATE()
                    WHERE BusinessEntityID=@BusinessEntityID";

                _sql.Execute(query, entity);
            }
        }

        public int GetLastId()
        {
            using(SQL<int> _sql = new SQL<int>())
            {
                const string query = @"Select BusinessEntityID From HumanResources.Employee Order By BusinessEntityID Desc";

                return _sql.ExecuteScalar(query);
            }
        }
    }
}