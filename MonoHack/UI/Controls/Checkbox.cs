using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoHack.UI.Controls
{
    class Checkbox : IUIControl
    {
        // Local Control Properties
        public SpriteBatch spriteBatch;
        public Rectangle controlBounds;
        public String text;
        public Boolean active;
        public Boolean visible = true;
        public Color currentColor;
        public Texture2D image;
        public IUITheme theme;

        public MouseState prev;
        public MouseState curr = Mouse.GetState();

        SpriteBatch IUIControl.SpriteBatch
        {
            get => spriteBatch;
            set => spriteBatch = value;
        }

        Rectangle IUIControl.ControlBounds
        {
            get => controlBounds;
            set => controlBounds = value;
        }

        String IUIControl.Text
        {
            get => text;
            set => text = value;
        }

        public Boolean Active
        {
            get => active;
            set => active = value;
        }

        public Boolean Visible
        {
            get => visible;
            set => visible = value;
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

        public Color CurrentColor
        {
            get => currentColor;
            set => currentColor = value;
        }

        public event EventHandler Hover;
        public event EventHandler Click;
        public event EventHandler Leave;

        public Checkbox()
        {
            this.Click += OnClick;
            this.Hover += OnHover;
            this.Leave += OnLeave;
        }

        public void Draw()
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
                     theme.BorderColor);
                // Draw Button
                spriteBatch.Draw(theme.BaseTexture, controlBounds, currentColor);
                // Draw Inner Check
                if (Active)
                {
                    spriteBatch.Draw(theme.BaseTexture, new Rectangle(new Point(
                        (controlBounds.X + controlBounds.Width / 2) - (controlBounds.Width * 3 / 4) / 2,
                        (controlBounds.X + controlBounds.Width / 2) - (controlBounds.Width * 3 / 4) / 2),
                        new Point(
                        controlBounds.Width * 3 / 4,
                        controlBounds.Height * 3 / 4)),
                        theme.BorderColor);
                }
                // Draw Text
                spriteBatch.DrawString(theme.Font, text, new Vector2(
                    (controlBounds.X + controlBounds.Width + 10),
                    (controlBounds.Y + controlBounds.Height / 2) - theme.Font.MeasureString(text).Y / 2),
                    theme.TextColor);
                spriteBatch.End();
            }
        }

        public void Update(GameTime gameTime)
        {
            prev = curr;
            curr = Mouse.GetState();

            if (curr.LeftButton == ButtonState.Released && prev.LeftButton == ButtonState.Pressed && controlBounds.Contains(Mouse.GetState().Position))
            {
                prev = Mouse.GetState();
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

        // OnClick - Attached to Click event
        public void OnClick(object sender, EventArgs e)
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
