using ValidationPoc.Dto;

namespace ValidationPoc.Command
{
    public class CreateAnswersCommand : ICommand
    {
        public Questionnaire Questionnaire { get; set; }
    }
}