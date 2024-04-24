using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Team
    {
        public string TeamName { get; }
        public string TeamCity { get; }
        public int YearEstablished { get; }

        public Team(string teamName, string teamCity, int yearEstablished)
        {
            TeamName = teamName;
            TeamCity = teamCity;
            YearEstablished = yearEstablished;
        }
    }
}
