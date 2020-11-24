using RugbyManager.DataAccess.Models;
using System.Collections.Generic;

namespace RugbyManager.DataAccess.Contracts
{
    public interface IPlayerDataManager
    {
        List<Player> Get(int? id = null, string firstName = null, string lastName = null, decimal? height = null, string teamName = null, string positionCode = null);

        void Create(Player player);

        void Update(int playerId, int teamId);
    }
}
