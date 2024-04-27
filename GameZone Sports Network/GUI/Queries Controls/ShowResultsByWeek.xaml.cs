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
    /// Interaction logic for ShowResultsByWeek.xaml
    /// </summary>
    public partial class ShowResultsByWeek : UserControl
    {
        public static string connectionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";
        public SqlResultsRepository t = new SqlResultsRepository(connectionString);

        public ShowResultsByWeek()
        {
            InitializeComponent();
        }
        private void SubmitClick(object sender, RoutedEventArgs e)
        {
            int weekNumber = countBox.Count;
            List<string> teamResults = t.GetResultsByWeek(weekNumber);

            showResultsBox.Items.Clear();

            foreach (string teamInfo in teamResults)
            {
                showResultsBox.Items.Add(teamInfo);
            }
        }
    }
}
