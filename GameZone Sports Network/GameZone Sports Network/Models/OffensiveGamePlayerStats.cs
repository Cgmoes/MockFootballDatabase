using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class OffensiveGamePlayerStats
    {
        public int OffensiveID { get; }
        public int PlayerID { get; }
        public int? PassAttempts { get; }
        public int? PassCompletions { get; }
        public int? PassYards { get; }
        public int? PassTDs { get; }
        public int? Ints { get; }
        public int? RushYrds { get; }
        public int? RushAttempts { get; }
        public int? Receptions { get; }
        public int? RecievingYrds { get; }
        public int? Touchdowns { get; }
        public int? Fumbles { get; }

        public OffensiveGamePlayerStats(int gameID, int playerId, int? passAttempts, int? passCompletions, int? passYards, int? passTDs, int? ints, int? rushYrds, int? rushAttempts, int? receptions, int? recievingYrds, int? touchdowns, int? fumbles)
        {
            OffensiveID = gameID;
            PlayerID = playerId;
            PassAttempts = passAttempts;
            PassCompletions = passCompletions;
            PassYards = passYards;
            PassTDs = passTDs;
            Ints = ints;
            RushYrds = rushYrds;
            RushAttempts = rushAttempts;
            Receptions = receptions;
            RecievingYrds = recievingYrds;
            Touchdowns = touchdowns;
            Fumbles = fumbles;
        }
    }
}
