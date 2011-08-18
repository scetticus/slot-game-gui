using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Windows.Controls;
using System.Windows.Forms;
using TextBox = System.Windows.Controls.TextBox;
using UserControl = System.Windows.Controls.UserControl;


namespace WpfApplication1.Controls.Menu.NewGame
{
    /// <summary>
    /// Interaction logic for NewGameControl1.xaml
    /// </summary>
    public partial class NewGameControl1 : UserControl
    {
        public NewGameControl1()
        {
            InitializeComponent();
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
        }

        private void GameNameTextBoxTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)e.Source;
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

        private void BrowseButtonClick(object sender, System.Windows.RoutedEventArgs e)
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
