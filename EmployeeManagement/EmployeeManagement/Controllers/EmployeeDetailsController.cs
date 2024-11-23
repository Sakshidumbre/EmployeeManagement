using EmployeeManagement.Interface;
using EmployeeManagement.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeDetails _employeeRepository;

        public EmployeeController(IEmployeeDetails employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("GetAllEmployeesDetails")]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                List<EmployeeDetails> employees = await _employeeRepository.GetAll();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while fetching employee details.", error = ex.Message });
            }
        }

        [HttpPost("AddNewEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeDetails employeeDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _employeeRepository.AddEmployee(employeeDetails);
                  return Ok(new { message = "Employee Details Added Successfully." });


            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while adding new employee in system.", error = ex.Message });
            }
        }

        [HttpPut("UpdateEmployeeData/{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeDetails employeeDetails)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
            

                var result = await _employeeRepository.UpdateEmployee(id, employeeDetails);
                return Ok(new { message = "Employee Details updatesd Successfully." });


            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while modifying employee details.", error = ex.Message });
            }


        }
        [HttpGet("EmployeeDetail/{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _employeeRepository.GetEmployeeById(id);

            if (employee == null)
            {
                return NotFound(new { message = "Employee not found." });
            }

            return Ok(employee);
        }

        [HttpDelete("RemoveEmployee/{id}")]
       
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                var result=await _employeeRepository.GetEmployeeById(id);

                if (result!=null)
                {
                    var res= await _employeeRepository.DeleteEmployee(id);
                }
                else
                {
                    return NotFound(new { message = "Employee not found." });
                }
                return Ok(new { message = "Employee is Removed from System." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the employee.", error = ex.Message });
            }
         }
    

    }
}
