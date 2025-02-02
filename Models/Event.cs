using System.ComponentModel.DataAnnotations;

namespace EventEasePro.Models
{
    public class Event
    {
        public int Id { get; set; }  // Primary key
        [Required(ErrorMessage ="Name is Required!")]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }
    }
}
