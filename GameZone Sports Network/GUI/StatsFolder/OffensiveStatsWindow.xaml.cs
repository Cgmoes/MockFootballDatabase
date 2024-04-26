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
    /// Interaction logic for OffensiveStatsWindow.xaml
    /// </summary>
    public partial class OffensiveStatsWindow : Window
    {
        static string connectionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";
        SqlStatsRepository s = new SqlStatsRepository(connectionString);
        public int idToBe;
        public bool Update;
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
            if (!Update)
            {
                s.CreateOffensiveTeamsStats(idToBe, passAtt, passComp, passYards, passTd, ints, rushYards, rushAtt, rec, recYards, tds, fumbles);
            }
            else
            {
                OffensiveGamePlayerStats stats = s.GetOffensiveStatsByPlayerId(idToBe);
                s.UpdateOffensiveTeamsStats(stats.OffensiveID, idToBe, passAtt, passComp, passYards, passTd, ints, rushYards, rushAtt, rec, recYards, tds, fumbles);
            }
        }
        public bool FillStats(int id)
        {
            OffensiveGamePlayerStats stats = s.GetOffensiveStatsByPlayerId(idToBe);
            if (stats != null)
               {
                passAttBox.Text = stats.PassAttempts.ToString();
                passCompBox.Text = stats.PassCompletions.ToString();
                passYardsBox.Text = stats.PassYards.ToString();
                passTdBox.Text = stats.PassTDs.ToString();
                intsBox.Text = stats.Ints.ToString();
                rushYardsBox.Text = stats.RushYrds.ToString();
                rushAttBox.Text = stats.RushAttempts.ToString();
                recBox.Text = stats.Receptions.ToString();
                recYardsBox.Text = stats.RecievingYrds.ToString() ;
                tdBox.Text = stats.Touchdowns.ToString();
                fumblesBox.Text = stats.Fumbles.ToString();

                return true;
                }
            else
                {
                return false;
                }
        }
    }
}
