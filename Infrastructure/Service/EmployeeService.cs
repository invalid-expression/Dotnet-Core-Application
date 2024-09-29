using Infrastructure.Data;
using Infrastructure.Data.Model.Common;
using Infrastructure.Data.Model.Employee;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class EmployeeService : IEmployeeService //implement interface
    {
        private readonly AppDbContext _context;//private  readonly variable

        public EmployeeService(AppDbContext context) //constructor
        {
            _context = context;  //db context injection
        }
        public Task<Response> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public async  Task<IEnumerable<Employee>> GetEmployee()
        {
            try
            {
                var activeEmployee = await _context.Employee
                                                     .Where(c => (bool)c.IsActive == true)
                                                     .ToListAsync(); //LINQ

                return activeEmployee;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Task<ServiceResult<Employee>> GetEmployee(int id)
        {
            throw new NotImplementedException();

        }

        public Task<Response> PostEmployee(Employee customer)
        {
            throw new NotImplementedException();
        }

        public Task<Response> PutEmployee(int id, Employee customers)
        {
            throw new NotImplementedException();
        }
    }
}
