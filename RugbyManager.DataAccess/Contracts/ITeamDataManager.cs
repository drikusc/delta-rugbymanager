using RugbyManager.DataAccess.Models;
using System.Collections.Generic;

namespace RugbyManager.DataAccess.Contracts
{
    public interface ITeamDataManager
    {
        List<Team> Get(int? id = null, string name = null);

        public void Create(Team team);

        public void Update(int teamId, int? stadiumId);
    }
}
