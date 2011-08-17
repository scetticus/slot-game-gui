using System.Windows;

namespace WpfApplication1.Controls.Menu.NewGame
{
    /// <summary>
    /// Interaction logic for NewGameWindow.xaml
    /// </summary>
    public partial class NewGameWindow : Window
    {
        private int _pageCount;

        private readonly NewGameControl1 _control1;
        private readonly NewGameControl2 _control2;

        public NewGameWindow()
        {
            InitializeComponent();
            _control1 = new NewGameControl1();

            Panel.Content = _control1;
            _control2 = new NewGameControl2();
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

            if (_pageCount == 1)
                NextButton.IsEnabled = false;
        }

        private void PreviewButtonClick(object sender, RoutedEventArgs e)
        {
            _pageCount--;
            ChangeContent();
            NextButton.IsEnabled = true;

            if (_pageCount == 2)
                PreviewButton.IsEnabled = false;
        }
        private void ChangeContent()
        {
            switch (_pageCount)
            {
                case 0:
                    Panel.Content = _control1;
                    label2.Content = "Enter a game name.";
                    break;
                case 1:
                    Panel.Content = _control2;
                    label2.Content = "Game Performance Configuration.";
                    break;

            }
        }
    }
}
