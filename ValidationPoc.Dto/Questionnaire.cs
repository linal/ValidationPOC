using System.Collections.Generic;
using FluentValidation.Attributes;
using ValidationPoc.Dto.Validators;
using ValidationPoc.Enums;

namespace ValidationPoc.Dto
{
    [Validator(typeof(QuestionnaireValidator))]
    public class Questionnaire
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool AnswerMoreQuestions { get; set; }

        public bool SeeMoreQuestions { get; set; }

        public int? Velocity { get; set; }

        public BasicColor? Color { get; set; }

        public OtherGreens? TypeOfGreen { get; set; }

        public string UltimateQuestion { get; set; }

        public IList<PreviousName> PreviousNames { get; set; }
    }
}