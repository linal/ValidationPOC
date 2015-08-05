using System.ComponentModel.DataAnnotations;

namespace ValidationPoc.Domain
{
    public class PreviousName
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string Surname { get; set; }
    }
}