using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acora.HR.UI.Data.Models
{
    public class Employee
    {
        [Key]
        [DisplayName("Employee ID")]
        public int EmployeeNumber { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }
        
        public string? Address { get; set; }
        
        public string? City { get; set; }

        public Guid DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
