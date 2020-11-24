using System.ComponentModel.DataAnnotations;

namespace RugbyManager.Models
{
    public class CreatePlayerRequest
    {
        [Required]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public decimal? Height { get; set; }

        [Required]
        public string BirthDate { get; set; }

        [Required]
        public string PositionCode { get; set; }

        [Required]
        public int? TeamId { get; set; }
    }
}
