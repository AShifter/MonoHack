using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoHack.Engine.UI.TitleScreen
{
    class MonoHackTitleScreen : ITitleScreen
    {
        // Local Properties
        private UI.IUITheme mainTheme;
        private Color backColor = Color.Black;
        private SpriteBatch spriteBatch;
        private ContentManager content;
        private GraphicsDevice graphicsDevice;

        // TitleScreen Scene 1 Controls
        private Control backPanel = new UI.Controls.Panel();
        private Control monohackIcon = new UI.Controls.PictureBox();
        private Control monoHackEngineLabel = new UI.Controls.Label();

        // TitleScreen Scene 2 Controls
        private Control aGameBy = new UI.Controls.Label();
        private Control ashifter = new UI.Controls.Label();
        private Control andCommunity = new UI.Controls.Label();

        private int totalElapsedFrames = 0;
        private bool animationComplete = true;
        private int animationCount = -1;

        public Color BackColor
        {
            get => backColor;
            set => backColor = value;
        }

        public int DrawOrder => 5;

        public bool Visible => true;

        public bool Enabled => true;

        public int UpdateOrder => 6;

        public event EventHandler ScreenStart;
        public event EventHandler ScreenEnd;
        public event EventHandler<EventArgs> DrawOrderChanged;
        public event EventHandler<EventArgs> VisibleChanged;
        public event EventHandler<EventArgs> EnabledChanged;
        public event EventHandler<EventArgs> UpdateOrderChanged;

        public MonoHackTitleScreen(SpriteBatch _spriteBatch, ContentManager _content, GraphicsDevice _graphicsDevice)
        {
            spriteBatch = _spriteBatch;
            content = _content;
            graphicsDevice = _graphicsDevice;
            mainTheme = new UI.Themes.DefaultTheme(_content, _spriteBatch);
        }

        public void Initialize()
        {
            ///
            /// backPanel
            ///
            backPanel.SpriteBatch = spriteBatch;
            backPanel.Bounds = new Rectangle(new Point(0, 0), new Point(graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height));
            backPanel.Theme = mainTheme;
            backPanel.Theme.BorderSize = 0;
            backPanel.Theme.ActiveColor = BackColor;

            // Preliminary setup
            monoHackEngineLabel.Text = "MonoHack Engine";
            monoHackEngineLabel.Theme = mainTheme;
            monoHackEngineLabel.Font = content.Load<SpriteFont>("UI/Font/H2");

            ///
            /// monohackIcon
            ///
            monohackIcon.SpriteBatch = spriteBatch;
            monohackIcon.Image = content.Load<Texture2D>("UI/Images/MonoHack_512x");
            monohackIcon.Bounds = new Rectangle(new Point(graphicsDevice.Viewport.Width / 2 - monohackIcon.Image.Bounds.Width / 2,
                graphicsDevice.Viewport.Height / 2 - monohackIcon.Image.Bounds.Width / 2 - (int)monoHackEngineLabel.Font.MeasureString(monoHackEngineLabel.Text).Y + 20),
                new Point(monohackIcon.Image.Bounds.Width, monohackIcon.Image.Bounds.Height));
            monohackIcon.Theme = mainTheme;
            monohackIcon.Opacity = 0f;
            monohackIcon.Theme.ControlStyle = Styles.ControlStyles.Flat;

            ///
            /// monoHackEngineLabel
            ///
            monoHackEngineLabel.SpriteBatch = spriteBatch;
            monoHackEngineLabel.Bounds = new Rectangle(new Point(graphicsDevice.Viewport.Width / 2 - (int)monoHackEngineLabel.Font.MeasureString(monoHackEngineLabel.Text).X / 2,
                graphicsDevice.Viewport.Height / 2 + (int)monoHackEngineLabel.Font.MeasureString(monoHackEngineLabel.Text).Y + (int)monoHackEngineLabel.Font.MeasureString(monoHackEngineLabel.Text).Y + 20), new Point(0, 0));
            monoHackEngineLabel.Theme.BorderSize = 0;
            monoHackEngineLabel.Theme.TextColor = Color.White;
            monoHackEngineLabel.Opacity = 0f;

            ///
            /// aGameBy
            ///
            aGameBy.SpriteBatch = spriteBatch;
            aGameBy.Text = "a game by";
            aGameBy.Theme = mainTheme;
            aGameBy.Theme.BorderSize = 0;
            aGameBy.Font = content.Load<SpriteFont>("UI/Font/H4");
            aGameBy.Theme.TextColor = Color.White;
            aGameBy.Opacity = 0f;
            aGameBy.Bounds = new Rectangle(new Point(graphicsDevice.Viewport.Width / 2 - (int)aGameBy.Font.MeasureString(aGameBy.Text).X / 2,
                graphicsDevice.Viewport.Height / 2 - (int)aGameBy.Font.MeasureString(aGameBy.Text).Y - 20), new Point(0, 0));

            ///
            /// ashifter
            ///
            ashifter.SpriteBatch = spriteBatch;
            ashifter.Text = "ashifter";
            ashifter.Theme = mainTheme;
            ashifter.Theme.BorderSize = 0;
            ashifter.Font = content.Load<SpriteFont>("UI/Font/H2");
            ashifter.Theme.TextColor = Color.White;
            ashifter.Opacity = 0f;
            ashifter.Bounds = new Rectangle(new Point(graphicsDevice.Viewport.Width / 2 - (int)ashifter.Font.MeasureString(ashifter.Text).X / 2,
                graphicsDevice.Viewport.Height / 2 - (int)ashifter.Font.MeasureString(ashifter.Text).Y / 2 + 20), new Point(0, 0));

            ///
            /// andCommunity
            ///
            andCommunity.SpriteBatch = spriteBatch;
            andCommunity.Text = "and the community";
            andCommunity.Theme = mainTheme;
            andCommunity.Theme.BorderSize = 0;
            andCommunity.Font = content.Load<SpriteFont>("UI/Font/H4");
            andCommunity.Theme.TextColor = Color.White;
            andCommunity.Opacity = 0f;
            andCommunity.Bounds = new Rectangle(new Point(graphicsDevice.Viewport.Width / 2 - (int)andCommunity.Font.MeasureString(andCommunity.Text).X / 2,
                graphicsDevice.Viewport.Height / 2 + (int)andCommunity.Font.MeasureString(andCommunity.Text).Y + 25), new Point(0, 0));
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
                    //animationCount++;
                }
            }

            if (animationComplete == false && animationCount == 1)
            {
                monohackIcon.Opacity = monohackIcon.Opacity - 0.05f;
                monohackIcon.Bounds = new Rectangle(new Point(monohackIcon.Bounds.X, monohackIcon.Bounds.Y - 1), new Point(monohackIcon.Bounds.Width, monohackIcon.Bounds.Height));

                monoHackEngineLabel.Opacity = monoHackEngineLabel.Opacity - 0.05f;
                monoHackEngineLabel.Bounds = new Rectangle(new Point(monoHackEngineLabel.Bounds.X, monoHackEngineLabel.Bounds.Y - 1), new Point(monoHackEngineLabel.Bounds.Width, monoHackEngineLabel.Bounds.Height));

                if (Math.Round(monohackIcon.Opacity, 2) == 0f)
                {
                    animationComplete = true;
                    //animationCount++;
                }
            }

            if (aGameBy.Opacity <= 1f && animationComplete == false && animationCount == 2)
            {
                aGameBy.Opacity = aGameBy.Opacity + 0.05f;
                aGameBy.Bounds = new Rectangle(new Point(aGameBy.Bounds.X, aGameBy.Bounds.Y - 1), new Point(aGameBy.Bounds.Width, aGameBy.Bounds.Height));

                ashifter.Opacity = ashifter.Opacity + 0.05f;
                ashifter.Bounds = new Rectangle(new Point(ashifter.Bounds.X, ashifter.Bounds.Y - 1), new Point(ashifter.Bounds.Width, ashifter.Bounds.Height));

                andCommunity.Opacity = andCommunity.Opacity + 0.05f;
                andCommunity.Bounds = new Rectangle(new Point(andCommunity.Bounds.X, andCommunity.Bounds.Y - 1), new Point(andCommunity.Bounds.Width, andCommunity.Bounds.Height));

                if (Math.Round(aGameBy.Opacity, 2) == 1f)
                {
                    animationComplete = true;
                    //animationCount++;
                }
            }

            if (animationComplete == false && animationCount == 3)
            {
                aGameBy.Opacity = aGameBy.Opacity - 0.05f;
                aGameBy.Bounds = new Rectangle(new Point(aGameBy.Bounds.X, aGameBy.Bounds.Y - 1), new Point(aGameBy.Bounds.Width, aGameBy.Bounds.Height));

                ashifter.Opacity = ashifter.Opacity - 0.05f;
                ashifter.Bounds = new Rectangle(new Point(ashifter.Bounds.X, ashifter.Bounds.Y - 1), new Point(ashifter.Bounds.Width, ashifter.Bounds.Height));

                andCommunity.Opacity = andCommunity.Opacity - 0.05f;
                andCommunity.Bounds = new Rectangle(new Point(andCommunity.Bounds.X, andCommunity.Bounds.Y - 1), new Point(andCommunity.Bounds.Width, andCommunity.Bounds.Height));

                if (Math.Round(aGameBy.Opacity, 2) == 0f)
                {
                    animationComplete = true;
                    //animationCount++;
                }
            }

            if (backPanel.Opacity <= 1f && animationComplete == false && animationCount == 4)
            {
                backPanel.Opacity = backPanel.Opacity - 0.05f;

                if (Math.Round(backPanel.Opacity, 2) == 1f)
                {
                    animationComplete = true;
                    //animationCount++;
                }
            }

            if (totalElapsedFrames == 60)
            {
                animationComplete = false;
                totalElapsedFrames = 0;
                animationCount++;
            }
        }

        public void Draw(GameTime gameTime)
        {
            backPanel.Draw(gameTime);
            monohackIcon.Draw(gameTime);
            monoHackEngineLabel.Draw(gameTime);

            //aGameBy.Opacity = 1f;
            //ashifter.Opacity = 1f;
            //andCommunity.Opacity = 1f;

            aGameBy.Draw(gameTime);
            ashifter.Draw(gameTime);
            andCommunity.Draw(gameTime);
        }
    }
}
