using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoHack.Applications
{
    public interface IMonoHackApp : IGameComponent, IDrawable, IUpdateable
    {
        // functions
        void Initialize();
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);

        // events
        event EventHandler Close;
        event EventHandler Maximize;
        event EventHandler Minimize;

        // properties
        Rectangle AppArea { get; set; }
        String Text { get; set; }
        Texture2D Icon { get; set; }
    }
}
