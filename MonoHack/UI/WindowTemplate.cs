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
        IUIControl TitleBar = new Controls.Panel();
        IUIControl Title = new Controls.Label();
        IUIControl btnClose = new Controls.Button();
        IUIControl btnMax = new Controls.Button();
        IUIControl btnMin = new Controls.Button();

        bool TitleBarDrag;
        public event EventHandler LMBRelease;
        public event EventHandler LMBDown;

        UI.IUIControl Btn1;
        UI.IUIControl Cbx1;
        UI.IUIControl Lbl1;
        UI.IUIControl Lbl2;
        UI.IUIControl Lbl3;
        UI.IUIControl Lbl4;
        UI.IUIControl Pnl1;
        UI.IUIControl Pbx1;

        public void SetupWindow(SpriteBatch spriteBatch, ContentManager Content)
        {
            ///
            /// WindowPanel
            ///
            WindowPanel.SpriteBatch = spriteBatch;
            WindowPanel.ControlBounds = new Rectangle(new Point(900, 50), new Point(300, 326));
            WindowPanel.Theme = new UI.Themes.DefaultTheme(Content);
            WindowPanel.Theme.BorderSize = 4;
            WindowPanel.Theme.BorderColor = Color.FromNonPremultiplied(64, 64, 64, 255);

            ///
            /// TitleBar
            /// 
            TitleBar.SpriteBatch = spriteBatch;
            TitleBar.ControlBounds = new Rectangle(new Point(WindowPanel.ControlBounds.X, WindowPanel.ControlBounds.Y), new Point(WindowPanel.ControlBounds.Width, 26));
            TitleBar.Theme = new UI.Themes.DefaultTheme(Content);
            TitleBar.Theme.ActiveColor = Color.FromNonPremultiplied(64, 64, 64, 255);
            TitleBar.Theme.BorderSize = 0;

            ///
            /// Title
            ///
            Title.SpriteBatch = spriteBatch;
            Title.ControlBounds = new Rectangle(new Point(WindowPanel.ControlBounds.X + 5, WindowPanel.ControlBounds.Y + 4), new Point(1, 1));
            Title.Theme = new UI.Themes.DefaultTheme(Content);
            Title.Theme.TextColor = Color.White;
            Title.Text = "MonoHack Window";

            ///
            /// btnClose
            ///
            btnClose.SpriteBatch = spriteBatch;
            btnClose.ControlBounds = new Rectangle(new Point(WindowPanel.ControlBounds.X + WindowPanel.ControlBounds.Width - 22, WindowPanel.ControlBounds.Y), new Point(22, 22));
            btnClose.Theme = new UI.Themes.DefaultTheme(Content);
            btnClose.Theme.BorderSize = 0;
            btnClose.Theme.ActiveColor = Color.Black;
            btnClose.Text = "";

            ///
            /// btnMax
            ///
            btnMax.SpriteBatch = spriteBatch;
            btnMax.ControlBounds = new Rectangle(new Point(WindowPanel.ControlBounds.X + WindowPanel.ControlBounds.Width - 48, WindowPanel.ControlBounds.Y), new Point(22, 22));
            btnMax.Theme = new UI.Themes.DefaultTheme(Content);
            btnMax.Theme.BorderSize = 0;
            btnMax.Theme.ActiveColor = Color.Black;
            btnMax.Text = "";

            ///
            /// btnMin
            ///
            btnMin.SpriteBatch = spriteBatch;
            btnMin.ControlBounds = new Rectangle(new Point(WindowPanel.ControlBounds.X + WindowPanel.ControlBounds.Width - 74, WindowPanel.ControlBounds.Y), new Point(22, 22));
            btnMin.Theme = new UI.Themes.DefaultTheme(Content);
            btnMin.Theme.BorderSize = 0;
            btnMin.Theme.ActiveColor = Color.Black;
            btnMin.Text = "";

            Btn1 = new UI.Controls.Button();

            Btn1.SpriteBatch = spriteBatch;
            Btn1.ControlBounds = new Rectangle(new Point(250, 250), new Point(150, 50));
            Btn1.Text = "I'm a button!";
            Btn1.Click += OnClick; // Moved from Update() so we don't do this every frame...
            Btn1.Theme = new UI.Themes.DefaultTheme(Content);

            Cbx1 = new UI.Controls.Checkbox();

            Cbx1.SpriteBatch = spriteBatch;
            Cbx1.ControlBounds = new Rectangle(new Point(50, 50), new Point(14, 14));
            Cbx1.Text = "This is a Checkbox!";
            Cbx1.Theme = new UI.Themes.DefaultTheme(Content);

            Lbl1 = new UI.Controls.Label();

            Lbl1.SpriteBatch = spriteBatch;
            Lbl1.ControlBounds = new Rectangle(new Point(500, 500), new Point(1, 1));
            Lbl1.Text = "Labels! They're typically used on filing cabinets.\nThis one happens to be placed right under a Panel.";
            Lbl1.Theme = new UI.Themes.DefaultTheme(Content);

            Lbl2 = new UI.Controls.Label();

            Lbl2.SpriteBatch = spriteBatch;
            Lbl2.ControlBounds = new Rectangle(new Point(100, 610), new Point(1, 1));
            Lbl2.Text = "A Picturebox!";
            Lbl2.Theme = new UI.Themes.DefaultTheme(Content);

            Lbl3 = new UI.Controls.Label();

            Lbl3.SpriteBatch = spriteBatch;
            Lbl3.ControlBounds = new Rectangle(new Point(50, 70), new Point(1, 1));
            Lbl3.Theme = new UI.Themes.DefaultTheme(Content);

            Lbl4 = new UI.Controls.Label();

            Lbl4.SpriteBatch = spriteBatch;
            Lbl4.ControlBounds = new Rectangle(new Point(250, 310), new Point(1, 1));
            Lbl4.Text = "Clicked!";
            Lbl4.Theme = new UI.Themes.DefaultTheme(Content);
            Lbl4.Visible = false;

            Pnl1 = new UI.Controls.Panel();

            Pnl1.SpriteBatch = spriteBatch;
            Pnl1.ControlBounds = new Rectangle(new Point(550, 180), new Point(300, 300));
            Pnl1.Theme = new UI.Themes.DefaultTheme(Content);

            Pbx1 = new UI.Controls.PictureBox();

            Pbx1.SpriteBatch = spriteBatch;
            Pbx1.ControlBounds = new Rectangle(new Point(100, 500), new Point(100, 100));
            Pbx1.Theme = new UI.Themes.DefaultTheme(Content);
            Pbx1.CurrentColor = Color.CornflowerBlue;
            Pbx1.Image = Content.Load<Texture2D>("UI/Images/MonoHack_512x");

            // Moved from Update().
            void testFunc(object sender, EventArgs e)
            {
                TitleBarDrag = false;
            }

            this.LMBRelease += testFunc;
            this.LMBDown += WindowMove;
        }

        public void Update(GameTime gameTime)
        {
            btnClose.Update(gameTime);
            btnMax.Update(gameTime);
            btnMin.Update(gameTime);

            Title.ControlBounds = new Rectangle(new Point(WindowPanel.ControlBounds.X + 5, WindowPanel.ControlBounds.Y + 4), new Point(1, 1));
            TitleBar.ControlBounds = new Rectangle(new Point(WindowPanel.ControlBounds.X, WindowPanel.ControlBounds.Y), new Point(WindowPanel.ControlBounds.Width, 26));
            btnClose.ControlBounds = new Rectangle(new Point(WindowPanel.ControlBounds.X + WindowPanel.ControlBounds.Width - 22, WindowPanel.ControlBounds.Y), new Point(22, 22));
            btnMax.ControlBounds = new Rectangle(new Point(WindowPanel.ControlBounds.X + WindowPanel.ControlBounds.Width - 48, WindowPanel.ControlBounds.Y), new Point(22, 22));
            btnMin.ControlBounds = new Rectangle(new Point(WindowPanel.ControlBounds.X + WindowPanel.ControlBounds.Width - 74, WindowPanel.ControlBounds.Y), new Point(22, 22));

            Btn1.Update(gameTime);
            Cbx1.Update(gameTime);

            MouseState mouseState = Mouse.GetState();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && TitleBar.ControlBounds.Contains(mouseState.Position) && !btnClose.ControlBounds.Contains(mouseState.Position) && !btnMax.ControlBounds.Contains(mouseState.Position) && !btnMin.ControlBounds.Contains(mouseState.Position))
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

            if (Cbx1.Active == true)
            {
                Lbl3.Text = "It's currently Checked.";
            }
            else
            {
                Lbl3.Text = "It's currently Unchecked.";
            }
        }

        public void WindowMove(object sender, EventArgs e)
        {
            TitleBarDrag = true;
            Point MouseLoc = Mouse.GetState().Position;
            WindowPanel.ControlBounds = new Rectangle(new Point(MouseLoc.X - 50, MouseLoc.Y - 10), WindowPanel.ControlBounds.Size);
            TitleBar.ControlBounds = new Rectangle(new Point(MouseLoc.X - 50, MouseLoc.Y - 10), TitleBar.ControlBounds.Size);
            Title.ControlBounds = new Rectangle(new Point(MouseLoc.X - 45, MouseLoc.Y - 6), btnClose.ControlBounds.Size);
        }

        public void Draw(GameTime gameTime)
        {
            Btn1.Draw();
            Cbx1.Draw();
            Lbl1.Draw();
            Lbl2.Draw();
            Lbl3.Draw();
            Lbl4.Draw();
            Pnl1.Draw();
            Pbx1.Draw();

            WindowPanel.Draw();
            TitleBar.Draw();
            Title.Draw();
            btnClose.Draw();
            btnMax.Draw();
            btnMin.Draw();
        }

        public void OnClick(object sender, EventArgs e)
        {
            Lbl4.Visible = true;
        }

    }
}
