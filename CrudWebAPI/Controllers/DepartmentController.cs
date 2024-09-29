using Infrastructure.Data.Model.Common;
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
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartment()
        {
            var Department = await _department.GetDepartment();
            return Ok(Department);
        }

        [HttpGet("{DeptID}")]
        public async Task<ActionResult<IEnumerable<Department>>> GetDepartmentByID(int ID)
        {
            var Department = await _department.GetDepartmentByID(ID);
            return Ok(Department);
        }

        [HttpPost]
        public async Task<ActionResult<Response>> PostDepartment(Department department)
        {
            var Department = await _department.PostDepartment(department);
            return Ok(Department);
        }

        [HttpPut("{DeptID}")]
        public async Task<ActionResult<Response>> UpdateDepartment(int ID, Department department)
        {
             var Department = await _department.UpdateDepartment(department);
             return Ok(Department);
        }

        [HttpDelete]
        public async Task<ActionResult<Response>> DeleteDepartment(int id)
        {
            var DeleteDepartment = await _department.DeleteDepartment(id);
            return Ok(DeleteDepartment);
        }
    }
}
