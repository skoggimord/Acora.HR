#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Acora.HR.UI.Data;
using Acora.HR.UI.Data.Models;

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
