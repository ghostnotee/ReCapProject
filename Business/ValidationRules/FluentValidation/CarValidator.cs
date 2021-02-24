using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            // Rules for Car Entity
            RuleFor(c => c.CarModelName).NotEmpty();
            RuleFor(c => c.CarModelName).MinimumLength(2);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(150).When(c => c.ModelYear > new System.DateTime(2020, 1, 1));
            // RuleFor(c => c.CarModelName).Must(StartWithA).WithMessage("Araç model adı A harfi ile başlamalı");
        }

        // private bool StartWithA(string arg)
        // {
        //     return arg.StartsWith("A");
        // }
    }
}