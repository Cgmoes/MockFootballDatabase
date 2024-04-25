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

namespace GUI
{
    /// <summary>
    /// Interaction logic for PlayerUpdateInfo.xaml
    /// </summary>
    public partial class PlayerUpdateInfo : UserControl
    {
        public PlayerUpdateInfo()
        {
            InitializeComponent();
        }
        private OffensiveStatsWindow _setOffense = new OffensiveStatsWindow();
        public OffensiveStatsWindow OffensiveStatsWindow
        {
            get
            {
                return _setOffense;
            }
            set
            {
                _setOffense = value;
            }
        }
        private DefensiveStatsWindow _setDefense = new DefensiveStatsWindow();
        public DefensiveStatsWindow DefensiveStatsWindow
        {
            get
            {
                return _setDefense;
            }
            set
            {
                _setDefense = value;
            }
        }
        private SpecialTeamsStatsWindow _setSpecial = new SpecialTeamsStatsWindow();
        public SpecialTeamsStatsWindow SpecialTeamsStatsWindow
        {
            get
            {
                return _setSpecial ;
            }
            set
            {
                _setSpecial = value;
            }
        }
        public void ClickEditStatssButton(object sender, RoutedEventArgs e)
        {
            //if(DataContext. == 1) { }
            SpecialTeamsStatsWindow r = new SpecialTeamsStatsWindow();
            r.Show();
            SpecialTeamsStatsWindow = r;
            checkButton();
        }
        public void SubmitCloseEvent(object sender, CustomEventArgs e)
        {
            if (e.Name == "SubmitButtonOffensiveStats")
            {
                OffensiveStatsWindow.Close();
            }
            if (e.Name == "SubmitButtonDefensiveStats")
            {
                DefensiveStatsWindow.Close();
            }
            if (e.Name == "SubmitButtonSpecialTeamStats")
                {
                    SpecialTeamsStatsWindow.Close();
            }
        }
        private void checkButton()
        {
            //OffensiveStatsWindow.SubmitClose += SubmitCloseEvent!;
            DefensiveStatsWindow.SubmitClose += SubmitCloseEvent!;
            SpecialTeamsStatsWindow.SubmitClose += SubmitCloseEvent!;
        }
    }
}
