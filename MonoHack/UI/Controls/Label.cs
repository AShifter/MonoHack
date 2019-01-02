using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoHack.UI.Controls
{
    class Label : Control
    {
        // Local Control Properties
        public SpriteBatch spriteBatch;
        public Rectangle controlBounds;
        public String text;
        public SpriteFont font;
        public IUITheme theme;
        public Texture2D image;
        public Color currentColor;
        public bool visible = true;
        public bool active = true;
        public float opacity = 1f;

        public override SpriteBatch SpriteBatch
        {
            get => spriteBatch;
            set => spriteBatch = value;
        }

        public override Rectangle Bounds
        {
            get => controlBounds;
            set => controlBounds = value;
        }

        public override String Text
        {
            get => text;
            set => text = value;
        }

        public override SpriteFont Font
        {
            get => font;
            set => font = value;
        }

        public override IUITheme Theme
        {
            get => theme;
            set => theme = value;
        }

        public override Texture2D Image
        {
            get => image;
            set => image = value;
        }

        public override Color Color
        {
            get => currentColor;
            set => currentColor = value;
        }

        public override bool Active
        {
            get => active;
            set => active = value;
        }

        public override float Opacity
        {
            get => opacity;
            set => opacity = value;
        }

        public override event EventHandler OnClick;
        public override event EventHandler OnHover;
        public override event EventHandler OnLeave;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && controlBounds.Contains(Mouse.GetState().Position))
            {
                OnClick(this, EventArgs.Empty);
            }
            else if (controlBounds.Contains(Mouse.GetState().Position))
            {
                OnHover(this, EventArgs.Empty);
            }
            else
            {
                OnLeave(this, EventArgs.Empty);
            }
        }

        // Draw - Draw the control
        public override void Draw(GameTime gameTime)
        {
            if (visible)
            {
                currentColor = theme.ActiveColor;
                spriteBatch.Begin();
                // Draw Text
                spriteBatch.DrawString(font, text, new Vector2(controlBounds.X, controlBounds.Y), theme.TextColor * opacity);
                spriteBatch.End();
            }
        }
    }
}
