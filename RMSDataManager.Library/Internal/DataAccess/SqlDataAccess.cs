using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace RMSDataManager.Library.Internal.DataAccess
{
    public class SqlDataAccess
    {
        private string GetConnectionString(string Name)
        {
            return ConfigurationManager.ConnectionStrings[Name].ConnectionString;
        }

        public List<T> LoadData<T, U>(string storedProceduer, U parameters, string ConnectionStringName)
        {
            string connectionString = GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(storedProceduer, parameters, commandType: CommandType.StoredProcedure).ToList();
                return rows;
            }
        }

        public void SaveDate<T>(string storedProceduer, T parameters, string ConnectionStringName)
        {
            string connectionString = GetConnectionString(ConnectionStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                connection.Execute(storedProceduer, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
