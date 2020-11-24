using System;

namespace RugbyManager.Models
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public string StadiumName { get; set; }

        public int TotalPlayers { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
