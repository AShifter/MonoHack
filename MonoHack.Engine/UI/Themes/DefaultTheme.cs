using System;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonoHack.Engine.UI.Themes
{
    class DefaultTheme : IUITheme
    {
        Texture2D baseTexture;
        SpriteFont font;
        int borderSize;
        Color disableColor;
        Color activeColor;
        Color hoverColor;
        Color clickColor;
        Color borderColor;
        Color textColor;

        public DefaultTheme(ContentManager content, SpriteBatch spriteBatch)
        {
            baseTexture = content.Load<Texture2D>("UI/Images/Pixel");
            font = content.Load<SpriteFont>("UI/Font/Main");

            borderSize = 2;
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

        public SpriteFont Font
        {
            get => font;
            set => font = value;
        }

        public int BorderSize
        {
            get => borderSize;
            set => borderSize = value;
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
