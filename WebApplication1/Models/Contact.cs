using System.ComponentModel.DataAnnotations;
using System.Drawing;
using WebApplication1.Models.Validators;
using FluentValidation.Attributes;

namespace WebApplication1.Models
{
    [Validator(typeof(ContactValidator))]
    public class Contact
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