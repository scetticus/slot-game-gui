using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlotGameGUI.Controls.Menu.NewGame;

namespace SlotGameGUI.Common.Component
{
    public class Connector : IComponent
    {
        #region Implementation of IComponent

        public string Name
        { get; set; }

        #endregion

        public string ConnectorType;
        public string Host;
        public int Port;
        public int UpdateFrequency;
        public bool IsAutoConnect;
        public Connector(NewGameWindow window)
        {

        }
    }
}
