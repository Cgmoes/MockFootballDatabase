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
    /// Interaction logic for InsertControl.xaml
    /// </summary>
    public partial class InsertControl : UserControl
    {
        public InsertControl()
        {
            InitializeComponent();
        }
        private InsertPlayerWindow _setPlayer = new InsertPlayerWindow();
        public InsertPlayerWindow InsertPlayerWindow
        {
            get
            {
                return _setPlayer;
            }
            set
            {
                _setPlayer = value;
            }
        }
        private InsertTeamWindow _setTeam = new InsertTeamWindow();
        public InsertTeamWindow InsertTeamWindow
        {
            get
            {
                return _setTeam;
            }
            set
            {
                _setTeam = value;
            }
        }
        public void ClickPlayerButton(object sender, RoutedEventArgs e)
        {
            InsertPlayerWindow i = new InsertPlayerWindow();
            i.Show();
            InsertPlayerWindow = i;
            checkButton();
        }
        public void ClickTeamButton(object sender, RoutedEventArgs e)
        {
            InsertTeamWindow i = new InsertTeamWindow();
            i.Show();
            InsertTeamWindow = i;
            checkButton();
        } 
        public void SubmitCloseEvent(object sender, CustomEventArgs e)
        {
            if(e.Name == "SubmitButtonPlayer")
            {
                InsertPlayerWindow.Close();
            }
            if (e.Name == "SubmitButtonTeam")
            {
                InsertTeamWindow.Close();
            }
        }
        private void checkButton()
        {
            InsertPlayerWindow.SubmitClose += SubmitCloseEvent!;
            InsertTeamWindow.SubmitClose += SubmitCloseEvent!;
        }
    }
}
