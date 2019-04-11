using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.BitmapFonts;

namespace MonoHack.Engine.UI
{
    public abstract class Control : IGameComponent, IUpdateable, IDrawable
    {
        ///
        /// Local Properties
        ///
        SpriteBatch _spriteBatch;
        Rectangle _bounds;
        String _text;
        BitmapFont _font;
        Texture2D _image;
        Color _normalColor;
        Color _hoverColor;
        Color _clickColor;
        Color _borderColor;
        bool _active;
        int _borderSize;
        float _opacity;
        UI.IUITheme _theme;

        ///
        /// ???
        ///
        public abstract SpriteBatch SpriteBatch { get; set; }
        public abstract Rectangle Bounds { get; set; }
        public abstract String Text { get; set; }
        public abstract BitmapFont Font { get; set; }
        public abstract IUITheme Theme { get; set; }
        public abstract Texture2D Image { get; set; }
        public abstract Color Color { get; set; }
        public abstract bool Active { get; set; }
        public abstract float Opacity { get; set; }


        public int UpdateOrder => throw new NotImplementedException();

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => true;

        public bool Enabled => true;

        ///
        /// Class Functions
        ///

        // Initialize() - Inherited from IGameComponent
        public abstract void Initialize();

        // Update(GameTime gameTime) - Inherited from IUpdateable
        public abstract void Update(GameTime gameTime);

        // Draw(GameTime gameTime) - Inherited from IDrawable
        public abstract void Draw(GameTime gameTime);

        // events
        public abstract event EventHandler OnClick;
        public abstract event EventHandler OnHover;
        public abstract event EventHandler OnLeave;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
    }
}
