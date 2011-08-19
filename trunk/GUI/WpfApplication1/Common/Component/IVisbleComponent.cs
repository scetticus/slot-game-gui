using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SlotGameGUI.Common.Component
{
    public interface IVisbleComponent : IComponent
    {
        int SystemIndex { get; set; }
    }
}
