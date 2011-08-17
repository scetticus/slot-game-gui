using System;
using System.Collections.Generic;
using System.Linq;
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

namespace WpfApplication1.Controls.Menu.NewGame
{
    /// <summary>
    /// Interaction logic for NewGameControl2.xaml
    /// </summary>
    public partial class NewGameControl2 : UserControl
    {
        public NewGameControl2()
        {
            InitializeComponent();

            Screen1Control.Content = new NewGameControl2Control();
            Screen2Control.Content = new NewGameControl2Control();
        }

        private void AddScreenButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
