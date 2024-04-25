using GameZone_Sports_Network;
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
        public InsertPlayerWindow()
        {
            InitializeComponent();

            string connectionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";
            SqlTeamRepository s = new SqlTeamRepository(connectionString);
            populateTeams(s);
        }

        private void populateTeams(SqlTeamRepository s) 
        {
            foreach (string teamName in s.RetrieveTeamNames())
            {
                team.Items.Add(teamName);
            }
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                SubmitClose?.Invoke(sender, new CustomEventArgs(b.Name));
            }
            /*
            string name = playerName.Text;
            int posID = 0;
            if (positionRole.Name == "Offense")
            {
                posID = 1;
            }
            else if (positionRole.Name == "Defense")
            {
                posID = 2;
            }
            else if (positionRole.Name == "Special Teams")
            {
                posID = 3;
            }
            string pos = position.Name;
            int ages = int.Parse(age.Text);
            int jerseyNum = int.Parse(jersey.Text);
            string col = college.Text;
            string homeState = state.Text;
            int hi = int.Parse(age.Text);
            //still need to add a team ID

            string connetionString = "Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=MockESPN;Integrated Security=True";

            SqlPlayerRepository s = new SqlPlayerRepository(connetionString);
            //s.CreatePlayer(name, posID, pos, ages, jerseyNum, col,homeState, age, )
            */
        }
    }
}
