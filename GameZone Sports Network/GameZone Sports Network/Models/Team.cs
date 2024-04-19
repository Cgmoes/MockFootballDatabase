using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Team
    {
        public int TeamID { get; }
        public TeamNames TeamName { get; }
        public string TeamCity { get; }
        public string YearEstablished { get; }

        public Team(int teamID, TeamNames teamName, string teamCity, string yearEstablished)
        {
            TeamID = teamID;
            TeamName = teamName;
            TeamCity = teamCity;
            YearEstablished = yearEstablished;
        }
    }
}
