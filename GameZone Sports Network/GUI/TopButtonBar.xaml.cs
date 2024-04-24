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
    /// Interaction logic for TopButtonBar.xaml
    /// </summary>
    public partial class TopButtonBar : UserControl
    {
        public TopButtonBar()
        {
            InitializeComponent();
        }
        public EventHandler<CustomEventArgs>? OnClick;
        public void ButtonClick(object sender, RoutedEventArgs e)
        {
            if(sender is Button b)
            {
                if(b.Name == "InsertButton")
                {
                    
                    OnClick?.Invoke(this, new CustomEventArgs(b.Name));
                }
                if (b.Name == "UpdateButton")
                {
                    OnClick?.Invoke(this, new CustomEventArgs(b.Name));
                }
                if (b.Name == "HomeButton")
                {
                    OnClick?.Invoke(this, new CustomEventArgs(b.Name));
                }
                if (b.Name == "SearchButton")
                {
                    OnClick?.Invoke(this, new CustomEventArgs(b.Name));
                }
            }
        }
    }
}
