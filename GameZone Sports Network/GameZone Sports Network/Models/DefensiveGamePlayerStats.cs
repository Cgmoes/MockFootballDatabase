using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class DefensiveGamePlayerStats
    {
        public int Tackles { get; }
        public int Sacks { get; }
        public int Interceptions { get; }
        public int Fumbles { get; }
        public int TDs { get; }

        public DefensiveGamePlayerStats(int tackles, int sacks, int interceptions, int fumbles, int tDs)
        {
            Tackles = tackles;
            Sacks = sacks;
            Interceptions = interceptions;
            Fumbles = fumbles;
            TDs = tDs;
        }
    }
}
