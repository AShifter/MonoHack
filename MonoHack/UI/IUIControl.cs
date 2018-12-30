using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoHack.UI
{
    public interface IUIControl : IGameComponent, IDrawable, IUpdateable
    {
        // functions
        void OnClick(object sender, EventArgs e);
        void OnHover(object sender, EventArgs e);
        void OnLeave(object sender, EventArgs e);
        void Update(GameTime gameTime);
        void Draw(GameTime gameTime);

        // events
        event EventHandler Hover;
        event EventHandler Click;
        event EventHandler Leave;

        // properties
        SpriteBatch SpriteBatch { get; set; }
        Rectangle Bounds { get; set; }
        String Text { get; set; }
        Texture2D Image { get; set; }
        Color Color { get; set; }
        bool Active { get; set; }
        float Opacity { get; set; }
        IUITheme Theme { get; set; }
    }
}
