using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace DAL.Dapper
{
    public class SQL<T> : IDisposable
    {
        private SqlConnection _connection;

        private const string cnn = @"Server=DESKTOP-LC4GVGJ\SQLEXPRESS;Database=AdventureWorks2017;Trusted_Connection=true";

        public IEnumerable<T> Query(string query)
        {
            using(_connection = new SqlConnection(cnn))
            {
                var result = _connection.Query<T>(query);

                return result;
            }
        }

        public T QueryFirst(string query, int id)
        {
            using(_connection = new SqlConnection(cnn))
            {
                var result = _connection.QueryFirst<T>(query, new { BusinessEntityID = id });

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

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}