using ValidationPoc.Dto;

namespace ValidationPoc.Command
{
    public class UpdateAnswersCommand : ICommand
    {
        public int Id { get; set; }

        public Questionnaire Questionnaire { get; set; }
    }
}