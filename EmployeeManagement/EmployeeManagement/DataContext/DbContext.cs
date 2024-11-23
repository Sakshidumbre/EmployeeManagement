using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagement.DataContext
{
    public class DbContext
    {
        
            private readonly string _connectionString;

            public DbContext(IConfiguration configuration)
            {
                _connectionString = configuration.GetConnectionString("DefaultConnection");
            }

            public IDbConnection GetConnection()
            {
                return new SqlConnection(_connectionString);
            }
        

    }
}
