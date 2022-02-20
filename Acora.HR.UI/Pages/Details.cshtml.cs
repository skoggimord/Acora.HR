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
    public class DetailsModel : PageModel
    {
        private readonly Acora.HR.UI.Data.EmployeeContext _context;

        public DetailsModel(Acora.HR.UI.Data.EmployeeContext context)
        {
            _context = context;
        }

        public Employee Employee { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employee = await _context.Employees
                .Include(e => e.Department).FirstOrDefaultAsync(m => m.EmployeeNumber == id);

            if (Employee == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
