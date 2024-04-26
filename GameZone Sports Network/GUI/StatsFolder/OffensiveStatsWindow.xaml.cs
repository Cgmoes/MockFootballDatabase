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
    /// Interaction logic for OffensiveStatsWindow.xaml
    /// </summary>
    public partial class OffensiveStatsWindow : Window
    {
        static string connectionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";
        SqlStatsRepository s = new SqlStatsRepository(connectionString);
        public int idToBe;
        public OffensiveStatsWindow(int playerId)
        {
            InitializeComponent();
            idToBe = playerId;
        }
        public event EventHandler<CustomEventArgs>? SubmitClose;

        public void SumbitClick(object sender, EventArgs e)
        {
            if (sender is Button b)
            {
                SubmitClose?.Invoke(this, new CustomEventArgs(b.Name));
            }
            int passAtt = int.Parse(passAttBox.Text);
            int passComp = int.Parse(passCompBox.Text);
            int passYards = int.Parse(passYardsBox.Text);
            int passTd = int.Parse(passTdBox.Text);
            int ints = int.Parse(intsBox.Text);
            int rushYards = int.Parse(rushYardsBox.Text);
            int rushAtt = int.Parse(rushAttBox.Text);
            int rec = int.Parse(recBox.Text);
            int recYards = int.Parse(recYardsBox.Text);
            int tds = int.Parse(tdBox.Text);
            int fumbles = int.Parse(fumblesBox.Text);
            s.CreateOffensiveTeamsStats(idToBe, passAtt, passComp, passYards, passTd, ints, rushYards, rushAtt, rec, recYards, tds, fumbles);
        }
    }
}
