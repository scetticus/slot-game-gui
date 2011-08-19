using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Shapes;
using SlotGameGUI.Controls.Menu.NewGame;

namespace SlotGameGUI.Common.Component
{
    public class Display : IComponent
    {
        #region Implementation of IComponent

        public string Name { get; set; }

        #endregion

        public List<Screen> Screens { get; private set; }

        public Display(NewGameWindow window)
        {
            Screens = new List<Screen>();
            var control = window.Control2;
            foreach (var newGameControl2Control in control.Screens)
            {
                var screen = new Screen();
                screen.SystemIndex = newGameControl2Control.SystemIndexComboBox.SelectedIndex;
                if (newGameControl2Control.CPUSensitiveCheckBox.IsChecked != null)
                    screen.IsCpuSensitive = (bool)newGameControl2Control.CPUSensitiveCheckBox.IsChecked;
                if (newGameControl2Control.FullScreenCheckBox.IsChecked != null)
                    screen.IsFullScreen = (bool)newGameControl2Control.FullScreenCheckBox.IsChecked;
                if (newGameControl2Control.VSyncCheckBox.IsChecked != null)
                    screen.IsVSync = (bool)newGameControl2Control.VSyncCheckBox.IsChecked;

                var item = (ComboBoxItem) newGameControl2Control.ResolutionComboBox.SelectedItem;
                var str =item.Content.ToString().Split('x');
                var width = int.Parse(str[0]);
                var height = int.Parse(str[1]);
                screen.Resolution = new Rectangle { Width = width, Height = height };
                screen.TargetFps = int.Parse(newGameControl2Control.TargetedFramesPerSecondResultLabel.Content.ToString());

                var num = 0;
                if (newGameControl2Control.CPU1CheckBox.IsChecked != null)
                    if ((bool)newGameControl2Control.CPU1CheckBox.IsChecked)
                        num |= 1;
                if (newGameControl2Control.CPU2CheckBox.IsChecked != null)
                    if ((bool)newGameControl2Control.CPU2CheckBox.IsChecked)
                        num |= 2;
                if (newGameControl2Control.CPU3CheckBox.IsChecked != null)
                    if ((bool)newGameControl2Control.CPU3CheckBox.IsChecked)
                        num |= 4;
                if (newGameControl2Control.CPU4CheckBox.IsChecked != null)
                    if ((bool)newGameControl2Control.CPU4CheckBox.IsChecked)
                        num |= 8;
                if (num == 0)
                    num = -1;
                screen.CpuAffinity = num;

                Screens.Add(screen);
            }
        }

    }
    public class Screen
    {
        public int SystemIndex;
        public Rectangle Resolution;
        public bool IsFullScreen;
        public bool IsVSync;
        public bool IsCpuSensitive;
        public int TargetFps;
        public int CpuAffinity;

        public List<IVisbleComponent> Component = new List<IVisbleComponent>();

        public void DrawComponents()
        {
        }
    }
}
