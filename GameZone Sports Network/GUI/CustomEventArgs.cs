using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GUI
{
    public class CustomEventArgs : RoutedEventArgs
    {
        public string Name { get; private set; }

        public CustomEventArgs(string name)
        {
            Name = name;
        }
    }
}
