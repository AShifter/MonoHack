using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoHack.UI
{
    public interface IUIControl
    {
        // functions
        void OnClick(object sender, EventArgs e);
        void OnHover(object sender, EventArgs e);
        void OnLeave(object sender, EventArgs e);
        void Update(GameTime gameTime);
        void Draw();

        // events
        event EventHandler Hover;
        event EventHandler Click;
        event EventHandler Leave;

        // properties
        SpriteBatch SpriteBatch { get; set; }
        Rectangle ControlBounds { get; set; }
        String Text { get; set; }
        Boolean Active { get; set; }
        Boolean Visible { get; set; }
        Texture2D Image { get; set; }
        Color CurrentColor { get; set; }
        IUITheme Theme { get; set; }
    }
}
