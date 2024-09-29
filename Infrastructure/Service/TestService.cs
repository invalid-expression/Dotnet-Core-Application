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
    public class TestService : IEmployeeService//implement
    {
        private readonly AppDbContext _context;//private  readonly variable
        public TestService(AppDbContext context)//dbsontext register
        {
            _context = context;

        }

        public Task<Response> DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Employee>> GetEmployee()
        {
            try
            {
                var test = await _context.Employee.ToListAsync();
                return test;
            }
            catch (Exception)
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
