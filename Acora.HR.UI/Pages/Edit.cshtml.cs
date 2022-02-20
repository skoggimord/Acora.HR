#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Acora.HR.UI.Data;
using Acora.HR.UI.Data.Models;
using Acora.HR.UI.Validation;
using FluentValidation.AspNetCore;

namespace Acora.HR.UI.Pages
{
    public class EditModel : PageModel
    {
        private readonly Acora.HR.UI.Data.EmployeeContext _context;

        public EditModel(Acora.HR.UI.Data.EmployeeContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {


            var validator = new EmployeeValidator();

            var results = await validator.ValidateAsync(Employee);

            if (!results.IsValid)
            {
                results.AddToModelState(ModelState, null);
                ViewData["DepartmentId"] = new SelectList(_context.Departments, "Id", "Name");
                return Page();
            }
            
            _context.Attach(Employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(Employee.EmployeeNumber))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeNumber == id);
        }
    }
}
