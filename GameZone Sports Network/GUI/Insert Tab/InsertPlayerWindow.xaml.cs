using Data.Models;
using GameZone_Sports_Network;
using GameZone_Sports_Network.Models.Enums;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for InsertPlayerWindow.xaml
    /// </summary>
    public partial class InsertPlayerWindow : Window
    {
        public event EventHandler<CustomEventArgs>? SubmitClose;
        public static string connectionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";
        public SqlTeamRepository t = new SqlTeamRepository(connectionString);
        public InsertPlayerWindow()
        {
            InitializeComponent();
            PopulateTeams(t);
            PopulatePositions();
        }
        private void PopulatePositions()
        {
            positionRole.Items.Add("Offense");
            positionRole.Items.Add("Defense");
            positionRole.Items.Add("Special Teams");
        }
        public void PositionChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            position.IsEnabled = false;
            position.Items.Clear();

            if(positionRole.SelectedItem.Equals("Offense"))
            {
                foreach (OffensivePositions p in Enum.GetValues(typeof(OffensivePositions)))
                {
                    position.Items.Add(p.ToString());
                }
            }
            if (positionRole.SelectedItem.Equals("Defense"))
            {
                foreach (DefensivePositions p in Enum.GetValues(typeof(DefensivePositions)))
                {
                    position.Items.Add(p.ToString());
                }
            }
            if (positionRole.SelectedItem.Equals("Special Teams"))
            {
                foreach (SpecialPositions p in Enum.GetValues(typeof(SpecialPositions)))
                {
                    position.Items.Add(p.ToString());
                }
            }
            position.IsEnabled = true;
        }
        private void PopulateTeams(SqlTeamRepository s) 
        {
            foreach (string teamz in s.RetrieveTeamNames())
            {
                team.Items.Add(teamz);
            }
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                SubmitClose?.Invoke(sender, new CustomEventArgs(b.Name));
            }
            
            string name = playerName.Text;
            int posID = 0;
            if (positionRole.SelectedItem.Equals("Offense"))
            {
                posID = 1;
            }
            else if (positionRole.SelectedItem.Equals("Defense"))
            {
                posID = 2;
            }
            else if (positionRole.SelectedItem.Equals( "Special Teams"))
            {
                posID = 3;
            }

            string pos = position.Text;
            int ages = int.Parse(age.Text);
            int jerseyNum = int.Parse(jersey.Text);
            string col = college.Text;
            string homeState = state.Text;
            int hei = int.Parse(height.Text);
            string playerTeam = team.Text;
            Team teams = t.GetTeam(playerTeam);

            string connetionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";

            SqlPlayerRepository s = new SqlPlayerRepository(connetionString);
            s.CreatePlayer(name, posID, pos, ages, jerseyNum, col, homeState, hei, teams.TeamID);
            
        }
    }
}
