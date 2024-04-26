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
using System.Xml.Linq;
using Data.Models;
using GameZone_Sports_Network;
using GameZone_Sports_Network.Models.Enums;

namespace GUI
{
    /// <summary>
    /// Interaction logic for SpecialTeamsStatsWindow.xaml
    /// </summary>
    public partial class SpecialTeamsStatsWindow : Window
    {
        static string connectionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";
        SqlStatsRepository s = new SqlStatsRepository(connectionString);
        public int idToBe;
        public SpecialTeamsStatsWindow(int playerID)
        {
            InitializeComponent();
            idToBe = playerID;
        }
        public event EventHandler<CustomEventArgs>? SubmitClose;

        public void SumbitClick(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                SubmitClose?.Invoke(this, new CustomEventArgs(b.Name));
            }
            int fgAttempts = int.Parse(fgAttemptsBox.Text);
            int fgMade = int.Parse(fgMadeBox.Text);
            int punts = int.Parse(puntsBox.Text);
            int puntYards = int.Parse(puntYardsBox.Text);

            s.CreateSpecialTeamsStats(idToBe, fgAttempts, fgMade, punts, puntYards);
        }
    }
}
