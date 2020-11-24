using System.ComponentModel.DataAnnotations;

namespace RugbyManager.Models
{
    public class TransferPlayerRequest
    {
        [Required]
        public int? PlayerId { get; set; }

        [Required]
        public int? TeamId { get; set; }
    }
}
