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
        private List<NewGameControl2Control> _screens = new List<NewGameControl2Control>();
        public NewGameControl2()
        {
            InitializeComponent();

            var content = new NewGameControl2Control();
            content.SystemIndexComboBox.SelectedIndex = 0;
            content.ResolutionComboBox.SelectedIndex = 0;
            Screen1Control.Content = content;
            _screens.Add(content);

            content = new NewGameControl2Control();
            content.SystemIndexComboBox.SelectedIndex = 1;
            content.ResolutionComboBox.SelectedIndex = 2;
            Screen2Control.Content = content;
            _screens.Add(content);

        }

        private void AddScreenButtonClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
