using System;

namespace RugbyManager.Models
{
    public class Player
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public decimal Height { get; set; }

        public DateTime BirthDate { get; set; }

        public string Position { get; set; }

        public string Team { get; set; }
    }
}
