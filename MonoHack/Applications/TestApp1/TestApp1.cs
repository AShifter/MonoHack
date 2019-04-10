using System;
using MonoHack.Engine;
using MonoHack.Engine.UI;
using MonoHack.Engine.UI.Styles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoHack.Applications
{
    class TestApp1 : IMonoHackApp
    {
        // Making variables for instances of required classes.
        SpriteBatch spriteBatch;
        ContentManager content;

        // Local Variables
        Rectangle _bounds = new Rectangle(new Point(50, 50), new Point(400, 592));
        string _text;
        Texture2D _icon;

        // Naming all of the Controls in this Application.
        Control TestLabel = new Engine.UI.Controls.Label();
        Control Cbx1 = new Engine.UI.Controls.Checkbox();
        Control Btn1 = new Engine.UI.Controls.Button();
        Control Lbl2 = new Engine.UI.Controls.Label();
        Control Pbx1 = new Engine.UI.Controls.PictureBox();

        // Size of the Application, as a Point, excluding all borders and title bar. Inherited from IMonoHackApp.
        public Rectangle Bounds
        {
            get => _bounds;
            set => _bounds = value;
        }

        // Text that the Application shows as a title. Inherited from IMonoHack.
        public string Text
        {
            get => "MonoHack 0.1a Demo";
            set => _text = value;
        }

        // The Icon of this Application, to be shown in the title bar. Inherited from IMonoHack.
        public Texture2D Icon
        {
            get => _icon;
            set => _icon = value;
        }

        // Draw order of the window. Inherited from IDrawable.
        public int DrawOrder => 5;

        // If this Application is Visible. Inherited from IMonoHack.
        bool IDrawable.Visible => true;

        // If this Application is Enabled. Inherited from IUpdateable.
        public bool Enabled => true;

        // UpdateOrder of this Application. Inherited from IUpdateable.
        public int UpdateOrder => 1;

        // Close EventHandler for this App's Window. Inherited from IMonoHackApp.
        public event EventHandler Close;

        // Maximize EventHandler for this App's Window. Inherited from IMonoHackApp.
        public event EventHandler Maximize;

        // Minimize EventHandler for this App's Window. Inherited from IMonoHackApp.
        public event EventHandler Minimize;

        // DrawOrderChanged EventHandler for this Application. Inherited from IDrawable.
        public event EventHandler<EventArgs> DrawOrderChanged;

        // VisibleChanged EventHandler for this Application. Inherited from IDrawable.
        public event EventHandler<EventArgs> VisibleChanged;

        // EnableChanged EventHandler for this Application. Inherited from IUpdateable.
        public event EventHandler<EventArgs> EnabledChanged;

        // UpdateOrderChanged EventHandler for this Application. Inherited from IUpdateable.
        public event EventHandler<EventArgs> UpdateOrderChanged;

        // This Application's Constructor.
        public TestApp1(SpriteBatch _spriteBatch, ContentManager _content)
        {
            spriteBatch = _spriteBatch;
            content = _content;

            ///
            /// TestLabel
            ///
            TestLabel.SpriteBatch = spriteBatch;
            TestLabel.Text = "Welcome to the MonoHack 0.1a Demo! Here's what I\nhave so far. Mess with controls down there and\ncheck your discord profile; Discord RPC is\nexperimental but should be working.\n\nNote: Try dragging this window around!\nContext buttons are not yet functional.";
            TestLabel.Theme = new Engine.UI.Themes.ClassicTheme(content, spriteBatch);
            TestLabel.Font = TestLabel.Theme.Font;

            ///
            /// Cbx1
            ///
            Cbx1.SpriteBatch = spriteBatch;
            Cbx1.Text = "Checkbox! This one is currently Unchecked.";
            Cbx1.Theme = new Engine.UI.Themes.ClassicTheme(content, spriteBatch);
            Cbx1.Font = TestLabel.Theme.Font;
            Cbx1.Theme.ActiveColor = Color.White;

            ///
            /// Btn1
            ///
            Btn1.SpriteBatch = spriteBatch;
            Btn1.Text = "Look, a Button!";
            Btn1.Bounds = new Rectangle(new Point(_bounds.Location.X + 8, _bounds.Location.Y + 160 + 26), new Point(150, 25));
            Btn1.Theme = new Engine.UI.Themes.ClassicTheme(content, spriteBatch);
            Btn1.Font = TestLabel.Theme.Font;

            ///
            /// Lbl2
            ///
            Lbl2.SpriteBatch = spriteBatch;
            Lbl2.Text = "MouseDown Event fired!";
            Lbl2.Opacity = 0f;
            Lbl2.Theme = new Engine.UI.Themes.ClassicTheme(content, spriteBatch);
            Lbl2.Font = TestLabel.Theme.Font;

            ///
            /// Pbx1
            ///
            Pbx1.SpriteBatch = spriteBatch;
            Pbx1.Theme = new Engine.UI.Themes.ClassicTheme(content, spriteBatch);
            Pbx1.Image = _content.Load<Texture2D>("UI/Images/monohack_512x");

            Btn1.OnClick += (s, e) => Btn1.Theme.ControlStyle = ControlStyles.Indent;
            Btn1.OnLeave += (s, e) => Btn1.Theme.ControlStyle = ControlStyles.Popup;
        }

        // Initialize Method. Inherited from IGameComponent.
        public void Initialize()
        {

        }

        // Update Method. Inherited from IUpdateable.
        public void Update(GameTime gameTime)
        {
            TestLabel.Bounds = new Rectangle(new Point(_bounds.Location.X + 8, _bounds.Location.Y + 5 + 26), new Point(1, 1));
            Cbx1.Bounds = new Rectangle(new Point(_bounds.Location.X + 8, _bounds.Location.Y + 130 + 26), new Point(16, 16));
            Btn1.Bounds = new Rectangle(new Point(_bounds.Location.X + 8, _bounds.Location.Y + 160 + 26), new Point(150, 25));
            Lbl2.Bounds = new Rectangle(new Point(_bounds.Location.X + 168, _bounds.Location.Y + 163 + 26), new Point(1, 1));
            Pbx1.Bounds = new Rectangle(new Point(_bounds.Location.X + 8, _bounds.Location.Y + 200 + 26), new Point(384, 384));

            Cbx1.Update(gameTime);
            Btn1.Update(gameTime);

            if (Cbx1.Active)
            {
                Cbx1.Text = "Checkbox! This one is currently Checked.";
            }
            else
            {
                Cbx1.Text = "Checkbox! This one is currently Unchecked.";
            }
        }

        // Draw Method. Inherited from IDrawable.
        public void Draw(GameTime gameTime)
        {
            TestLabel.Draw(gameTime);
            Cbx1.Draw(gameTime);
            Btn1.Draw(gameTime);
            Lbl2.Draw(gameTime);
            Pbx1.Draw(gameTime);
        }
    }
}
