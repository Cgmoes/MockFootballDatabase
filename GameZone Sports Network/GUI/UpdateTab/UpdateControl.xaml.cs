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
using GameZone_Sports_Network;

namespace GUI
{
    /// <summary>
    /// Interaction logic for UpdateControl.xaml
    /// </summary>
    public partial class UpdateControl : UserControl
    {
        public static string connectionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";
        public SqlPlayerRepository s = new SqlPlayerRepository(connectionString);
        public SqlTeamRepository t = new SqlTeamRepository(connectionString);
        public UpdateControl()
        {
            InitializeComponent();
            PlayerUpdateControl.GoBack += CloseWindow!;
            TeamUpdate!.SubmitClose += CloseWindow!;
        }
        public void ClickPlayerUpdate(object sender, RoutedEventArgs e)
        {
            PlayerUpdateControl.Visibility = Visibility.Visible;
            PlayerUpdateControl.playersListBox.Items.Clear();
            PlayerUpdateControl.PopulatePlayers(s);
            PlayerUpdateControl.PopulateTeams(t);
        }
        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            PlayerUpdateControl.Visibility = Visibility.Hidden;
            TeamUpdate!.Close();
        }
        public TeamUpdate? TeamUpdate = new();
        public void ClickTeamUpdate(object sender, RoutedEventArgs e)
        {
            TeamUpdate t = new TeamUpdate();
            t.Show();
            TeamUpdate = t;
            CheckClose();
        }
        private void CheckClose()
        {
            TeamUpdate!.SubmitClose += CloseWindow!;
        }
    }
}
