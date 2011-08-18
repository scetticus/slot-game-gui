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
    /// Interaction logic for NewGameControl2Control.xaml
    /// </summary>
    public partial class NewGameControl2Control : UserControl
    {
        public NewGameControl2Control()
        {
            InitializeComponent();
        }

        private void TargetedFramesPerSecondSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TargetedFramesPerSecondResultLabel.Content = e.NewValue;
        }


    }
}
