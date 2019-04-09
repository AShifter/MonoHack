using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoHack.Engine.UI.Styles;

namespace MonoHack.Engine.UI
{
    public interface IUITheme
    {
        // Texture2D BaseTexture - Should always be a 1x1px white square.
        Texture2D BaseTexture { get; }

        // SpriteFont Font - Font used for this theme.
        SpriteFont Font { get; set; }

        // int BorderSize - Thickness of the border found around UI elements.
        int BorderSize { get; set;  }

        // ControlStyles ControlStyle - Control border style used in this theme.
        ControlStyles ControlStyle { get; set; }

        // Color DisableColor - The background color of a disabled element.
        Color DisableColor { get; set; }

        // Color ActiveColor - The background color of an active element.
        Color ActiveColor { get; set; }

        // Color HoverColor - The background color of a hovered element.
        Color HoverColor { get; set; }

        // Color ClickColor - The background color of a clicked element.
        Color ClickColor { get; set; }

        // Color BorderColor - The color of an element's border.
        Color BorderColor { get; set; }

        // Color TextColor - The color of an element's text.
        Color TextColor { get; set; }
    }
}
