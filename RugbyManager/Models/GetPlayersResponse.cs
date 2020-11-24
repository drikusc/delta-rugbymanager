using System.Collections.Generic;

namespace RugbyManager.Models
{
    public class GetPlayersResponse : Response
    {
        public IEnumerable<Player> Players { get; set; }
    }
}
