﻿using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Provider
{
    internal class TeamProvider
    {
        private readonly AppDbContext _context;

        public TeamProvider(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public void Update(Team team)
        {
            _context.Teams.Update(team);

            _context.SaveChanges();
        }

        public void Delete(Team team)
        {
            _context.Remove(team);
        }

        public Team Get(int id)
        {
            return _context.Teams.First(x => x.Id == id);
        }

        public List<Team> GetAll()
        {
            return _context.Teams.ToList();
        }
    }
}
