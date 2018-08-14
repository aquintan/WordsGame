using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsGame.Entities;

namespace WordsGame.Services.Interfaces
{
    public interface IGameService
    {
        Round GetRoundById(int id);

        Round CreateGame(string userId);

        void FinishGame(Round round);

        Dictionary<string, List<string>> GetLastRoundForUserRole();
    }
}
