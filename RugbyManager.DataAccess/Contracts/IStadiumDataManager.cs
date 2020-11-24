using RugbyManager.DataAccess.Models;
using System.Collections.Generic;

namespace RugbyManager.DataAccess.Contracts
{
    public interface IStadiumDataManager
    {
        List<Stadium> Get(int? id = null, string name = null);

        void Create(Stadium stadium);
    }
}
