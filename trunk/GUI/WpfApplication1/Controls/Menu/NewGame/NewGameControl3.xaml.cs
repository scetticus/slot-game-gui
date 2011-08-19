using System.Windows;
using System.Windows.Controls;

namespace SlotGameGUI.Controls.Menu.NewGame
{
    /// <summary>
    /// Interaction logic for NewGameControl3.xaml
    /// </summary>
    public partial class NewGameControl3 : UserControl
    {
        public NewGameControl3()
        {
            InitializeComponent();
        }

        private void UpdateFrequencySliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateFrequencyLabel.Content = e.NewValue;
        }




    }
}
