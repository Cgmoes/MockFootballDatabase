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
    /// Interaction logic for PlayerUpdate.xaml
    /// </summary>
    public partial class PlayerUpdate : UserControl
    {
        public EventHandler<RoutedEventArgs>? GoBack;
        public PlayerUpdate()
        {
            InitializeComponent();
        }
        public void ClickBack(object sender, RoutedEventArgs e)
        {
            GoBack?.Invoke(this, e);
            PlayerInfo.Visibility = Visibility.Hidden;
        }
        public void SubmitButton(object sender, RoutedEventArgs e)
        {
            /*
            if(PlayerInfo.DataContext != null)
            {

            }
            */
            PlayerInfo.Visibility = Visibility.Visible; 
        }
    }
}
