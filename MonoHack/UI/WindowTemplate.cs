using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoHack.UI
{
    class WindowTemplate
    {
        IUIControl WindowPanel = new Controls.Panel();
        IUIControl ContentPanel = new Controls.Panel();
        IUIControl TitleBar = new Controls.Panel();
        IUIControl Title = new Controls.Label();
        IUIControl btnClose = new Controls.Button();
        IUIControl btnMax = new Controls.Button();
        IUIControl btnMin = new Controls.Button();

        Applications.IMonoHackApp app;

        bool TitleBarDrag;
        public event EventHandler LMBRelease;
        public event EventHandler LMBDown;

        MouseState mouseState;

        public WindowTemplate(SpriteBatch spriteBatch, ContentManager Content, Applications.IMonoHackApp App)
        {
            app = App;

            ///
            /// WindowPanel
            ///
            WindowPanel.SpriteBatch = spriteBatch;
            WindowPanel.Bounds = new Rectangle(new Point(0, 0), new Point(app.AppArea.Width, app.AppArea.Height + 26));
            WindowPanel.Theme = new UI.Themes.DefaultTheme(Content);
            WindowPanel.Theme.BorderSize = 4;
            WindowPanel.Theme.BorderColor = Color.FromNonPremultiplied(64, 64, 64, 255);

            ///
            /// TitleBar
            /// 
            TitleBar.SpriteBatch = spriteBatch;
            TitleBar.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X, WindowPanel.Bounds.Y), new Point(WindowPanel.Bounds.Width, 26));
            TitleBar.Theme = new UI.Themes.DefaultTheme(Content);
            TitleBar.Theme.ActiveColor = Color.FromNonPremultiplied(64, 64, 64, 255);
            TitleBar.Theme.BorderSize = 0;

            ///
            /// ContentPanel
            ///
            ContentPanel.SpriteBatch = spriteBatch;
            ContentPanel.Bounds = new Rectangle(new Point(0, 0 - TitleBar.Bounds.Height), new Point(WindowPanel.Bounds.Width, WindowPanel.Bounds.Height + TitleBar.Bounds.Height));
            ContentPanel.Theme = new UI.Themes.DefaultTheme(Content);
            ContentPanel.Theme.BorderSize = 0;
            TitleBar.Theme.ActiveColor = Color.FromNonPremultiplied(255, 64, 64, 255);

            ///
            /// Title
            ///
            Title.SpriteBatch = spriteBatch;
            Title.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + 5, WindowPanel.Bounds.Y + 4), new Point(0, 0));
            Title.Theme = new UI.Themes.DefaultTheme(Content);
            Title.Theme.TextColor = Color.White;
            Title.Text = "MonoHack Window";

            ///
            /// btnClose
            ///
            btnClose.SpriteBatch = spriteBatch;
            btnClose.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 22, WindowPanel.Bounds.Y), new Point(22, 22));
            btnClose.Theme = new UI.Themes.DefaultTheme(Content);
            btnClose.Theme.BorderSize = 0;
            btnClose.Theme.ActiveColor = Color.Black;
            btnClose.Text = "";

            ///
            /// btnMax
            ///
            btnMax.SpriteBatch = spriteBatch;
            btnMax.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 48, WindowPanel.Bounds.Y), new Point(22, 22));
            btnMax.Theme = new UI.Themes.DefaultTheme(Content);
            btnMax.Theme.BorderSize = 0;
            btnMax.Theme.ActiveColor = Color.Black;
            btnMax.Text = "";

            ///
            /// btnMin
            ///
            btnMin.SpriteBatch = spriteBatch;
            btnMin.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 74, WindowPanel.Bounds.Y), new Point(22, 22));
            btnMin.Theme = new UI.Themes.DefaultTheme(Content);
            btnMin.Theme.BorderSize = 0;
            btnMin.Theme.ActiveColor = Color.Black;
            btnMin.Text = "";

            this.LMBRelease += TitleMouseUp;
            this.LMBDown += TitleMouseDown;
        }

        void TitleMouseDown(object sender, EventArgs e)
        {
            TitleBarDrag = true;
            Point MouseLoc = Mouse.GetState().Position;
            WindowPanel.Bounds = new Rectangle(new Point(MouseLoc.X - 50, MouseLoc.Y - 10), WindowPanel.Bounds.Size);
            TitleBar.Bounds = new Rectangle(new Point(MouseLoc.X - 50, MouseLoc.Y - 10), TitleBar.Bounds.Size);
            Title.Bounds = new Rectangle(new Point(MouseLoc.X - 45, MouseLoc.Y - 6), btnClose.Bounds.Size);
        }

        void TitleMouseUp(object sender, EventArgs e)
        {
            TitleBarDrag = false;
        }

        public void Update(GameTime gameTime)
        {
            btnClose.Update(gameTime);
            btnMax.Update(gameTime);
            btnMin.Update(gameTime);

            Title.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + 5, WindowPanel.Bounds.Y + 4), new Point(1, 1));
            TitleBar.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X, WindowPanel.Bounds.Y), new Point(WindowPanel.Bounds.Width, 26));
            btnClose.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 22, WindowPanel.Bounds.Y), new Point(22, 22));
            btnMax.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 48, WindowPanel.Bounds.Y), new Point(22, 22));
            btnMin.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 74, WindowPanel.Bounds.Y), new Point(22, 22));

            app.AppArea = new Rectangle(WindowPanel.Bounds.Location, app.AppArea.Size);

             mouseState = Mouse.GetState();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && TitleBar.Bounds.Contains(mouseState.Position) && !btnClose.Bounds.Contains(mouseState.Position) && !btnMax.Bounds.Contains(mouseState.Position) && !btnMin.Bounds.Contains(mouseState.Position))
            {
                LMBDown(this, EventArgs.Empty);
            }
            else if (TitleBarDrag)
            {
                LMBDown(this, EventArgs.Empty);
            }

            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                LMBRelease(this, EventArgs.Empty);
            }
        }

        public void Draw(GameTime gameTime)
        {
            WindowPanel.Draw(gameTime);
            TitleBar.Draw(gameTime);
            Title.Draw(gameTime);
            btnClose.Draw(gameTime);
            btnMax.Draw(gameTime);
            btnMin.Draw(gameTime);
            app.Draw(gameTime);
        }
    }
}
