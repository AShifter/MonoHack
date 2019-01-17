using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoHack.Engine.UI
{
    public interface IUITheme
    {
        // Texture2D baseTexture - Should always be a 1x1px white square.
        Texture2D BaseTexture { get; }

        // SpriteFont font - Font used for this theme.
        SpriteFont Font { get; set; }

        // int borderSize - Thickness of the border found around UI elements.
        int BorderSize { get; set;  }

        // Color disableColor - The background color of a disabled element.
        Color DisableColor { get; set; }

        // Color activeColor - The background color of an active element.
        Color ActiveColor { get; set; }

        // Color hoverColor - The background color of a hovered element.
        Color HoverColor { get; set; }

        // Color clickColor - The background color of a clicked element.
        Color ClickColor { get; set; }

        // Color borderColor - The color of an element's border.
        Color BorderColor { get; set; }

        // Color textColor - The color of an element's text.
        Color TextColor { get; set; }
    }
}
