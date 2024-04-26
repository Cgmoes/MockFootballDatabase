using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class SpecialTeamsGamePlayerStats
    {
        public int SpecialTeamsId { get; }

        public int PlayerId { get; }
        public int? FieldGoalAtt { get; }
        public int? FieldGoalsMade { get; }
        public int? Punts { get; }
        public int? PuntYrds { get; }

        public SpecialTeamsGamePlayerStats(int id, int playerId, int? fieldGoalAtt, int? fieldGoalsMade, int? punts, int? puntYrds)
        {
            SpecialTeamsId = id;
            PlayerId = playerId;
            FieldGoalAtt = fieldGoalAtt;
            FieldGoalsMade = fieldGoalsMade;
            Punts = punts;
            PuntYrds = puntYrds;
        }
    }
}
