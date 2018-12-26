using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoHack.UI.Controls
{
    class Textbox : IUIControl
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

        // Draw - Draw the control
        public void Draw()
        {
            currentColor = theme.ActiveColor;
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
                // Draw Panel
                spriteBatch.Draw(theme.BaseTexture, controlBounds, currentColor);
                spriteBatch.End();
            }
        }

        public void Update(GameTime gameTime)
        {

            this.Click += OnClick;
            this.Hover += OnHover;
            this.Leave += OnLeave;

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

        public void OnClick(object sender, EventArgs e) { }

        public void OnHover(object sender, EventArgs e) { }

        public void OnLeave(object sender, EventArgs e) { }
    }
}
