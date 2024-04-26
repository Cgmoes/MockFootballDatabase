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
    /// Interaction logic for StandingsTable.xaml
    /// </summary>
    public partial class StandingsTable : UserControl
    {
        public static string connectionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";
        public SqlResultsRepository t = new SqlResultsRepository(connectionString);
        public StandingsTable()
        {
            InitializeComponent();
            populateStandings();
        }

        
        public void populateStandings() 
        {
            List<string> standings = t.ShowStandings();
            foreach(string team in standings) 
            {
                standingsBox.Items.Add(team);
            }
        }
    }
}
