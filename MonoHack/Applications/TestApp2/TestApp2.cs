using System;
using MonoHack.Engine;
using MonoHack.Engine.UI;
using MonoHack.Engine.UI.Styles;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using MonoHack.Engine.UI.Controls;

namespace MonoHack.Applications
{
    class TestApp2 : IMonoHackApp
    {

        Control label = new Label();

        // Making variables for instances of required classes.
        SpriteBatch spriteBatch;
        ContentManager content;

        // Local Variables
        Rectangle _bounds = new Rectangle(new Point(50, 50), new Point(200, 100));
        string _text;
        Texture2D _icon;

        // Naming all of the Controls in this Application.
 

        // Size of the Application, as a Point, excluding all borders and title bar. Inherited from IMonoHackApp.
        public Rectangle Bounds
        {
            get => _bounds;
            set => _bounds = value;
        }

        // Text that the Application shows as a title. Inherited from IMonoHack.
        public string Text
        {
            get => "Another Window";
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
        public TestApp2(SpriteBatch _spriteBatch, ContentManager _content)
        {
            spriteBatch = _spriteBatch;
            content = _content;

            label.SpriteBatch = _spriteBatch;
            label.Text = "testing";
            label.Bounds = new Rectangle(new Point(_bounds.Location.X + 8, _bounds.Location.Y + 40), new Point(0, 0));
            label.Theme = new Engine.UI.Themes.ClassicTheme(content, spriteBatch);
            label.Font = label.Theme.Font;
        }

        // Initialize Method. Inherited from IGameComponent.
        public void Initialize()
        {

        }

        // Update Method. Inherited from IUpdateable.
        public void Update(GameTime gameTime)
        {
            label.Bounds = new Rectangle(new Point(_bounds.Location.X + 8, _bounds.Location.Y + 40), new Point(0, 0));
        }

        // Draw Method. Inherited from IDrawable.
        public void Draw(GameTime gameTime)
        {
            label.Draw(gameTime);
        }
    }
}
