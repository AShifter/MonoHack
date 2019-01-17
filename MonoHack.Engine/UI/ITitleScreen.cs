using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoHack.Engine.UI
{
    public interface ITitleScreen : IGameComponent, IDrawable, IUpdateable
    {
        // functions
        //void Initialize();
        //void Update(GameTime gameTime);
        //void Draw(GameTime gameTime);

        // events
        event EventHandler ScreenStart;
        event EventHandler ScreenEnd;

        // properties
        Color BackColor { get; set; }
    }
}
