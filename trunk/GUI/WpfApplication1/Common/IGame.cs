using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlotGameGUI.Common.Component;

namespace SlotGameGUI.Common
{
    public interface IGame
    {
        void Save();
        void CreateConfiguration();
        void AddComponent(IComponent component);
        void AddComponents(List<IComponent> components);
        void RemoveComponent(String componentName);
        void Show();
    }
}
