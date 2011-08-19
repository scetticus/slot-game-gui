using System.IO;
using System.Windows;
using SlotGameGUI.Common;
using SlotGameGUI.Common.Component;

namespace SlotGameGUI.Controls.Menu.NewGame
{
    /// <summary>
    /// Interaction logic for NewGameWindow.xaml
    /// </summary>
    public partial class NewGameWindow : Window
    {
        private int _pageCount;

        public NewGameControl1 Control1 { get; private set; }
        public NewGameControl2 Control2 { get; private set; }
        public NewGameControl3 Control3 { get; private set; }

        public NewGameWindow()
        {
            InitializeComponent();
            Control1 = new NewGameControl1(this);

            Panel.Content = Control1;
            Control2 = new NewGameControl2();
            Control3 = new NewGameControl3();

        }

        private void CancelButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NextButtonClick(object sender, RoutedEventArgs e)
        {
            _pageCount++;
            ChangeContent();
            PreviewButton.IsEnabled = true;

            if (_pageCount == 2)
                NextButton.IsEnabled = false;
        }

        private void PreviewButtonClick(object sender, RoutedEventArgs e)
        {
            _pageCount--;
            ChangeContent();
            NextButton.IsEnabled = true;

            if (_pageCount == 0)
                PreviewButton.IsEnabled = false;
        }
        private void ChangeContent()
        {
            switch (_pageCount)
            {
                case 0:
                    Panel.Content = Control1;
                    label2.Content = "Enter a game name.";
                    break;
                case 1:
                    Panel.Content = Control2;
                    label2.Content = "Game Performance Configuration.(When you have no idea, press the Finish button.)";
                    break;
                case 2:
                    Panel.Content = Control3;
                    label2.Content = "Game Communications and Miscellaneous.(When you have no idea, press the Finish button.)";
                    break;

            }
        }

        private void FinishButtonClick(object sender, RoutedEventArgs e)
        {
            var game = new SlotGame();
            MainWindow.Instance.Game = game;

            game.AddComponent(new Display(this));

            game.Show();

            if (!Directory.Exists(Control1.LocationTextBox.Text))
                Directory.CreateDirectory(Control1.LocationTextBox.Text);

            if (!Directory.Exists(Control1.ResourcesTextBox.Text))
                Directory.CreateDirectory(Control1.ResourcesTextBox.Text);

            if (!Directory.Exists(Control1.OutputTextBox.Text))
                Directory.CreateDirectory(Control1.OutputTextBox.Text);

            File.Create(Control1.LocationTextBox.Text + @"\" + Control1.GameNameTextBox.Text + ".slg");

            Close();
        }
    }
}
