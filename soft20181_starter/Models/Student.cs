using System.ComponentModel.DataAnnotations;

namespace soft20181_starter.Models
{
	public class Student
	{
        public int Id { get; set; }

        [Required]
        public string NNumber { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
