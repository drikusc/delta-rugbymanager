using System.ComponentModel.DataAnnotations;

namespace RugbyManager.Models
{
    public class LinkTeamToStadiumRequest
    {
        [Required]
        public int? StadiumId { get; set; }

        [Required]
        public int? TeamId { get; set; }
    }
}
