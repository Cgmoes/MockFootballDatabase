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
        public string TeamName { get; }
        public string TeamCity { get; }
        public int YearEstablished { get; }

        public Team(int teamID, string teamName, string teamCity, int yearEstablished)
        {
            TeamID = teamID;
            TeamName = teamName;
            TeamCity = teamCity;
            YearEstablished = yearEstablished;
        }
    }
}
