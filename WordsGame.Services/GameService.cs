using Microsoft.AspNet.Identity.EntityFramework;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsGame.Data.Interfaces;
using WordsGame.Data.Roles;
using WordsGame.Data.User;
using WordsGame.Entities;
using WordsGame.Services.Interfaces;

namespace WordsGame.Services
{
    public class GameService : IGameService
    {
        private readonly IRoundRepository _roundRepository;
        private readonly IUserRepository _userRepository;

        public GameService(IUserRepository userRepository, IRoundRepository roundRepository)
        {
            this._userRepository = userRepository;
            this._roundRepository = roundRepository;
        }

        public Round GetRoundById(int id)
        {
            Round r = this._roundRepository.Find(id);

            return r;
        }

        public Round CreateGame(string userId)
        {            
            Round r = new Round();
            r.RoundInfo = "";
            r.IsFinished = false;
            r.StartTime = DateTime.UtcNow;
            r.UserId = userId;

            _roundRepository.InsertOrUpdate(r);
            _roundRepository.Save();

            return r;
        }

        public void FinishGame(Round round)
        {            
            round.IsFinished = true;
            round.EndTime = DateTime.UtcNow;

            _roundRepository.InsertOrUpdate(round);
            _roundRepository.Save();
        }

        public Dictionary<string, List<string>> GetLastRoundForUserRole() 
        {
            IdentityRole userRole = this._userRepository.Roles.Where<IdentityRole>(w => w.Name.Equals(RoleNames.UserRole)).FirstOrDefault();
            List<string> userIds = userRole.Users.Select(s => s.UserId).ToList();

            var lastRound = this._roundRepository.All.Where<Round>(w => userIds.Contains(w.UserId) && w.IsFinished).OrderBy(o => o.EndTime).GroupBy(g => g.UserId).ToList();

            Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

            foreach (var item in lastRound)
            {
                string userName = this._userRepository.Users.Where(w => w.Id.Equals(item.Key)).Select(s => s.UserName).FirstOrDefault();
                Round round = item.OrderByDescending(o => o.EndTime).FirstOrDefault();

                var words = JsonConvert.DeserializeObject<List<string>>(round.RoundInfo);

                result.Add(userName, words);
            }

            return result;
        }
    }
}
