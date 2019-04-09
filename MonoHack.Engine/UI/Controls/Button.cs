using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoHack.Engine.UI.Controls
{
    public class Button : Control
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

        public override event EventHandler OnHover;
        public override event EventHandler OnClick;
        public override event EventHandler OnLeave;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public Button()
        {
            this.OnClick += Click;
            this.OnHover += Hover;
            this.OnLeave += Leave;
        }

        public override void Initialize()
        {

        }

        public override void Update(GameTime gameTime)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && controlBounds.Contains(Mouse.GetState().Position))
            {
                OnClick?.Invoke(this, EventArgs.Empty);
            }
            else if (controlBounds.Contains(Mouse.GetState().Position))
            {
                OnHover?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                OnLeave?.Invoke(this, EventArgs.Empty);
            }
        }

        // Draw - Draw the control
        public override void Draw(GameTime gameTime)
        {
            if (visible && (int)theme.ControlStyle > 0)
            {
                spriteBatch.Begin();
                if ((int)theme.ControlStyle == 2)
                {
                    // Draw Border
                    spriteBatch.Draw(theme.BaseTexture, new Rectangle(new Point(
                         controlBounds.X - theme.BorderSize,
                         controlBounds.Y - theme.BorderSize),
                        new Point(
                         controlBounds.Width + theme.BorderSize * 2,
                         controlBounds.Height + theme.BorderSize * 2)),
                         theme.BorderColor * opacity);
                }

                if ((int)theme.ControlStyle == 3)
                {
                    // Draw Black
                    spriteBatch.Draw(theme.BaseTexture, new Rectangle(new Point(
                         controlBounds.X - 1,
                         controlBounds.Y - 1),
                        new Point(
                         controlBounds.Width + 3,
                         controlBounds.Height + 3)),
                         new Color(0, 0, 0) * opacity);

                    // Draw White
                    spriteBatch.Draw(theme.BaseTexture, new Rectangle(new Point(
                         controlBounds.X - 1,
                         controlBounds.Y - 1),
                        new Point(
                         controlBounds.Width + 2,
                         controlBounds.Height + 2)),
                         new Color(255, 255, 255) * opacity);

                    // Draw Dark Grey
                    spriteBatch.Draw(theme.BaseTexture, new Rectangle(new Point(
                         controlBounds.X,
                         controlBounds.Y),
                        new Point(
                         controlBounds.Width + 1,
                         controlBounds.Height + 1)),
                         new Color(128, 128, 128) * opacity);
                }
                // Draw Button
                spriteBatch.Draw(theme.BaseTexture, controlBounds, currentColor * opacity);

                // Draw X button
                spriteBatch.Draw(theme.BaseTexture, new Rectangle(controlBounds.X + 3, controlBounds.Y + 2, 2, 1), new Color(0, 0, 0) * opacity);
                spriteBatch.Draw(theme.BaseTexture, new Rectangle(controlBounds.X + 4, controlBounds.Y + 3, 2, 1), new Color(0, 0, 0) * opacity);
                spriteBatch.Draw(theme.BaseTexture, new Rectangle(controlBounds.X + 5, controlBounds.Y + 4, 4, 1), new Color(0, 0, 0) * opacity);
                spriteBatch.Draw(theme.BaseTexture, new Rectangle(controlBounds.X + 9, controlBounds.Y + 2, 2, 1), new Color(0, 0, 0) * opacity);
                spriteBatch.Draw(theme.BaseTexture, new Rectangle(controlBounds.X + 8, controlBounds.Y + 3, 2, 1), new Color(0, 0, 0) * opacity);
                spriteBatch.Draw(theme.BaseTexture, new Rectangle(controlBounds.X + 6, controlBounds.Y + 5, 2, 1), new Color(0, 0, 0) * opacity);
                spriteBatch.Draw(theme.BaseTexture, new Rectangle(controlBounds.X + 5, controlBounds.Y + 6, 4, 1), new Color(0, 0, 0) * opacity);
                spriteBatch.Draw(theme.BaseTexture, new Rectangle(controlBounds.X + 4, controlBounds.Y + 7, 2, 1), new Color(0, 0, 0) * opacity);
                spriteBatch.Draw(theme.BaseTexture, new Rectangle(controlBounds.X + 3, controlBounds.Y + 8, 2, 1), new Color(0, 0, 0) * opacity);
                spriteBatch.Draw(theme.BaseTexture, new Rectangle(controlBounds.X + 8, controlBounds.Y + 7, 2, 1), new Color(0, 0, 0) * opacity);
                spriteBatch.Draw(theme.BaseTexture, new Rectangle(controlBounds.X + 9, controlBounds.Y + 8, 2, 1), new Color(0, 0, 0) * opacity);

                // Draw Text
                spriteBatch.DrawString(theme.Font, text, new Vector2(
                    (controlBounds.X + controlBounds.Width / 2) - theme.Font.MeasureString(text).X / 2,
                    (controlBounds.Y + controlBounds.Height / 2) - theme.Font.MeasureString(text).Y / 2),
                    theme.TextColor * opacity);
                spriteBatch.End();
            }
        }

        // OnClick - Attached to Click event
        public void Click(object sender, EventArgs e)
        {
            currentColor = theme.ClickColor;
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