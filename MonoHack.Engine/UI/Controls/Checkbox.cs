using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoHack.Engine.UI.Controls
{
    class Checkbox : Control
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

        public MouseState prev;
        public MouseState curr = Mouse.GetState();

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

        public int DrawOrder => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public bool Visible => visible;

        public override event EventHandler OnClick;
        public override event EventHandler OnHover;
        public override event EventHandler OnLeave;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public Checkbox()
        {
            this.OnClick += Click;
            this.OnHover += Hover;
            this.OnLeave += Leave;
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime)
        {
            prev = curr;
            curr = Mouse.GetState();

            if (curr.LeftButton == ButtonState.Released && prev.LeftButton == ButtonState.Pressed && controlBounds.Contains(Mouse.GetState().Position))
            {
                prev = Mouse.GetState();
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

        public override void Draw(GameTime gameTime)
        {
            if (visible)
            {
                spriteBatch.Begin();
                // Draw Border
                spriteBatch.Draw(theme.BaseTexture, new Rectangle(new Point(
                     controlBounds.X - theme.BorderSize,
                     controlBounds.Y - theme.BorderSize),
                    new Point(
                     controlBounds.Width + theme.BorderSize * 2,
                     controlBounds.Height + theme.BorderSize * 2)),
                     theme.BorderColor * opacity);
                // Draw Button
                spriteBatch.Draw(theme.BaseTexture, controlBounds, currentColor * opacity);
                // Draw Inner Check
                if (Active)
                {
                    spriteBatch.Draw(theme.BaseTexture, new Rectangle(new Point(
                        (controlBounds.X + controlBounds.Width / 2) - (controlBounds.Width * 3 / 4) / 2,
                        (controlBounds.Y + controlBounds.Width / 2) - (controlBounds.Width * 3 / 4) / 2),
                        new Point(
                        controlBounds.Width * 3 / 4,
                        controlBounds.Height * 3 / 4)),
                        theme.BorderColor * opacity);
                }
                // Draw Text
                spriteBatch.DrawString(theme.Font, text, new Vector2(
                    (controlBounds.X + controlBounds.Width + 10),
                    (controlBounds.Y + controlBounds.Height / 2) - theme.Font.MeasureString(text).Y / 2),
                    theme.TextColor * opacity);
                spriteBatch.End();
            }
        }

        // OnClick - Attached to Click event
        public void Click(object sender, EventArgs e)
        {
            if (Active)
            {
                Active = false;
            }
            else
            {
                Active = true;
            }
            
        }

        // OnHover - Attached to Hover event
        public void Hover(object sender, EventArgs e)
        {
            currentColor = theme.HoverColor;
        }

        // OnLeave - Attached to Leave event
        public void Leave(object sender, EventArgs e)
        {
            currentColor = theme.ActiveColor;
        }
    }
}
