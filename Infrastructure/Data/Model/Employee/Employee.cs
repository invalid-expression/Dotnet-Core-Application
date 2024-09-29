using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Model.Employee
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }


        public string? Name { get; set; }


        public string? Email { get; set; }


        public string? Contact { get; set; }


        public string? Address { get; set; }


        //public IFormFile? ProfileImage { get; set; }
        public string? ProfilePicture { get; set; }
        public bool IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
