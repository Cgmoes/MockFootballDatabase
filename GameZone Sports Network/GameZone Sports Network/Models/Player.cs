using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Player
    {
        public int TeamID { get; }
        public string PlayerName { get; }
        public int PositionID { get; }
        public string Positions { get; }
        public int Age { get; }
        public int JerseyNumber { get; }
        public string CollegeName { get; }
        public string HomeState { get; }
        public int Height { get; }

        public Player(string playerName, int positionID, string positions, int age, int jerseyNumber, string collegeName, string homeState, int height, int teamID)
        {
            PlayerName = playerName;
            Positions = positions;
            Age = age;
            JerseyNumber = jerseyNumber;
            CollegeName = collegeName;
            HomeState = homeState;
            Height = height;
            TeamID = teamID;
        }
    }
}
