using FluentValidation.Attributes;
using ValidationPoc.Models.Validators;

namespace ValidationPoc.Models
{
    [Validator(typeof(QuestionnaireValidator))]
    public class Questionnaire
    {
        public string Name { get; set; }

        public bool AnswerMoreQuestions { get; set; }

        public bool SeeMoreQuestions { get; set; }

        public int? Velocity { get; set; }

        public BasicColor? Color { get; set; }

        public OtherGreens? TypeOfGreen { get; set; }

        public string UltimateQuestion { get; set; }
    }
}