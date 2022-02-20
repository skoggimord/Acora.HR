using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Acora.HR.UI.Data.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeNumber { get; set; }

        public DateTime DateOfBirth { get; set; }
        
        public string Firstname { get; set; }

        public string Lastname { get; set; }
        
        public string Address { get; set; }
        
        public string City { get; set; }

        public Guid DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
