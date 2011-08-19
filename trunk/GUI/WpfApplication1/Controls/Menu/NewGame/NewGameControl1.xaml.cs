using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using TextBox = System.Windows.Controls.TextBox;
using UserControl = System.Windows.Controls.UserControl;

namespace SlotGameGUI.Controls.Menu.NewGame
{
    /// <summary>
    /// Interaction logic for NewGameControl1.xaml
    /// </summary>
    public partial class NewGameControl1 : UserControl
    {
        public new Window Parent { get; set; }

        public NewGameControl1(Window parent)
        {
            Parent = parent;
            InitializeComponent();

            LanguageListBox.Items.Add(new ListBoxItem { Content = "zh-CHT", IsSelected = true });
            LanguageListBox.Items.Add(new ListBoxItem { Content = "en-US", IsSelected = false });
            LanguageListBox.Items.Add(new ListBoxItem { Content = "ja", IsSelected = false });
            LanguageListBox.Items.Add(new ListBoxItem { Content = "ko", IsSelected = false });

            CurrencyListBox.Items.Add(new ListBoxItem { Content = "USD", IsSelected = true });
            CurrencyListBox.Items.Add(new ListBoxItem { Content = "CNY", IsSelected = false });
            CurrencyListBox.Items.Add(new ListBoxItem { Content = "JPY", IsSelected = false });
            CurrencyListBox.Items.Add(new ListBoxItem { Content = "KER", IsSelected = false });

            Parent = parent;
        }

        private void LocationTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {

            var textBox = (TextBox)e.Source;

            if (string.IsNullOrEmpty(Path.GetDirectoryName(textBox.Text)) && string.IsNullOrEmpty(Path.GetPathRoot(textBox.Text)))
            {

                return;
            }
            ResourcesTextBox.Text = textBox.Text + @"\Resources";
            OutputTextBox.Text = textBox.Text + @"\bin";

            var window = (NewGameWindow)Parent;
            var str = GameNameTextBox == null ? "NewGame1" : GameNameTextBox.Text;
            if (File.Exists(textBox.Text + @"\" + str + ".slg"))
            {
                window.NextButton.IsEnabled = false;
                window.FinishButton.IsEnabled = false;
                window.label2.Content = "Game is already existed.";
                var brush = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                window.label2.Foreground = brush;
            }
            else
            {
                window.NextButton.IsEnabled = true;
                window.FinishButton.IsEnabled = true;
                window.label2.Content = "Enter a game name.";
                var brush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                window.label2.Foreground = brush;
            }
        }

        private void GameNameTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)e.Source;
            var window = (NewGameWindow)Parent;
            if (string.IsNullOrEmpty(textBox.Text))
            {
                window.NextButton.IsEnabled = false;
                window.FinishButton.IsEnabled = false;
                return;
            }
            window.NextButton.IsEnabled = true;
            window.FinishButton.IsEnabled = true;

            foreach (var textChange in e.Changes)
            {
                string str = textBox.Text.Substring(textChange.Offset, textChange.AddedLength);
                if (!Regex.IsMatch(str, "^[0-9 a-z A-Z]*$"))
                {
                    e.Handled = true;
                    textBox.Text = textBox.Text.Substring(0, textChange.Offset);
                    Console.Beep();
                    textBox.SelectionStart = textBox.Text.Length;
                    return;
                }
            }



            var lastSeparatorIndex = LocationTextBox.Text.LastIndexOf(@"\");
            var temp = LocationTextBox.Text.Substring(0, lastSeparatorIndex + 1);
            LocationTextBox.Text = temp + textBox.Text;


        }

        private void BrowseButtonClick(object sender, RoutedEventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            if (Directory.Exists(LocationTextBox.Text))
            {
                folderBrowserDialog.SelectedPath = LocationTextBox.Text;
            }
            else
            {
                string path = Path.GetPathRoot(LocationTextBox.Text);
                folderBrowserDialog.SelectedPath = path;
            }
            folderBrowserDialog.ShowDialog();
            if (!string.IsNullOrEmpty(folderBrowserDialog.SelectedPath))
            {
                if (folderBrowserDialog.SelectedPath.EndsWith(@"\"))
                    LocationTextBox.Text = folderBrowserDialog.SelectedPath + GameNameTextBox.Text;
                else
                    LocationTextBox.Text = folderBrowserDialog.SelectedPath + @"\" + GameNameTextBox.Text;
            }
        }
    }
}
