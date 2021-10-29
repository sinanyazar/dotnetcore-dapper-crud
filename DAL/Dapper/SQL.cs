using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;

namespace DAL.Dapper
{
    public class SQL<T> : IDisposable
    {
        private SqlConnection _connection;

        private const string cnn = @"Server=DESKTOP-LC4GVGJ\SQLEXPRESS;Database=AdventureWorks2017;Trusted_Connection=true";

        public IEnumerable<T> Query(string query, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using(_connection = new SqlConnection(cnn))
            {
                var result = _connection.Query<T>(query);

                return result;
            }
        }

        public T QueryFirstOrDefault(string query, object param = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            using(_connection = new SqlConnection(cnn))
            {
                var result = _connection.QueryFirstOrDefault<T>(query, param, commandTimeout: commandTimeout, commandType: commandType);

                return result;
            }
        }

        public void Execute(string query, object param = null)
        {
            using(_connection = new SqlConnection(cnn))
            {
                _connection.Execute(query, param);
            }
        }

        public T ExecuteScalar(string query, object param = null)
        {
            using(_connection = new SqlConnection(cnn))
            {
                var result = _connection.ExecuteScalar<T>(query);

                return result;
            }
        }

        public void Dispose()
        {
            _connection.Dispose();
        }
    }
}