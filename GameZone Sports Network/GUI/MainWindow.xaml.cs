using System.Text;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public EventHandler<RoutedEventArgs>? ShutdownVisibility;
        public MainWindow()
        {
            InitializeComponent();
            TopBar.OnClick += ClickTopButton!;
        }
        public void ClickTopButton(object sender, CustomEventArgs e)
        {
            if (e.Name == "InsertButton")
            {
                HideVisibilites();
                InsertControl.Visibility = Visibility.Visible;
            }
            if (e.Name == "HomeButton")
            {
                HideVisibilites();
                StandingsTable.Visibility = Visibility.Visible;
                ResultByWeek.Visibility = Visibility.Visible;
                RankQb.Visibility = Visibility.Visible;
            }
            if (e.Name == "UpdateButton")
            {
                HideVisibilites();
                UpdateControl.Visibility = Visibility.Visible;
                UpdateControl.PlayerUpdateControl.PlayerInfo.Visibility = Visibility.Hidden;
            }
            if (e.Name == "SearchButton")
            {
                HideVisibilites();
                SearchControl.Visibility = Visibility.Visible;
            }
        }
        private void HideVisibilites()
        {
            InsertControl.Visibility = Visibility.Hidden;
            UpdateControl.Visibility = Visibility.Hidden;
            UpdateControl.PlayerUpdateControl.Visibility = Visibility.Hidden;
            UpdateControl.PlayerUpdateControl.PlayerInfo.Visibility = Visibility.Hidden;
            SearchControl.Visibility = Visibility.Hidden;
            ResultByWeek.Visibility = Visibility.Hidden;
            RankQb.Visibility = Visibility.Hidden;
            StandingsTable.Visibility = Visibility.Hidden;
        }
    }
}