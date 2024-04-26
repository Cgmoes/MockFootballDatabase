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
    /// Interaction logic for DefensiveStatsWindow.xaml
    /// </summary>
    public partial class DefensiveStatsWindow : Window
    {
        static string connectionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";
        SqlStatsRepository s = new SqlStatsRepository(connectionString);
        public int idToBe;
        public DefensiveStatsWindow(int id)
        {
            InitializeComponent();
            idToBe = id;
        }
        public event EventHandler<CustomEventArgs>? SubmitClose;

        public void SumbitClick(object sender, EventArgs e)
        {
            if(sender is Button b)
            {
                SubmitClose?.Invoke(this, new CustomEventArgs(b.Name));
            }
            int tackles = int.Parse(tacklesBox.Text);
            int sacks = int.Parse(sacksBox.Text);
            int ints = int.Parse(intsBox.Text);
            int fumbles = int.Parse(fumblesBox.Text);
            int tds = int.Parse(tdBox.Text);

            s.CreateDefensiveTeamsStats(idToBe, tackles, sacks, ints, fumbles, tds);
        }

    }
}
