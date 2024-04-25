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
    /// Interaction logic for ResultInsertWindow.xaml
    /// </summary>
    public partial class ResultInsertWindow : Window
    {
        static string connectionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";
        readonly SqlResultsRepository r = new SqlResultsRepository(connectionString);
        readonly SqlTeamRepository s = new SqlTeamRepository(connectionString);
        public ResultInsertWindow()
        {
            InitializeComponent();
            populateTeams(s);
        }
        public event EventHandler<CustomEventArgs>? SubmitClose;
        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                SubmitClose?.Invoke(sender, new CustomEventArgs(b.Name));
            }

            int week = 2;
            string homeTeam = homeTeamBox.Text;
            string awayTeam = awayTeamBox.Text;
            int homePoints = int.Parse(homeTeamPointsBox.Text);
            int awayPoints = int.Parse(awayTeamPointsBox.Text);
            r.CreateResults(week, awayTeam, homePoints, awayPoints);
        }

        private void populateTeams(SqlTeamRepository s)
        {
            foreach (string teamName in s.RetrieveTeamNames())
            {
                homeTeamBox.Items.Add(teamName);
                awayTeamBox.Items.Add(teamName);
            }
        }
    }
}
