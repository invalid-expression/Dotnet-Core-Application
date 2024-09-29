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
        Task<IEnumerable<Department>> GetEmployee();

        Task<ServiceResult<Department>> GetEmployee(int id);



    }
}
