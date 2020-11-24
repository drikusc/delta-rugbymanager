using System.Collections.Generic;

namespace RugbyManager.Models
{
    public class GetPositionsResponse : Response
    {
        public IEnumerable<Position> Positions { get; set; }
    }
}
