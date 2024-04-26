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
    /// Interaction logic for PlayerUpdateInfo.xaml
    /// </summary>
    public partial class PlayerUpdateInfo : UserControl
    {
        public static string connectionString = "Data Source=(localdb)\\mylocaldb;Initial Catalog=MockESPN;Integrated Security=True";
        public SqlPlayerRepository s = new SqlPlayerRepository(connectionString);
        public SqlTeamRepository t = new SqlTeamRepository(connectionString);
        public PlayerUpdateInfo()
        {
            InitializeComponent();
            OffensiveStatsWindow.SubmitClose += CloseWindows!;
            DefensiveStatsWindow.SubmitClose += CloseWindows!;
            SpecialTeamsStatsWindow.SubmitClose += CloseWindows!;
        }
        public event EventHandler<CustomEventArgs>? OnPositionChange;
        public event EventHandler<RoutedEventArgs>? OnUpdate;
        private OffensiveStatsWindow _setOffense = new OffensiveStatsWindow(0);
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
        private DefensiveStatsWindow _setDefense = new DefensiveStatsWindow(0);
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
        private SpecialTeamsStatsWindow _setSpecial = new SpecialTeamsStatsWindow(0);
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
        public void ChangedPosition(object sender, RoutedEventArgs e)
        {
            OnPositionChange?.Invoke(sender, new CustomEventArgs(posID.SelectedItem.ToString()!));
        }

        private void UpdateClick(object sender, RoutedEventArgs e)
        {
            Player p = s.GetPlayer(playerName.Text);
            int posId = 0;
            if (posID.SelectedItem.Equals("Offense")) posId = 1;
            else if (posID.SelectedItem.Equals("Defense")) posId = 2;
            else if (posID.SelectedItem.Equals("Special Teams")) posId = 3;
            int playerId = p.PlayerID;
            string name = playerName.Text;
            string pos = position.Text;
            int ages = int.Parse(age.Text);
            int jerseyNum = int.Parse(jerseyNumber.Text);
            string col = college.Text;
            string homeState = state.Text;
            int hei = int.Parse(height.Text);
            string playerTeam = team.Text;
            Team teams = t.GetTeam(playerTeam);

            s.UpdatePlayer(playerId, name, posId, pos, ages, jerseyNum, col, homeState, hei, teams.TeamID);
            OnUpdate?.Invoke(this, e);
        }

        private void EditStatsButton(object sender, RoutedEventArgs e)
        {
            Player p = s.GetPlayer(playerName.Text);
            if (posID.SelectedItem.ToString()!.Equals("Offense"))
            {
                OffensiveStatsWindow o = new OffensiveStatsWindow(p.PlayerID);
                o.Show();
                OffensiveStatsWindow = o;
                OffensiveStatsWindow.Update = OffensiveStatsWindow.FillStats(p.PlayerID);
            }
            if (posID.SelectedItem.ToString()!.Equals("Defense"))
            {
                DefensiveStatsWindow d = new DefensiveStatsWindow(p.PlayerID);
                d.Show();
                DefensiveStatsWindow = d;
                DefensiveStatsWindow.Update = DefensiveStatsWindow.FillStats(p.PlayerID);
            }
            if (posID.SelectedItem.ToString()!.Equals("Special Teams"))
            {
                SpecialTeamsStatsWindow s = new SpecialTeamsStatsWindow(p.PlayerID);
                s.Show();
                SpecialTeamsStatsWindow = s;
                SpecialTeamsStatsWindow.Update = SpecialTeamsStatsWindow.FillStats(p.PlayerID);
            }
            CheckSubmit();
        }
        public void CloseWindows(object sender, CustomEventArgs e)
        {
            DefensiveStatsWindow.Close();
            OffensiveStatsWindow.Close();
            SpecialTeamsStatsWindow.Close();
        }
        private void CheckSubmit()
        {
            OffensiveStatsWindow.SubmitClose += CloseWindows!;
            DefensiveStatsWindow.SubmitClose += CloseWindows!;
            SpecialTeamsStatsWindow.SubmitClose += CloseWindows!;

        }
    }
}
