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

        public IList<Employee> Employee { get;set; }

        public async Task OnGetAsync()
        {
            Employee = await _context.Employees
                .Include(e => e.Department).ToListAsync();
        }
    }
}
