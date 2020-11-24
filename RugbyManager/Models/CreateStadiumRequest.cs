using System.ComponentModel.DataAnnotations;

namespace RugbyManager.Models
{
    public class CreateStadiumRequest
    {
        [Required]
        public string Name { get; set; }

        public string Suburb { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }
    }
}
