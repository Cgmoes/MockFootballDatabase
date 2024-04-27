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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Data.Models;
using GameZone_Sports_Network;

namespace GUI
{
    /// <summary>
    /// Interaction logic for SearchControl.xaml
    /// </summary>
    public partial class SearchControl : UserControl
    {
        public static string connectionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";
        SqlTeamRepository t = new SqlTeamRepository(connectionString);
        SqlPlayerRepository p = new SqlPlayerRepository(connectionString);
        public SearchControl()
        {
            InitializeComponent();
        }
        public void Selected(object sender, RoutedEventArgs e)
        {
            DisplayTeamPlayerControl.playerListBox.Items.Clear();
            if (teamListBox.SelectedItem != null)
            {
                string item = teamListBox.SelectedItem.ToString()!;
                Team team = t.GetTeam(item);
                IReadOnlyList<Player> playersInTeam = p.GetPlayersByTeam(team.TeamID);
                int totalPlayers = p.GetTotalPlayers(team.TeamID);
                DisplayTeamPlayerControl.playerListBox.Items.Add($"Total Number Of Players: {totalPlayers}");
                foreach(Player player in playersInTeam) 
                {
                    DisplayTeamPlayerControl.playerListBox.Items.Add($"{player.PlayerName} - {player.Position}");
                }
            }
        }
        public void PopulateTeamsBox()
        {
            foreach (string team in t.RetrieveTeamNames())
            {
                teamListBox.Items.Add(team);
            }
        }

        public void SubmitButton(object sender, RoutedEventArgs e)
        {
            teamListBox.Items.Clear();
            foreach (string t in t.RetrieveTeamNames())
            {
                if (t.Contains(searchBox.Text, StringComparison.InvariantCultureIgnoreCase))
                {
                    teamListBox.Items.Add(t);
                }
            }
        }
    }
}
