using Microsoft.Data.SqlClient;

namespace ADONetSakila
{
    internal class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public SqlDataReader ExecuteQuery(string query, SqlParameter[] parameters)
        {
            var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(query, connection);

            if(parameters != null)
                command.Parameters.AddRange(parameters);

            connection.Open();
            return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
        }
    }
}
