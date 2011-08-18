using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Controls;


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
                if (!Regex.IsMatch(str, "*[0-9 a-z A-Z]"))
                {
                    e.Handled = true;
                    textBox.Text = 
                    return;
                }
            }


            var lastSeparatorIndex = LocationTextBox.Text.LastIndexOf(@"\");
            var temp = LocationTextBox.Text.Substring(0, lastSeparatorIndex + 1);
            LocationTextBox.Text = temp + textBox.Text;
        }
    }
}
