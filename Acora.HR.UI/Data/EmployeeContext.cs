using Acora.HR.UI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Acora.HR.UI.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options) : base(options)
        {

        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(b =>
            {
                b.HasKey(e => e.EmployeeNumber);
                b.Property(e => e.EmployeeNumber).ValueGeneratedOnAdd();
            });

            var HRDepartment = new Department() { Id = Guid.NewGuid(), Name = "HR" };
            var ITDepartment = new Department() { Id = Guid.NewGuid(), Name = "IT" };
            var QADepartment = new Department() { Id = Guid.NewGuid(), Name = "QA" };

            modelBuilder.Entity<Department>().HasData(HRDepartment);
            modelBuilder.Entity<Department>().HasData(ITDepartment);
            modelBuilder.Entity<Department>().HasData(QADepartment);

            var testEmployeeA = new Employee()
            {
                EmployeeNumber = 1,
                Firstname = "TestA",
                Lastname = "TestALastname",
                Address = "1 Top Street",
                City = "Manchester",
                DateOfBirth = new DateTime(1980, 1, 1),
                DepartmentId = HRDepartment.Id
            };

            var testEmployeeB = new Employee()
            {
                EmployeeNumber = 2,
                Firstname = "TestB",
                Lastname = "TestBLastname",
                Address = "1 Left Street",
                City = "Liverpool",
                DateOfBirth = new DateTime(1989, 11, 4),
                DepartmentId = HRDepartment.Id
            };

            var testEmployeeC = new Employee()
            {
                EmployeeNumber = 3,
                Firstname = "TestC",
                Lastname = "TestCLastname",
                Address = "1 Bottom Street",
                City = "London",
                DateOfBirth = new DateTime(1972, 8, 10),
                DepartmentId = HRDepartment.Id
            };

            modelBuilder.Entity<Employee>().HasData(testEmployeeA);
            modelBuilder.Entity<Employee>().HasData(testEmployeeB);
            modelBuilder.Entity<Employee>().HasData(testEmployeeC);
        }
    }
}
