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
using Data.Models;
using GameZone_Sports_Network;

namespace GUI
{
    /// <summary>
    /// Interaction logic for TeamUpdate.xaml
    /// </summary>
    public partial class TeamUpdate : Window
    {
        public static string connectionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";
        public SqlTeamRepository t = new SqlTeamRepository(connectionString);
        public TeamUpdate()
        {
            InitializeComponent();
        }
        public event EventHandler<CustomEventArgs>? SubmitClose;
        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                SubmitClose?.Invoke(sender, new CustomEventArgs(b.Name));
            }

            string teamName = nameBox.Text;
            string teamCity = cityBox.Text;
            int year = int.Parse(yearBox.Text);

            Team teams = t.GetTeam(teamName);
            int teamId = teams.TeamID;

            t.Updateteam(teamId, teamName, teamCity, year);
        }
    }
}
