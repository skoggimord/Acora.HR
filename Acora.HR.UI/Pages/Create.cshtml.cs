#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Acora.HR.UI.Data;
using Acora.HR.UI.Data.Models;
using Acora.HR.UI.Validation;

namespace Acora.HR.UI.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Acora.HR.UI.Data.EmployeeContext _context;

        public CreateModel(Acora.HR.UI.Data.EmployeeContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var validator = new EmployeeValidator();

            var validationResult = validator.Validate(Employee);

            if (!ModelState.IsValid || !validationResult.IsValid)
            {
                // Pass validation failures from validator back to the page
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
