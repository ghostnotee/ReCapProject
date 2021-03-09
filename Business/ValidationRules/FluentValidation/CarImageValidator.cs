using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(i => i.CarId).NotNull().WithMessage("CarId cannot be empty!");
            RuleFor(i => i.CarId).NotEmpty().WithMessage("CarId cannot be empty!");
        }
    }
}