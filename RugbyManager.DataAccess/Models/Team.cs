using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RugbyManager.DataAccess.Models
{
    [Table("Team")]
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public int? StadiumId { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public Stadium Stadium { get; set; }

        public List<Player> Players { get; } = new List<Player>();
    }
}