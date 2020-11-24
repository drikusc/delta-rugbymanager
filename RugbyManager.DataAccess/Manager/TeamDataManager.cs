using Microsoft.EntityFrameworkCore;
using RugbyManager.DataAccess.Contracts;
using RugbyManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RugbyManager.DataAccess.Manager
{
    public class TeamDataManager : ITeamDataManager
    {
        public List<Team> Get(int? id = null, string name = null)
        {
            using (var db = new DataAccess())
            {
                IQueryable<Team> teams = db.Teams
                    .Include(x => x.Stadium)
                    .Include(x => x.Players);

                if (id != null)
                    teams = teams.Where(x => x.Id == id);

                if (!string.IsNullOrWhiteSpace(name))
                    teams = teams.Where(x => x.Name == name);

                return teams.ToList();
            }
        }

        public void Create(Team team)
        {
            team.CreatedDate = DateTime.Now;
            using (var db = new DataAccess())
            {
                db.Teams.Add(team);
                db.SaveChanges();
            }
        }

        public void Update(int teamId, int? stadiumId)
        {
            using (var db = new DataAccess())
            {
                var dbTeam = db.Teams.Where(x => x.Id == teamId).FirstOrDefault();
                if (dbTeam == null)
                    return;

                dbTeam.StadiumId = stadiumId;
                dbTeam.ModifiedDate = DateTime.Now;
                
                db.Teams.Update(dbTeam);
                db.SaveChanges();
            }
        }
    }
}
