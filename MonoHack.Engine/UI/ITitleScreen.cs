using System;
using Microsoft.Xna.Framework;

namespace MonoHack.Engine.UI
{
    public interface ITitleScreen : IGameComponent, IDrawable, IUpdateable
    {
        // events
        event EventHandler ScreenStart;
        event EventHandler ScreenEnd;

        // properties
        Color BackColor { get; set; }
    }
}
