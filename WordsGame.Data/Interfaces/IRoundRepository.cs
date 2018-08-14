using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsGame.Entities;

namespace WordsGame.Data.Interfaces
{
    /// <summary>
    /// Defines the base operations for Round type data access
    /// </summary>
    public interface IRoundRepository
    {
        IQueryable<Round> All { get; }
        Round Find(int? id);
        void InsertOrUpdate(Round round);
        void Delete(int id);
        void Save();
    }
}
