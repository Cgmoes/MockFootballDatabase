using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class DefensiveGamePlayerStats
    {
        public int DefensiveTeamID { get; }

        public int PlayerId { get; }
        public int? Tackles { get; }
        public int? Sacks { get; }
        public int? Interceptions { get; }
        public int? Fumbles { get; }
        public int? TDs { get; }

        public DefensiveGamePlayerStats(int id, int playerId, int? tackles, int? sacks, int? interceptions, int? fumbles, int? tDs)
        {
            DefensiveTeamID = id;
            PlayerId = playerId;
            Tackles = tackles;
            Sacks = sacks;
            Interceptions = interceptions;
            Fumbles = fumbles;
            TDs = tDs;
        }
    }
}
