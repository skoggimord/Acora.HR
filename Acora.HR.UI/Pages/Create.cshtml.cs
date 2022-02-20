#nullable disable
using Acora.HR.UI.Data.Models;
using Acora.HR.UI.Validation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Employee Employee { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            var validator = new EmployeeValidator();

            var results =  await validator.ValidateAsync(Employee);

            if (!results.IsValid)
            {
                results.AddToModelState(ModelState, null);
                ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
                return Page();
            }

            _context.Employees.Add(Employee);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
