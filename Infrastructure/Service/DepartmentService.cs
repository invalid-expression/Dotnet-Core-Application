using Infrastructure.Data;
using Infrastructure.Data.Model.Common;
using Infrastructure.Data.Model.Department;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Infrastructure.Service
{
    public class DepartmentService : IDepartment
    {
        private readonly AppDbContext _context;
        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Department>> GetEmployee()
        {
            try
            {
                var Department = await _context.Department.ToListAsync();
                return Department;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public Task<ServiceResult<Department>> GetEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
