using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace DAL.Dapper
{
    public class SQL<T>
    {
        private SqlConnection _connection;

        private const string cnn = @"Data Source=(local);Initial Catalog=AdventureWorks2017;User ID=sa;Password=123";

        public IEnumerable<T> Query(string query)
        {
            using(_connection = new SqlConnection(cnn))
            {
                var result = _connection.Query<T>(query);

                return result;
            }
        }

        public void Execute(string query)
        {
            using(_connection = new SqlConnection(cnn))
            {
                _connection.Execute(query);
            }
        }
    }
}