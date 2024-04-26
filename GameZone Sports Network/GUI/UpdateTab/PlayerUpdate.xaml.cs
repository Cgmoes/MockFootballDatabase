using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Data.Models;
using GameZone_Sports_Network;
using GameZone_Sports_Network.Models.Enums;

namespace GUI
{
    /// <summary>
    /// Interaction logic for PlayerUpdate.xaml
    /// </summary>
    public partial class PlayerUpdate : UserControl
    {
        public EventHandler<RoutedEventArgs>? GoBack;
        public static string connectionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";
        public SqlPlayerRepository s = new SqlPlayerRepository(connectionString);
        public SqlTeamRepository t = new SqlTeamRepository(connectionString);
        public PlayerUpdate()
        {
            InitializeComponent();
            PopulatePositions();
            PlayerInfo.OnPositionChange += PositionChangedEvent!;
            PlayerInfo.OnUpdate += ClickBack!;
        }
        public void ClickBack(object sender, RoutedEventArgs e)
        {
            GoBack?.Invoke(this, e);
            PlayerInfo.Visibility = Visibility.Hidden;
        }
        public void SubmitButton(object sender, RoutedEventArgs e)
        {
            playersListBox.Items.Clear();
            foreach(Player p in s.GetPlayers())
            {
                if (p.PlayerName.Contains(searchBox.Text , StringComparison.InvariantCultureIgnoreCase))
                {
                    playersListBox.Items.Add(p.PlayerName + " - " + p.Position);
                }
            }
        }



        public void PopulatePlayers(SqlPlayerRepository s)
        {
            foreach (Player playerz in s.GetPlayers())
            {
                playersListBox.Items.Add(playerz.PlayerName + " - " + playerz.Position);
            }
        }

        public void Selected(object sender, SelectionChangedEventArgs e)
        {
            if(playersListBox.SelectedItem != null)
            {
                PlayerInfo.Visibility = Visibility.Visible;
                string item = playersListBox.SelectedItem.ToString()!;
                string[] split = item!.Split(' ');
                Player p = s.GetPlayer(split[0] + " " + split[1]);
                PlayerInfo.playerName.Text = p.PlayerName;
                PlayerInfo.posID.SelectedItem = PlayerInfo.posID.Items[GetPositionSpot(p.PositionID)];
                PlayerInfo.position.SelectedItem = PositionInitial(p);
                PlayerInfo.team.SelectedItem = t.GetTeamById(p.TeamID);
                PlayerInfo.age.Text = p.Age.ToString();
                PlayerInfo.state.Text = p.HomeState;
                PlayerInfo.height.Text = p.Height.ToString();
                PlayerInfo.jerseyNumber.Text = p.JerseyNumber.ToString();
                PlayerInfo.college.Text = p.CollegeName;
            }
        }
        private void PopulatePositions()
        {
            PlayerInfo.posID.Items.Add("Offense");
            PlayerInfo.posID.Items.Add("Defense");
            PlayerInfo.posID.Items.Add("Special Teams");
        }
        private int GetPositionSpot(int id)
        {
            if (id == 1)
            {
                return 0;
            }
            else if (id == 2)
            {
                return 1;
            }
            else if (id == 3)
            {
                return 2;
            }
            return -1;
        }
            public void PopulateTeams(SqlTeamRepository s)
        {
            foreach (string teamz in s.RetrieveTeamNames())
            {
                PlayerInfo.team.Items.Add(teamz);
            }
        }
        public string PositionInitial(Player d)
        {
            PlayerInfo.position.IsEnabled = true;
            PlayerInfo.position.Items.Clear();
            if (d.PositionID == 1)
            {
                foreach (OffensivePositions p in Enum.GetValues(typeof(OffensivePositions)))
                {
                    PlayerInfo.position.Items.Add(p.ToString());
                }
            }
            if (d.PositionID == 2)
            {
                foreach (DefensivePositions p in Enum.GetValues(typeof(DefensivePositions)))
                {
                    PlayerInfo.position.Items.Add(p.ToString());
                }
            }
            if (d.PositionID == 3)
            {
                foreach (SpecialPositions p in Enum.GetValues(typeof(SpecialPositions)))
                {
                    PlayerInfo.position.Items.Add(p.ToString());
                }
            }
            return d.Position;
        }
        public void PositionChangedEvent(object sender, CustomEventArgs e)
        {
            PlayerInfo.position.IsEnabled = true;
            PlayerInfo.position.Items.Clear();

            if (PlayerInfo.posID.SelectedItem.Equals("Offense"))
            {
                foreach (OffensivePositions p in Enum.GetValues(typeof(OffensivePositions)))
                {
                    PlayerInfo.position.Items.Add(p.ToString());
                }
            }
            if (PlayerInfo.posID.SelectedItem.Equals("Defense"))
            {
                foreach (DefensivePositions p in Enum.GetValues(typeof(DefensivePositions)))
                {
                    PlayerInfo.position.Items.Add(p.ToString());
                }
            }
            if (PlayerInfo.posID.SelectedItem.Equals("Special Teams"))
            {
                foreach (SpecialPositions p in Enum.GetValues(typeof(SpecialPositions)))
                {
                    PlayerInfo.position.Items.Add(p.ToString());
                }
            }
            PlayerInfo.position.IsEnabled = true;
        }

    }
}
