using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class OffensiveGamePlayerStats
    {
        public int GameID { get; }
        public int? PassAttempts { get; }
        public int? PassCompletions { get; }
        public int? PassYards { get; }
        public int? PassTDs { get; }
        public int? Ints { get; }
        public int? RushYrds { get; }
        public int? RushAttempts { get; }
        public int? Receptions { get; }
        public int? RecievingYrds { get; }
        public int? RushTDs { get; }
        public int? RecievingTDs { get; }
        public int? Fumbles { get; }

        public OffensiveGamePlayerStats(int gameID, int? passAttempts, int? passCompletions, int? passYards, int? passTDs, int? ints, int? rushYrds, int? rushAttempts, int? receptions, int? recievingYrds, int? rushTDs, int? recievingTDs, int? fumbles)
        {
            GameID = gameID;
            PassAttempts = passAttempts;
            PassCompletions = passCompletions;
            PassYards = passYards;
            PassTDs = passTDs;
            Ints = ints;
            RushYrds = rushYrds;
            RushAttempts = rushAttempts;
            Receptions = receptions;
            RecievingYrds = recievingYrds;
            RushTDs = rushTDs;
            RecievingTDs = recievingTDs;
            Fumbles = fumbles;
        }
    }
}
