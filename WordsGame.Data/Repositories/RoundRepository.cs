using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsGame.Data.Context;
using WordsGame.Data.Interfaces;
using WordsGame.Entities;

namespace WordsGame.Data.Repositories
{
    public class RoundRepository : IRoundRepository
    {
        private ApplicationDbContext dbContext;

        public RoundRepository()
        {
            this.dbContext = ApplicationDbContext.Create();
        }

        public IQueryable<Round> All 
        {
            get
            {
                return this.dbContext.Rounds;
            }
        }

        public Round Find(int? id)
        {
            Round round = this.dbContext.Rounds.Where(p => p.Id == id).FirstOrDefault();
            
            return round;
        }

        public void InsertOrUpdate(Round round)
        {
            if (round.Id == default(int))
            {
                // New entity
                round = this.dbContext.Rounds.Add(round);
            }
            else
            {
                // Existing entity
                this.dbContext.Entry(round).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var round = this.dbContext.Rounds.Find(id);
            this.dbContext.Rounds.Remove(round);
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }

        public void Dispose()
        {
            this.dbContext.Dispose();
        }
    }
}
