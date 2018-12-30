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
    class Screen1 : DrawableGameComponent
    {
        //UI.IUIControl Btn1;
        //UI.IUIControl Cbx1;
        //UI.IUIControl Lbl1;
        //UI.IUIControl Lbl2;
        //UI.IUIControl Lbl3;
        //UI.IUIControl Lbl4;
        //UI.IUIControl Pnl1;
        //UI.IUIControl Pbx1;

        public Screen1(Game game) : base(game)
        {

        }

        public override void Initialize()
        {
            //Btn1 = new UI.Controls.Button();

            //Btn1.SpriteBatch = spriteBatch;
            //Btn1.ControlBounds = new Rectangle(new Point(250, 250), new Point(150, 50));
            //Btn1.Text = "I'm a button!";
            //Btn1.Click += OnClick; // Moved from Update() so we don't do this every frame...
            //Btn1.Theme = new UI.Themes.DefaultTheme(Content);

            //Cbx1 = new UI.Controls.Checkbox();

            //Cbx1.SpriteBatch = spriteBatch;
            //Cbx1.ControlBounds = new Rectangle(new Point(50, 50), new Point(14, 14));
            //Cbx1.Text = "This is a Checkbox!";
            //Cbx1.Theme = new UI.Themes.DefaultTheme(Content);

            //Lbl1 = new UI.Controls.Label();

            //Lbl1.SpriteBatch = spriteBatch;
            //Lbl1.ControlBounds = new Rectangle(new Point(500, 500), new Point(1, 1));
            //Lbl1.Text = "Labels! They're typically used on filing cabinets.\nThis one happens to be placed right under a Panel.";
            //Lbl1.Theme = new UI.Themes.DefaultTheme(Content);

            //Lbl2 = new UI.Controls.Label();

            //Lbl2.SpriteBatch = spriteBatch;
            //Lbl2.ControlBounds = new Rectangle(new Point(100, 610), new Point(1, 1));
            //Lbl2.Text = "A Picturebox!";
            //Lbl2.Theme = new UI.Themes.DefaultTheme(Content);

            //Lbl3 = new UI.Controls.Label();

            //Lbl3.SpriteBatch = spriteBatch;
            //Lbl3.ControlBounds = new Rectangle(new Point(50, 70), new Point(1, 1));
            //Lbl3.Theme = new UI.Themes.DefaultTheme(Content);

            //Lbl4 = new UI.Controls.Label();

            //Lbl4.SpriteBatch = spriteBatch;
            //Lbl4.ControlBounds = new Rectangle(new Point(250, 310), new Point(1, 1));
            //Lbl4.Text = "Clicked!";
            //Lbl4.Theme = new UI.Themes.DefaultTheme(Content);
            //Lbl4.Visible = false;

            //Pnl1 = new UI.Controls.Panel();

            //Pnl1.SpriteBatch = spriteBatch;
            //Pnl1.ControlBounds = new Rectangle(new Point(550, 180), new Point(300, 300));
            //Pnl1.Theme = new UI.Themes.DefaultTheme(Content);

            //Pbx1 = new UI.Controls.PictureBox();

            //Pbx1.SpriteBatch = spriteBatch;
            //Pbx1.ControlBounds = new Rectangle(new Point(100, 500), new Point(100, 100));
            //Pbx1.Theme = new UI.Themes.DefaultTheme(Content);
            //Pbx1.CurrentColor = Color.CornflowerBlue;
            //Pbx1.Image = Content.Load<Texture2D>("UI/Images/MonoHack_512x");
        }

        public void Update(GameTime gameTime)
        {
            //Btn1.Update(gameTime);
            //Cbx1.Update(gameTime);

            //MouseState mouseState = Mouse.GetState();

            //if (Cbx1.Active == true)
            //{
                //Lbl3.Text = "It's currently Checked.";
            //}
            //else
            //{
                //Lbl3.Text = "It's currently Unchecked.";
            //}
        }

        public override void Draw(GameTime gameTime)
        {
            //Btn1.Draw();
            //Cbx1.Draw();
            //Lbl1.Draw();
            //Lbl2.Draw();
            //Lbl3.Draw();
            //Lbl4.Draw();
            //Pnl1.Draw();
            //Pbx1.Draw();
        }

        public void OnClick(object sender, EventArgs e)
        {
            //Lbl4.Visible = true;
        }
    }
}
