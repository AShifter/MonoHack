using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoHack.UI
{
    interface IWindowType : IGameComponent, IUpdateable, IDrawable
    {
        Control WindowPanel { get; set; }
        Control TitleBar { get; set; }
        Control Title { get; set; }
        Control btnClose { get; set; }
        Control btnMax { get; set; }
        Control btnMin { get; set; }

        bool TitleBarDrag { get; set; }
        event EventHandler TitleBarLMBDown;
        event EventHandler TitleBarLMBRelease;

        void TitleMouseDown(object sender, EventArgs e);
        void TitleMouseUp(object sender, EventArgs e);
    }
}
