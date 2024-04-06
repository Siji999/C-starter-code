using System.ComponentModel.DataAnnotations;

namespace soft20181_starter.Models
{
    public class Events
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Image { get; set; }
    }
}
