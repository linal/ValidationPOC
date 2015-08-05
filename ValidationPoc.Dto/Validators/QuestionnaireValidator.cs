using FluentValidation;
using ValidationPoc.Enums;

namespace ValidationPoc.Dto.Validators
{
    public class QuestionnaireValidator : AbstractValidator<Questionnaire>
    {
        public QuestionnaireValidator()
        {
            RuleFor(x => x.Name).Length(0, 10).NotEmpty();
            RuleFor(x => x.Velocity).NotEmpty().When(x => x.SeeMoreQuestions);

            RuleFor(x => x.Color).NotEmpty();
            RuleFor(x => x.TypeOfGreen).NotEmpty().When(x => x.Color == BasicColor.Green);
            RuleFor(x => x.UltimateQuestion)
                    .Length(0, 200)
                    .NotEmpty()
                    .When(x => x.TypeOfGreen == OtherGreens.DarkGreen && x.Velocity > 41);
        }
    }
}