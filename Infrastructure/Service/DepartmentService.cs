using Infrastructure.Data;
using Infrastructure.Data.Model.Common;
using Infrastructure.Data.Model.Department;
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
    public class DepartmentService : IDepartment
    {
        private readonly AppDbContext _context;
        public DepartmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetDepartment()
        {
            var Data = await _context.Department.ToListAsync();
            return Data;
        }

        public async Task<IEnumerable<Department>> GetDepartmentByID(int ID)
        {
            var Data = await _context.Department.Where(x => x.DeptID == ID).ToListAsync();
            return Data;
        }

        public async Task<Response> PostDepartment(Department department)
        {
            var Data = await _context.Department.AddAsync(department);
            await _context.SaveChangesAsync();

            return new Response
            {
                StatusCode = 200,
                Message = "Succefully Added",
                Result = true
            };
        }

        public async Task<Response> UpdateDepartment(Department department)
        {
            try
            {
                var Data = _context.Department.Update(department);
                await _context.SaveChangesAsync();

                return new Response { StatusCode = 200, Message = "Succesfully Updated", Result = true };
            }
            catch (Exception ex)
            {
                return new Response { StatusCode = 417, Message = $"{ex}", Result = false };
            }
        }

        public async Task<Response> DeleteDepartment(int id)
        {
            var department = await _context.Department.FindAsync(id);
            if (department == null)
            {
                new Response { StatusCode = 501, Message = "Data not found", Result = false };
            }
            try
            {
                _context.Department.Remove(department);
                await _context.SaveChangesAsync();
                return new Response { StatusCode = 200, Message = "Removed", Result = true };
            }
            catch(Exception ex)
            {
                return new Response
                {
                    StatusCode = 404,
                    Message = $"{ex}",
                    Result = false
                };
            }
            
        }

        public async Task<IEnumerable<Department>> DisableDepartment(int ID)
        {
            var Data = await _context.Department.Where(x => x.DeptID == ID).ToListAsync();
            return Data;
        }
    }
}
