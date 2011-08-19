using System;
using System.Windows;
using SlotGameGUI.Common;
using SlotGameGUI.Controls.Menu.NewGame;

namespace SlotGameGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Instance;

        public IGame Game { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
        }

        private void NewGameMenuItemClick(object sender, RoutedEventArgs e)
        {
            var newGame = new NewGameWindow() { Owner = this };
            newGame.ShowDialog();
        }

        private void ExitMenuItemClick(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void SlotGameGuiClosed(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }



    }
}
