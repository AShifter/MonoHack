using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoHack.Engine.UI.Styles;
using MonoGame.Extended.BitmapFonts;

namespace MonoHack.Engine.UI.Themes
{
    public class DefaultTheme : IUITheme
    {
        Texture2D baseTexture;
        BitmapFont font;
        int borderSize;
        ControlStyles controlStyle;
        Color disableColor;
        Color activeColor;
        Color hoverColor;
        Color clickColor;
        Color borderColor;
        Color textColor;

        public DefaultTheme(ContentManager content, SpriteBatch spriteBatch)
        {
            baseTexture = content.Load<Texture2D>("UI/Images/Pixel");

            font = content.Load<BitmapFont>("UI/Font/Classic/ClassicReg");

            borderSize = 2;

            controlStyle = ControlStyles.Border;

            disableColor = Color.DimGray;
            activeColor = Color.White;
            hoverColor = Color.Gray;
            clickColor = Color.Black;
            borderColor = Color.Black;
            textColor = Color.Black;
        }

        public Texture2D BaseTexture
        {
            get => baseTexture;
        }

        public BitmapFont Font
        {
            get => font;
            set => font = value;
        }

        public int BorderSize
        {
            get => borderSize;
            set => borderSize = value;
        }

        public ControlStyles ControlStyle
        {
            get => controlStyle;
            set => controlStyle = value;
        }

        public Color DisableColor
        {
            get => disableColor;
            set => disableColor = value;
        }

        public Color ActiveColor
        {
            get => activeColor;
            set => activeColor = value;
        }

        public Color HoverColor
        {
            get => hoverColor;
            set => hoverColor = value;
        }

        public Color ClickColor
        {
            get => clickColor;
            set => clickColor = value;
        }

        public Color BorderColor
        {
            get => borderColor;
            set => borderColor = value;
        }

        public Color TextColor
        {
            get => textColor;
            set => textColor = value;
        }
    }
}
