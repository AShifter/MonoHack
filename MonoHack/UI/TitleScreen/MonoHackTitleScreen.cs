using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoHack.UI.TitleScreen
{
    class MonoHackTitleScreen : ITitleScreen
    {
        // Local Properties
        private Color backColor = Color.Black;
        private IUIControl backPanel = new UI.Controls.Panel();
        private IUIControl monohackIcon = new UI.Controls.PictureBox();
        private IUIControl monoHackEngineLabel = new UI.Controls.Label();

        private int totalElapsedFrames = 0;
        private bool animationComplete = true;
        private int animationCount = 0;

        public Color BackColor
        {
            get => backColor;
            set => backColor = value;
        }

        public int DrawOrder => throw new NotImplementedException();

        public bool Visible => true;

        public bool Enabled => true;

        public int UpdateOrder => throw new NotImplementedException();

        public event EventHandler ScreenStart;
        public event EventHandler ScreenEnd;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public MonoHackTitleScreen(SpriteBatch _spriteBatch, ContentManager _content, GraphicsDevice _graphicsDevice)
        {
            ///
            /// backPanel
            ///
            backPanel.SpriteBatch = _spriteBatch;
            backPanel.Bounds = new Rectangle(new Point(0, 0), new Point(_graphicsDevice.Viewport.Width, _graphicsDevice.Viewport.Height));
            backPanel.Theme = new UI.Themes.DefaultTheme(_content);
            backPanel.Theme.BorderSize = 0;
            backPanel.Theme.ActiveColor = BackColor;

            // Preliminary setup
            monoHackEngineLabel.Text = "MonoHack Engine";
            monoHackEngineLabel.Theme = new UI.Themes.DefaultTheme(_content);
            monoHackEngineLabel.Theme.Font = _content.Load<SpriteFont>("UI/Font/Title");

            ///
            /// monohackIcon
            ///
            monohackIcon.SpriteBatch = _spriteBatch;
            monohackIcon.Image = _content.Load<Texture2D>("UI/Images/MonoHack_512x");
            monohackIcon.Bounds = new Rectangle(new Point(_graphicsDevice.Viewport.Width / 2 - monohackIcon.Image.Bounds.Width / 2,
                _graphicsDevice.Viewport.Height / 2 - monohackIcon.Image.Bounds.Width / 2 - (int)monoHackEngineLabel.Theme.Font.MeasureString(monoHackEngineLabel.Text).Y + 20),
                new Point(monohackIcon.Image.Bounds.Width, monohackIcon.Image.Bounds.Height));
            monohackIcon.Theme = new UI.Themes.DefaultTheme(_content);
            monohackIcon.Opacity = 0f;

            ///
            /// monoHackEngineLabel
            ///
            monoHackEngineLabel.SpriteBatch = _spriteBatch;
            monoHackEngineLabel.Bounds = new Rectangle(new Point(_graphicsDevice.Viewport.Width / 2 - (int)monoHackEngineLabel.Theme.Font.MeasureString(monoHackEngineLabel.Text).X / 2,
                _graphicsDevice.Viewport.Height / 2 + (int)monoHackEngineLabel.Theme.Font.MeasureString(monoHackEngineLabel.Text).Y + (int)monoHackEngineLabel.Theme.Font.MeasureString(monoHackEngineLabel.Text).Y + 20), new Point(0, 0));
            monoHackEngineLabel.Theme.BorderSize = 0;
            monoHackEngineLabel.Theme.TextColor = Color.White;
            monoHackEngineLabel.Opacity = 0f;
        }

        public void Initialize()
        {

        }

        public void Update(GameTime gameTime)
        {
            if (animationComplete)
            {
                totalElapsedFrames++;
            }

            if (monohackIcon.Opacity <= 1f && animationComplete == false && animationCount == 0)
            {
                monohackIcon.Opacity = monohackIcon.Opacity + 0.05f;
                monohackIcon.Bounds = new Rectangle(new Point(monohackIcon.Bounds.X, monohackIcon.Bounds.Y - 1), new Point(monohackIcon.Bounds.Width, monohackIcon.Bounds.Height));

                monoHackEngineLabel.Opacity = monoHackEngineLabel.Opacity + 0.05f;
                monoHackEngineLabel.Bounds = new Rectangle(new Point(monoHackEngineLabel.Bounds.X, monoHackEngineLabel.Bounds.Y - 1), new Point(monoHackEngineLabel.Bounds.Width, monoHackEngineLabel.Bounds.Height));

                if (Math.Round(monohackIcon.Opacity, 2) == 1f)
                {
                    animationComplete = true;
                    animationCount++;
                }
            }
            if (animationComplete == false && animationCount == 1)
            {
                //Math.Round(monohackIcon.Opacity) == 1f && 

                monohackIcon.Opacity = monohackIcon.Opacity - 0.05f;
                monohackIcon.Bounds = new Rectangle(new Point(monohackIcon.Bounds.X, monohackIcon.Bounds.Y - 1), new Point(monohackIcon.Bounds.Width, monohackIcon.Bounds.Height));

                monoHackEngineLabel.Opacity = monoHackEngineLabel.Opacity - 0.05f;
                monoHackEngineLabel.Bounds = new Rectangle(new Point(monoHackEngineLabel.Bounds.X, monoHackEngineLabel.Bounds.Y - 1), new Point(monoHackEngineLabel.Bounds.Width, monoHackEngineLabel.Bounds.Height));

                if (Math.Round(monohackIcon.Opacity, 2) == 0f)
                {
                    animationComplete = true;
                    animationCount++;
                }
            }

            if (totalElapsedFrames == 120)
            {
                animationComplete = false;
                totalElapsedFrames = 0;
            }

        }

        public void Draw(GameTime gameTime)
        {
            backPanel.Draw(gameTime);
            monohackIcon.Draw(gameTime);
            monoHackEngineLabel.Draw(gameTime);
        }
    }
}
