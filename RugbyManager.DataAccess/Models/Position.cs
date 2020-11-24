using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RugbyManager.DataAccess.Models
{
    [Table("Position")]
    public class Position
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public List<Player> Players { get; set; }
    }
}