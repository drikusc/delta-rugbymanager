using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RugbyManager.DataAccess.Models
{
    [Table("Player")]
    public class Player
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public decimal Height { get; set; }

        public DateTime BirthDate { get; set; }

        public int PrimaryPositionId { get; set; }

        public int TeamId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("PrimaryPositionId")]
        public Position Position { get; set; }

        public Team Team { get; set; }
    }
}
