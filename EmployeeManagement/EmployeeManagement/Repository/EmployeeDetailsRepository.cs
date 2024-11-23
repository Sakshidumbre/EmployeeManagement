using System.Data;
using System.Data.SqlClient;
using Dapper;
using EmployeeManagement.DataContext;
using EmployeeManagement.Interface;
using EmployeeManagement.Model;
using Microsoft.AspNetCore.Mvc;
using static EmployeeManagement.DataContext.DbContext;

namespace EmployeeManagement.Repository
{
    public class EmployeeDetailsRepository : IEmployeeDetails
    {
        private readonly DbContext _dbContext;

        public EmployeeDetailsRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EmployeeDetails>> GetAll()
        {
            using (var connection = _dbContext.GetConnection())
            {
                var result = await connection.QueryAsync<EmployeeDetails>(
                            "GetEmployeeDetails",
                            commandType: CommandType.StoredProcedure
                        ); return result.ToList();
            }
        }

        public async Task<EmployeeDetails> AddEmployee(EmployeeDetails employeeDetails)
        {
            using (var connection = _dbContext.GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", employeeDetails.Name);
                parameters.Add("@Email", employeeDetails.Email);
                parameters.Add("@PhoneNumber", employeeDetails.PhoneNumber);
                parameters.Add("@IsDeleted", false);

                await connection.ExecuteAsync("AddEmployeeDetails", parameters, commandType: CommandType.StoredProcedure);

              
                return employeeDetails;
            }
        }
        public async Task<EmployeeDetails> UpdateEmployee(int id, EmployeeDetails employeeDetails)
        {
            using (var connection = _dbContext.GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Name", employeeDetails.Name);
                parameters.Add("@Email", employeeDetails.Email);
                parameters.Add("@PhoneNumber", employeeDetails.PhoneNumber);
                parameters.Add("@Id", id);

                var result = await connection.ExecuteScalarAsync<int>(
                    "UpdateEmployeeDetails",
                    parameters,
                    commandType: CommandType.StoredProcedure
                );

                if (result <= 0)
                {
                    throw new Exception($"No employee found with ID {id} or the employee is deleted.");
                }

                return employeeDetails;
            }
        }




        public async Task<EmployeeDetails> GetEmployeeById(int id)
        {
            using (var connection = _dbContext.GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                var result = await connection.QuerySingleOrDefaultAsync<EmployeeDetails>(
                    "GetEmployeeById", parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            using (var connection = _dbContext.GetConnection())
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

              var result= await connection.ExecuteAsync("DeleteEmployee", parameters, commandType: CommandType.StoredProcedure);
                return result > 0;

            }
        }


    }
}
