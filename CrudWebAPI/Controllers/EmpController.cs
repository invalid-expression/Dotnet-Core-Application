using Infrastructure.Data.Model.Employee;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;//interface's referance variable

        public EmpController(IEmployeeService empService) //constrotur injection
        {
            _employeeService = empService;
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            try
            {
                var employee = await _employeeService.GetEmployee();

                if (employee == null)
                {
                    return NotFound();
                }

                return Ok(employee);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, "Internal server error");
                //test commit 
            }
        }
    }
}
