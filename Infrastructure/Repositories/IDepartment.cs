using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Data.Model.Common;
using Infrastructure.Data.Model.Department;

namespace Infrastructure.Repositories
{
    public interface IDepartment
    {
        Task<IEnumerable<Department>> GetDepartment(); //GET THE DATA 

        Task<IEnumerable<Department>> GetDepartmentByID(int ID); //GET THE DATA WITH ID

        Task<Response> PostDepartment(Department department); //INSERT THE DATA

        Task<Response> UpdateDepartment(Department department); //UPDATE THE DATA

        Task<Response> DeleteDepartment(int id); //Delete Department

    }
}
