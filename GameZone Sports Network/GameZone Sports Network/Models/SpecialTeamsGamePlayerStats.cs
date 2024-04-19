using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class SpecialTeamsGamePlayerStats
    {
        public int? FieldGoalAtt { get; }
        public int? FieldGoalsMade { get; }
        public int? Punts { get; }
        public int? PuntYrds { get; }

        public SpecialTeamsGamePlayerStats(int? fieldGoalAtt, int? fieldGoalsMade, int? punts, int? puntYrds)
        {
            FieldGoalAtt = fieldGoalAtt;
            FieldGoalsMade = fieldGoalsMade;
            Punts = punts;
            PuntYrds = puntYrds;
        }
    }
}
