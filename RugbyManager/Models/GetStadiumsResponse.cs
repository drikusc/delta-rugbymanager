using System.Collections.Generic;

namespace RugbyManager.Models
{
    public class GetStadiumsResponse : Response
    {
        public IEnumerable<Stadium> Stadiums { get; set; }
    }
}