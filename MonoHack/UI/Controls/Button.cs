using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoHack.UI.Controls
{
    public class Button : IUIControl
    {
        // Local Control Properties
        public SpriteBatch spriteBatch;
        public Rectangle controlBounds;
        public String text;
        public IUITheme theme;
        public Texture2D image;
        public Color currentColor;
        public bool visible = true;
        public bool active = true;
        public float opacity = 1f;

        SpriteBatch IUIControl.SpriteBatch
        {
            get => spriteBatch;
            set => spriteBatch = value;
        }

        Rectangle IUIControl.Bounds
        {
            get => controlBounds;
            set => controlBounds = value;
        }

        String IUIControl.Text
        {
            get => text;
            set => text = value;
        }

        public IUITheme Theme
        {
            get => theme;
            set => theme = value;
        }

        public Texture2D Image
        {
            get => image;
            set => image = value;
        }

        public Color Color
        {
            get => currentColor;
            set => currentColor = value;
        }

        public bool Active
        {
            get => active;
            set => active = value;
        }
        public float Opacity
        {
            get => opacity;
            set => opacity = value;
        }

        public int DrawOrder => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public int UpdateOrder => throw new NotImplementedException();

        public bool Visible => visible;

        public event EventHandler Hover;
        public event EventHandler Click;
        public event EventHandler Leave;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public Button()
        {
            // Don't do this in Update().
            this.Click += OnClick;
            this.Hover += OnHover;
            this.Leave += OnLeave;
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            if (Mouse.GetState().LeftButton == ButtonState.Pressed && controlBounds.Contains(Mouse.GetState().Position))
            {
                Click(this, EventArgs.Empty);
            }
            else if (controlBounds.Contains(Mouse.GetState().Position))
            {
                Hover(this, EventArgs.Empty);
            }
            else
            {
                Leave(this, EventArgs.Empty);
            }
        }

        // Draw - Draw the control
        public void Draw(GameTime gameTime)
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
                // Draw Text
                spriteBatch.DrawString(theme.Font, text, new Vector2(
                    (controlBounds.X + controlBounds.Width / 2) - theme.Font.MeasureString(text).X / 2,
                    (controlBounds.Y + controlBounds.Height / 2) - theme.Font.MeasureString(text).Y / 2),
                    theme.TextColor * opacity);
                spriteBatch.End();
            }
        }

        // OnClick - Attached to Click event
        public void OnClick(object sender, EventArgs e)
        {
            currentColor = theme.ClickColor;
        }

        // OnHover - Attached to Hover event
        public void OnHover(object sender, EventArgs e)
        {
            currentColor = theme.HoverColor;
        }

        // OnLeave - Attached to Leave event
        public void OnLeave(object sender, EventArgs e)
        {
            currentColor = theme.ActiveColor;
        }
    }
}