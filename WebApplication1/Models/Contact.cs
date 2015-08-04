using System.ComponentModel.DataAnnotations;
using System.Drawing;
using Foolproof;
using WebApplication1.Attributes;
using WebApplication1.Models.Validators;
using FluentValidation.Attributes;

namespace WebApplication1.Models
{
    [Validator(typeof(ContactValidator))]
    public class Contact
    {
        //[Required]
        //[MaxLength(10)]
        [Display(Name = "What is your Name?")]
        public string Name { get; set; }

        [Display(Name = "Do you want to answer more questions?")]
        public bool AnswerMoreQuestions { get; set; }

        [Display(Name = "Do you want to see more questions?")]
        public bool SeeMoreQuestions { get; set; }

        //[RequiredIfTrue("SeeMoreQuestions")]
        [Display(Name= "What is the velocity of an unladen swallow?")]
        public int? Velocity { get; set; }

        //[Required]
        [Display(Name = "What is your favourite colour?")]
        public BasicColor? Color { get; set; }

        //[RequiredIf("Color", Operator.EqualTo, BasicColor.Green)]
        [Display(Name = "What type of green is it?")]
        public OtherGreens? TypeOfGreen { get; set; }

        //[MultipleRequiredIf("TypeOfGreen", Operator.EqualTo, OtherGreens.DarkGreen)]
        //[MultipleRequiredIf("Velocity", Operator.GreaterThan, 41)]
        //[MultipleRequiredIf(
        //    new [] { "TypeOfGreen", "Velocity"},
        //    new[] { Operator.EqualTo, Operator.GreaterThan },
        //    new object[] { OtherGreens.DarkGreen, 41 })]
        [Display(Name = "What is the ultimate question?")]
        public string UltimateQuestion { get; set; }
    }

    public enum BasicColor
    {
        Red,
        Blue,
        Green,
        Yellow
    }

    public enum OtherGreens
    {
        LightGreen,
        DarkGreen
    }
}