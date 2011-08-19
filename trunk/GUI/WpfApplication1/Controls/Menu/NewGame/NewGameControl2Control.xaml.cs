using System;
using System.Windows;
using System.Windows.Controls;
using SlotGameGUI.Common;

namespace SlotGameGUI.Controls.Menu.NewGame
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
