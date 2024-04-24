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
using GameZone_Sports_Network;

namespace GUI
{
    /// <summary>
    /// Interaction logic for InsertTeamWindow.xaml
    /// </summary>
    public partial class InsertTeamWindow : Window
    {
        public event EventHandler<CustomEventArgs>? SubmitClose;
        public InsertTeamWindow()
        {
            InitializeComponent();
        }

        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button b)
            {
                SubmitClose?.Invoke(sender, new CustomEventArgs(b.Name));
            }

            string teamName = nameBox.Text;
            string teamCity = cityBox.Text;
            string yearEstablished = yearBox.Text;
            int year = int.Parse(yearEstablished);

            string connetionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";

            SqlTeamRepository s = new SqlTeamRepository(connetionString);
            s.CreateTeam(teamName, teamCity, year);
        }
    }
}
