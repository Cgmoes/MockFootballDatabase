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
        public int PlayerID { get; }
        public string PlayerName { get; }
        public int PositionID { get; }
        public string Position { get; }
        public int Age { get; }
        public int JerseyNumber { get; }
        public string CollegeName { get; }
        public string HomeState { get; }
        public int Height { get; }

        public Player(int playerID, string playerName, int positionID, string positions, int age, int jerseyNumber, string collegeName, string homeState, int height, int teamId)
        { 
            PlayerName = playerName;
            Position = positions;
            PositionID = positionID;
            Age = age;
            JerseyNumber = jerseyNumber;
            CollegeName = collegeName;
            HomeState = homeState;
            Height = height;
            PlayerID = playerID;
            TeamID = teamId;
        }
    }
}
