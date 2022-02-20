#nullable disable
using Acora.HR.UI.Data.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Acora.HR.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Acora.HR.UI.Data.EmployeeContext _context;

        public IndexModel(Acora.HR.UI.Data.EmployeeContext context)
        {
            _context = context;
        }

        public IList<Employee> Employee { get; set; }

        public async Task OnGetAsync(string sortOrder)
        {
            ViewData["NameSortParam"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["IdSortParam"] = sortOrder == "id" ? "id_desc" : "id";

            IQueryable<Employee> employees =  _context.Employees.Include(e => e.Department);

            switch (sortOrder)
            {
                case "name_desc":
                    employees = employees.OrderByDescending(s => s.Lastname);
                    break;

                case "id":
                    employees = employees.OrderBy(s => s.EmployeeNumber);
                    break;

                case "id_desc":
                    employees = employees.OrderByDescending(s => s.EmployeeNumber);
                    break;
                default:
                    employees = employees.OrderBy(s => s.Lastname);
                    break;
            }

            Employee = await employees.ToListAsync();
        }
    }
}
