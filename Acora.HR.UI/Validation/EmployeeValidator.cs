using Acora.HR.UI.Data.Models;
using Acora.HR.UI.Extensions;
using FluentValidation;

namespace Acora.HR.UI.Validation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty().WithMessage("Geoff is a stupid name");
            RuleFor(x => x.Lastname).NotEmpty();
            RuleFor(x => x.Department).NotNull();
            RuleFor(x => x.DateOfBirth.Age()).InclusiveBetween(18, 65).WithMessage($"Age must be between 18 and 65");
        }

    }
}
