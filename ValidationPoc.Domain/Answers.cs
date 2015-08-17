using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ValidationPoc.Enums;

namespace ValidationPoc.Domain
{
    public class Answers
    {
        public int Id { get; set; }

        [MaxLength(10)]
        public string Name { get; set; }

        public bool AnswerMoreQuestions { get; set; }

        public bool SeeMoreQuestions { get; set; }

        public int? Velocity { get; set; }

        public BasicColor? Color { get; set; }

        public OtherGreens? TypeOfGreen { get; set; }

        [MaxLength(200)]
        public string UltimateQuestion { get; set; }

        public IList<PreviousName> PreviousNames { get; set; }

        public DateTime? DateCompleted { get; set; }
    }
}