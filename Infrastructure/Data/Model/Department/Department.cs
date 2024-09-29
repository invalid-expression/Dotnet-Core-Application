using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Model.Department
{
    public class Department
    {
        [Key]
        public int? DeptID { get; set; }
        public string? DepartmentName { get; set; }
        public int? EmployeeNumber { get; set; }
    }
}
