using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoHack.Applications;

namespace MonoHack.UI
{
    class TestApp1 : IMonoHackApp
    {
        // Making variables for instances of required classes.
        SpriteBatch spriteBatch;
        ContentManager content;

        // Local Variables
        Rectangle _appArea;
        string _text;
        Texture2D _icon;

        // Naming all of the Controls in this Application.
        IUIControl TestLabel = new UI.Controls.Label();

        // Size of the Application, as a Point, excluding all borders and title bar. Inherited from IMonoHackApp.
        public Rectangle AppArea
        {
            get => new Rectangle(new Point(100, 100), new Point(400, 250));
            set => _appArea = value;
        }

        // Text that the Application shows as a title. Inherited from IMonoHack.
        public string Text
        {
            get => "Test Application 1";
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
        }

        // Initialize Method. Inherited from IGameComponent.
        public void Initialize()
        {

        }

        // Update Method. Inherited from IUpdateable.
        public void Update(GameTime gameTime)
        {
            TestLabel.Bounds = new Rectangle(new Point(_appArea.Location.X + 5, _appArea.Location.Y + 5), new Point(1, 1));
        }

        // Draw Method. Inherited from IDrawable.
        public void Draw(GameTime gameTime)
        {
            TestLabel.SpriteBatch = spriteBatch;
            TestLabel.Bounds = new Rectangle(new Point(_appArea.Location.X + 5, _appArea.Location.Y + 5 + 26), new Point(1, 1));
            TestLabel.Text = "Testing Label 1.";
            TestLabel.Theme = new UI.Themes.DefaultTheme(content);

            TestLabel.Draw(gameTime);
        }
    }
}
