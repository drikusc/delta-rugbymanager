using System.Collections.Generic;

namespace RugbyManager.Models
{
    public class GetTeamsResponse : Response
    {
        public IEnumerable<Team> Teams { get; set; }
    }
}
