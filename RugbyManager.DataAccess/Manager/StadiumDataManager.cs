using Microsoft.EntityFrameworkCore;
using RugbyManager.DataAccess.Contracts;
using RugbyManager.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RugbyManager.DataAccess.Manager
{
    public class StadiumDataManager : IStadiumDataManager
    {
        public List<Stadium> Get(int? id = null, string name = null)
        {
            using (var db = new DataAccess())
            {
                IQueryable<Stadium> stadiums = db.Stadiums.Include(x => x.Team);

                if (id != null)
                    stadiums = stadiums.Where(x => x.Id == id);

                if(!string.IsNullOrWhiteSpace(name))
                    stadiums = stadiums.Where(x => x.Name == name);

                return stadiums.ToList();
            }
        }

        public void Create(Stadium stadium)
        {
            stadium.CreatedDate = DateTime.Now;
            using(var db = new DataAccess())
            {
                db.Stadiums.Add(stadium);
                db.SaveChanges();
            }
        }
    }
}
