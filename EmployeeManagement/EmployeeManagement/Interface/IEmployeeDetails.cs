using EmployeeManagement.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Interface
{
    public interface IEmployeeDetails
    {
        Task<List<EmployeeDetails>> GetAll();
        Task<EmployeeDetails> AddEmployee(EmployeeDetails employeeDetails);
        Task<EmployeeDetails> UpdateEmployee(int id,EmployeeDetails employeeDetails);
        Task<EmployeeDetails> GetEmployeeById(int id);

        Task<bool> DeleteEmployee(int id);


    }
}
