using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Player
    {
        public int PlayerID { get; }
        public string PlayerName { get; }
        public Positions Positions { get; }
        public int Age { get; }
        public int JerseyNumber { get; }
        public string CollegeName { get; }
        public string HomeState { get; }
        public int Height { get; }

        public Player(int playerID, string playerName, Positions positions, int age, int jerseyNumber, string collegeName, string homeState, int height)
        {
            PlayerID = playerID;
            PlayerName = playerName;
            Positions = positions;
            Age = age;
            JerseyNumber = jerseyNumber;
            CollegeName = collegeName;
            HomeState = homeState;
            Height = height;
        }
    }
}
