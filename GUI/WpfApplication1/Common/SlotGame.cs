using System;
using System.Collections.Generic;
using System.Windows;
using SlotGameGUI.Common.Component;

namespace SlotGameGUI.Common
{
    public class SlotGame : IGame
    {
        public string GameName;

        public string Location;

        public string Resource;

        public string Output;

        private readonly List<IComponent> _components = new List<IComponent>();

        private List<Window> _windows = new List<Window>();

        public List<IComponent> Components
        {
            get { return _components; }
        }
        #region Implementation of IGame
        public void Save()
        {
            throw new NotImplementedException();
        }

        public void CreateConfiguration()
        {
            throw new NotImplementedException();
        }

        public void AddComponent(IComponent component)
        {
            _components.Add(component);
        }

        public void AddComponents(List<IComponent> components)
        {
            _components.AddRange(components);
        }

        public void RemoveComponent(string componentName)
        {
            foreach (var component in _components)
            {
                if (!component.Name.Equals(componentName)) continue;
                _components.Remove(component);
                return;
            }
        }

        public void Show()
        {
            var display = (Display)Components[0];
            foreach (var window in _windows)
            {
                window.Close();
            }
            _windows = new List<Window>();
            foreach (var screen in display.Screens)
            {
                var screens = System.Windows.Forms.Screen.AllScreens;


                var window = new Window();
                window.Width = screen.Resolution.Width;
                window.Height = screen.Resolution.Height;
                window.ResizeMode = ResizeMode.CanMinimize;
                window.WindowStartupLocation = WindowStartupLocation.Manual;
                window.Top = 0;
                if (screen.SystemIndex >= screens.Length)
                    window.Left = 0;
                else
                    window.Left = screens[screen.SystemIndex].Bounds.X;
                window.Show();

                _windows.Add(window);
                screen.DrawComponents();
            }

        }

        #endregion
    }
}
