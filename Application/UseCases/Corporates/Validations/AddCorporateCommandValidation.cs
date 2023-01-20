using Application.UseCases.Corporates.Commands;
using FluentValidation;

namespace Application.UseCases.Corporates.Validations
{
    public class AddCorporateCommandValidation : AbstractValidator<AddCorporateCommand>
    {
        public AddCorporateCommandValidation()
        {
            RuleFor(x => x.CorporateName).NotEmpty()
                .WithMessage("Corporate name can not be empty");
            RuleFor(x => x.Number).GreaterThan(5)
                .WithMessage("number should more than 5");
        }
    }
}
