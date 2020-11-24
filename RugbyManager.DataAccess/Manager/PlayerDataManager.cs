using Microsoft.EntityFrameworkCore;
using RugbyManager.DataAccess.Contracts;
using RugbyManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RugbyManager.DataAccess.Manager
{
    public class PlayerDataManager : IPlayerDataManager
    {
        public List<Player> Get(int? id = null, string firstName = null, string lastName = null, decimal? height = null, string teamName = null, string positionCode = null)
        {
            using (var db = new DataAccess())
            {
                IQueryable<Player> players = db.Players
                    .Include(x => x.Position)
                    .Include(x => x.Team);

                if(id != null)
                    players = players.Where(x => x.Id == id);

                if (!string.IsNullOrWhiteSpace(firstName))
                    players = players.Where(x => x.FirstName.Contains(firstName));

                if (!string.IsNullOrWhiteSpace(lastName))
                    players = players.Where(x => x.LastName.Contains(lastName));

                if (!string.IsNullOrWhiteSpace(teamName))
                    players = players.Where(x => x.Team.Name.Contains(teamName));

                if (!string.IsNullOrWhiteSpace(positionCode))
                    players = players.Where(x => x.Position.Code == positionCode);

                return players.ToList();
            }
        }

        public void Create(Player player)
        {
            player.CreatedDate = DateTime.Now;
            using (var db = new DataAccess())
            {
                db.Players.Add(player);
                db.SaveChanges();
            }
        }

        public void Update(int playerId, int teamId)
        {
            using (var db = new DataAccess())
            {
                var dbPlayer = db.Players.Where(x => x.Id == playerId).FirstOrDefault();
                if (dbPlayer == null)
                    return;

                dbPlayer.TeamId = teamId;
                dbPlayer.ModifiedDate = DateTime.Now;

                db.Players.Update(dbPlayer);
                db.SaveChanges();
            }
        }
    }
}
