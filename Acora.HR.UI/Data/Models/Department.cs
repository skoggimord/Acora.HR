using System.ComponentModel.DataAnnotations;

namespace Acora.HR.UI.Data.Models
{
    public class Department
    {
        [Key]
        public Guid Id { get; set; } 

        [MaxLength(50)]
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
    }
}
