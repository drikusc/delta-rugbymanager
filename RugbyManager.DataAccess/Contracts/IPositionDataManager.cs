using RugbyManager.DataAccess.Models;
using System.Collections.Generic;

namespace RugbyManager.DataAccess.Contracts
{
    public interface IPositionDataManager
    {
        List<Position> Get(string code = null);
    }
}
