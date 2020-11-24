using RugbyManager.DataAccess.Contracts;
using RugbyManager.DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace RugbyManager.DataAccess.Manager
{
    public class PositionDataManager : IPositionDataManager
    {
        public List<Position> Get(string code = null)
        {
            using (var db = new DataAccess())
            {
                IQueryable<Position> positions = db.Positions;

                if (!string.IsNullOrWhiteSpace(code))
                    positions = positions.Where(x => x.Code == code);

                return positions.ToList();
            }
        }
    }
}
