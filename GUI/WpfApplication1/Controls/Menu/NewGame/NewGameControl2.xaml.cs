using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SlotGameGUI.Controls.Menu.NewGame
{
    /// <summary>
    /// Interaction logic for NewGameControl2.xaml
    /// </summary>
    public partial class NewGameControl2 : UserControl
    {
        public List<NewGameControl2Control> Screens { get; private set; }
        public NewGameControl2()
        {
            InitializeComponent();

            Screens = new List<NewGameControl2Control>();

            var content = new NewGameControl2Control();
            content.SystemIndexComboBox.SelectedIndex = 0;
            content.ResolutionComboBox.SelectedIndex = 0;
            Screen1Control.Content = content;
            Screens.Add(content);

            content = new NewGameControl2Control();
            content.SystemIndexComboBox.SelectedIndex = 1;
            content.ResolutionComboBox.SelectedIndex = 2;
            Screen2Control.Content = content;
            Screens.Add(content);

        }

        private void AddScreenButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
