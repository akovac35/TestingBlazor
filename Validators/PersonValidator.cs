using FluentValidation;
using TestingBlazor.Models;

namespace TestingBlazor.Validators
{
    /// <summary>
    /// See also <see cref="ValidatorOptions.Global.CascadeMode"/> and <see cref="CascadeMode.Stop"/>.
    /// </summary>
    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(person => person.FirstName).NotNull().NotEmpty().WithName("Ime");
            RuleFor(person => person.LastName).NotNull().NotEmpty().WithName("Priimek").Must(BeMax25CharactersLong).WithMessage("Priimek ne sme biti daljši od 25 znakov.");
            RuleFor(person => person.Age).GreaterThanOrEqualTo(18).WithName("Starost");
        }

        public bool BeMax25CharactersLong(string lastName)
        {
            if (lastName.Length > 25) return false;
            return true;
        }
    }
}
