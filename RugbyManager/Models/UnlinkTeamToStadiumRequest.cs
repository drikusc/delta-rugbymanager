using System.ComponentModel.DataAnnotations;

namespace RugbyManager.Models
{
    public class UnlinkTeamToStadiumRequest
    {
        [Required]
        public int? TeamId { get; set; }
    }
}
