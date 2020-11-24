using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RugbyManager.DataAccess.Models
{
    [Table("Stadium")]
    public class Stadium
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Suburb { get; set; }

        public string City { get; set; }

        public string Province { get; set; }

        public DateTime CreatedDate { get; set; }

        public Team Team { get; set; }
    }
}
