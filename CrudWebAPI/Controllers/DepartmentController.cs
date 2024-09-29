using Infrastructure.Data.Model.Department;
using Infrastructure.Repositories;
using Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _department;
        public DepartmentController(IDepartment department)
        {
            _department = department;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> GetEmployee()
        {
            var Department = await _department.GetEmployee();
            return Ok(Department);
        }
    }
}
