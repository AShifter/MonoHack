using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoHack.Engine.UI;
using MonoHack.Engine.UI.Controls;

namespace MonoHack.Engine.WindowTypes
{
    class ClassicWindow : IGameComponent, IUpdateable, IDrawable
    {
        GraphicsDevice graphicsDevice;
        SpriteBatch spriteBatch;
        MouseState mouseState;

        Control WindowPanel = new Panel();
        Control TitleBar = new Panel();
        Control Title = new Label();
        Control btnClose = new Button();
        Control btnMax = new Button();
        Control btnMin = new Button();

        Point dragHandle = new Point();

        Applications.IMonoHackApp app;

        bool TitleBarDrag;

        public event EventHandler TitleBarLMBRelease;
        public event EventHandler TitleBarLMBDown;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        public bool Enabled => true;

        public int UpdateOrder => 1;

        public int DrawOrder => 1;

        public bool Visible => true;

        public ClassicWindow(SpriteBatch _spriteBatch, ContentManager _content, GraphicsDevice _graphicsDevice, Applications.IMonoHackApp App)
        {
            spriteBatch = _spriteBatch;
            app = App;
            graphicsDevice = _graphicsDevice;
            this.TitleBarLMBRelease += TitleMouseUp;
            this.TitleBarLMBDown += TitleMouseDown;

            ///
            /// WindowPanel
            ///
            WindowPanel.SpriteBatch = spriteBatch;
            WindowPanel.Bounds = new Rectangle(new Point(50, 50), new Point(app.Bounds.Width, app.Bounds.Height + 26));
            WindowPanel.Theme = new Engine.UI.Themes.DefaultTheme(_content, _spriteBatch);
            WindowPanel.Theme.BorderSize = 4;
            WindowPanel.Theme.BorderColor = Color.FromNonPremultiplied(64, 64, 64, 255);

            ///
            /// TitleBar
            /// 
            TitleBar.SpriteBatch = spriteBatch;
            TitleBar.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X, WindowPanel.Bounds.Y), new Point(WindowPanel.Bounds.Width, 18));
            TitleBar.Theme = new Engine.UI.Themes.DefaultTheme(_content, _spriteBatch);
            TitleBar.Theme.ActiveColor = new Color(0, 0, 128);
            TitleBar.Theme.BorderSize = 0;

            ///
            /// Title
            ///
            Title.SpriteBatch = spriteBatch;
            Title.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + 5, WindowPanel.Bounds.Y + 4), new Point(0, 0));
            Title.Theme = new Engine.UI.Themes.DefaultTheme(_content, _spriteBatch);
            Title.Font = Title.Theme.Font;
            Title.Theme.TextColor = Color.White;
            Title.Text = App.Text;

            ///
            /// btnClose
            ///
            btnClose.SpriteBatch = spriteBatch;
            btnClose.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 17, WindowPanel.Bounds.Y + 3), new Point(13, 11));
            btnClose.Theme = new Engine.UI.Themes.DefaultTheme(_content, _spriteBatch);
            btnClose.Theme.BorderSize = 0;
            btnClose.Text = "";

            ///
            /// btnMax
            ///
            btnMax.SpriteBatch = spriteBatch;
            btnMax.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 35, WindowPanel.Bounds.Y + 3), new Point(13, 11));
            btnMax.Theme = new Engine.UI.Themes.DefaultTheme(_content, _spriteBatch);
            btnMax.Theme.BorderSize = 0;
            btnMax.Text = "";

            ///
            /// btnMin
            ///
            btnMin.SpriteBatch = spriteBatch;
            btnMin.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 51, WindowPanel.Bounds.Y + 3), new Point(13, 11));
            btnMin.Theme = new Engine.UI.Themes.DefaultTheme(_content, _spriteBatch);
            btnMin.Theme.BorderSize = 0;
            btnMin.Text = "";
        }

        public void Initialize()
        {
            
        }

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            btnClose.Update(gameTime);
            btnMax.Update(gameTime);
            btnMin.Update(gameTime);
            app.Update(gameTime);

            if (TitleBarDrag == false)
            {
                dragHandle = new Point(mouseState.X - WindowPanel.Bounds.X, mouseState.Y - WindowPanel.Bounds.Y);
            }

            if (mouseState.LeftButton == ButtonState.Pressed && TitleBar.Bounds.Contains(mouseState.Position) && !btnClose.Bounds.Contains(mouseState.Position) && !btnMax.Bounds.Contains(mouseState.Position) && !btnMin.Bounds.Contains(mouseState.Position))
            {
                TitleBarLMBDown(this, EventArgs.Empty);
            }
            else if (TitleBarDrag)
            {
                TitleBarLMBDown(this, EventArgs.Empty);
            }

            if (Mouse.GetState().LeftButton == ButtonState.Released)
            {
                TitleBarLMBRelease(this, EventArgs.Empty);
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

        void TitleMouseDown(object sender, EventArgs e)
        {
            TitleBarDrag = true;

            WindowPanel.Bounds = new Rectangle(new Point(mouseState.X - dragHandle.X, mouseState.Y - dragHandle.Y), WindowPanel.Bounds.Size);
            Title.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + 5, WindowPanel.Bounds.Y + 4), new Point(1, 1));
            TitleBar.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X, WindowPanel.Bounds.Y), new Point(WindowPanel.Bounds.Width, 18));
            btnClose.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 17, WindowPanel.Bounds.Y + 3), new Point(13, 11));
            btnMax.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 35, WindowPanel.Bounds.Y + 3), new Point(13, 11));
            btnMin.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 51, WindowPanel.Bounds.Y + 3), new Point(13, 11));

            app.Bounds = new Rectangle(WindowPanel.Bounds.Location, app.Bounds.Size);
        }

        void TitleMouseUp(object sender, EventArgs e)
        {
            TitleBarDrag = false;
        }
    }
}
