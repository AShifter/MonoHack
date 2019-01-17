using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoHack.Engine.UI;
using MonoHack.Engine.UI.Controls;

namespace MonoHack.Engine.WindowTypes
{
    class GameWindow : IGameComponent, IUpdateable, IDrawable
    {
        Control WindowPanel = new Panel();
        Control TitleBar = new Panel();
        Control Title = new Label();
        Control btnClose = new Button();
        Control btnMax = new Button();
        Control btnMin = new Button();

        RenderTarget2D windowTarget;

        Applications.IMonoHackApp app;

        GraphicsDevice graphicsDevice;

        bool TitleBarDrag;
        public event EventHandler TitleBarLMBRelease;
        public event EventHandler TitleBarLMBDown;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;

        SpriteBatch spriteBatch;

        MouseState mouseState;

        public bool Enabled => true;

        public int UpdateOrder => 5;

        public int DrawOrder => 5;

        public bool Visible => true;

        public GameWindow(SpriteBatch _spriteBatch, ContentManager _content, GraphicsDevice _graphicsDevice, Applications.IMonoHackApp App)
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
            WindowPanel.Theme = new MonoHack.Engine.UI.Themes.DefaultTheme(_content, _spriteBatch);
            WindowPanel.Theme.BorderSize = 4;
            WindowPanel.Theme.BorderColor = Color.FromNonPremultiplied(64, 64, 64, 255);

            ///
            /// TitleBar
            /// 
            TitleBar.SpriteBatch = spriteBatch;
            TitleBar.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X, WindowPanel.Bounds.Y), new Point(WindowPanel.Bounds.Width, 26));
            TitleBar.Theme = new MonoHack.Engine.UI.Themes.DefaultTheme(_content, _spriteBatch);
            TitleBar.Theme.ActiveColor = Color.FromNonPremultiplied(64, 64, 64, 255);
            TitleBar.Theme.BorderSize = 0;

            ///
            /// Title
            ///
            Title.SpriteBatch = spriteBatch;
            Title.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + 5, WindowPanel.Bounds.Y + 4), new Point(0, 0));
            Title.Theme = new MonoHack.Engine.UI.Themes.DefaultTheme(_content, _spriteBatch);
            Title.Font = Title.Theme.Font;
            Title.Theme.TextColor = Color.White;
            Title.Text = App.Text;

            ///
            /// btnClose
            ///
            btnClose.SpriteBatch = spriteBatch;
            btnClose.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 22, WindowPanel.Bounds.Y), new Point(22, 22));
            btnClose.Theme = new MonoHack.Engine.UI.Themes.DefaultTheme(_content, _spriteBatch);
            btnClose.Theme.BorderSize = 0;
            btnClose.Theme.ActiveColor = Color.Black;
            btnClose.Text = "";

            ///
            /// btnMax
            ///
            btnMax.SpriteBatch = spriteBatch;
            btnMax.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 48, WindowPanel.Bounds.Y), new Point(22, 22));
            btnMax.Theme = new MonoHack.Engine.UI.Themes.DefaultTheme(_content, _spriteBatch);
            btnMax.Theme.BorderSize = 0;
            btnMax.Theme.ActiveColor = Color.Black;
            btnMax.Text = "";

            ///
            /// btnMin
            ///
            btnMin.SpriteBatch = spriteBatch;
            btnMin.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 74, WindowPanel.Bounds.Y), new Point(22, 22));
            btnMin.Theme = new MonoHack.Engine.UI.Themes.DefaultTheme(_content, _spriteBatch);
            btnMin.Theme.BorderSize = 0;
            btnMin.Theme.ActiveColor = Color.Black;
            btnMin.Text = "";

            // windowTarget = new RenderTarget2D(graphicsDevice, app.Bounds.Width, app.Bounds.Height, false, SurfaceFormat.Color, DepthFormat.Depth24, 0, RenderTargetUsage.PreserveContents);
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

            // int test = (int)(Math.Sqrt((mouseState.Position.X - WindowPanel.Bounds.X) ^ 2) * 22.5);

            //Console.WriteLine(test);

            WindowPanel.Bounds = new Rectangle(new Point(mouseState.Position.X, mouseState.Position.Y), WindowPanel.Bounds.Size);
            Title.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + 5, WindowPanel.Bounds.Y + 4), new Point(1, 1));
            TitleBar.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X, WindowPanel.Bounds.Y), new Point(WindowPanel.Bounds.Width, 26));
            btnClose.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 22, WindowPanel.Bounds.Y), new Point(22, 22));
            btnMax.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 48, WindowPanel.Bounds.Y), new Point(22, 22));
            btnMin.Bounds = new Rectangle(new Point(WindowPanel.Bounds.X + WindowPanel.Bounds.Width - 74, WindowPanel.Bounds.Y), new Point(22, 22));

            app.Bounds = new Rectangle(WindowPanel.Bounds.Location, app.Bounds.Size);

            //TitleBar.Bounds = new Rectangle(new Point(TitleBar.Bounds.X + (mouseState.Position.X - TitleBar.Bounds.X), TitleBar.Bounds.Y + (mouseState.Position.Y - TitleBar.Bounds.Y)), TitleBar.Bounds.Size);
            //Title.Bounds = new Rectangle(new Point(mouseState.Position.X - 45, mouseState.Position.Y - 6), btnClose.Bounds.Size);
        }

        void TitleMouseUp(object sender, EventArgs e)
        {
            TitleBarDrag = false;
        }
    }
}
