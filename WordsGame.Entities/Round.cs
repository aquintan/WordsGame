using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsGame.Entities
{
    public class Round
    {
        public int Id { get; set; }

        public string RoundInfo { get; set; }

        public string UserId { get; set; }

        public bool IsFinished { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
    }
}