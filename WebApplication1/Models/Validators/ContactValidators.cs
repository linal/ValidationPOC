using FluentValidation;

namespace WebApplication1.Models.Validators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name).Length(10).NotEmpty();
            RuleFor(x => x.Velocity).NotEmpty().When(x => x.SeeMoreQuestions);


            RuleFor(x => x.Color).NotEmpty();
            RuleFor(x => x.TypeOfGreen).NotEmpty().When(x => x.Color == BasicColor.Green);
            RuleFor(x => x.UltimateQuestion).NotEmpty().When(x => x.TypeOfGreen == OtherGreens.DarkGreen && x.Velocity > 41);
        }
    }
}