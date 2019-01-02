using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoHack.Applications
{
    public interface IMonoHackApp : IGameComponent, IDrawable, IUpdateable
    {
        // events
        event EventHandler Close;
        event EventHandler Maximize;
        event EventHandler Minimize;

        // properties
        Rectangle Bounds { get; set; }
        String Text { get; set; }
        Texture2D Icon { get; set; }
    }
}
