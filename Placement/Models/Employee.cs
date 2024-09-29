using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Placement.Areas.Identity.Pages.Account;

namespace Placement.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }

        [Column(TypeName = "Varchar(50)")]
        [Required]
        public string? Name { get; set; }

        [Column(TypeName = "Varchar(50)")]
        [Required]
        public string? Email { get; set; }

        [Column(TypeName = "Varchar(20)")]
        [Required]
        public string? Contact { get; set; }

        [Column(TypeName = "Varchar(100)")]
        [Required]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Please choose profile image")]
        [Display(Name = "Profile Picture")]
        [NotMapped]
        public IFormFile? ProfileImage { get; set; }
        public string? ProfilePicture { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }



    }
}
