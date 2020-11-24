using System.ComponentModel.DataAnnotations;

namespace RugbyManager.Models
{
    public class CreateTeamRequest
    {
        [Required]
        public string Name { get; set; }

        public string Suburb { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Province { get; set; }

        public int? StadiumId { get; set; }
    }
}
