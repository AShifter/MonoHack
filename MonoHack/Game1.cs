using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoHack
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D DefaultCursor;
        Texture2D TextCursor;
        Texture2D CurrentCursor;
        Texture2D Pixel;
        Vector2 MousePosition;
        SpriteFont Font;
        Applications.IMonoHackApp Win1;
        UI.WindowTemplate Test1;
        //UI.Screen1 screen;
        UI.IUIControl FPSLabel;
        double fps;

        UI.ITitleScreen title;

        bool PostProcessing = false;

        // Create a new render target
        RenderTarget2D renderTarget;

        // The time elapsed since the last forced garbage collection.
        double GarbageCollectionTime = 0.0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: Add your initialization logic here
            Win1 = new UI.TestApp1(spriteBatch, Content);
            // Components.Add(Win1);
            Test1 = new UI.WindowTemplate(spriteBatch, Content, Win1);
            //Components.Add(Test1);
            title = new UI.TitleScreen.MonoHackTitleScreen(spriteBatch, Content, GraphicsDevice);
            Components.Add(title);

            base.Initialize();

            Console.Title = "MonoHack Engine Console";
            Console.WriteLine("[" + DateTime.Now.ToString("MM/dd/yyyy H:mm:ss") + "] MonoHack Engine Initialized.");

            //renderTarget = new RenderTarget2D(
              //  GraphicsDevice,
                //GraphicsDevice.PresentationParameters.BackBufferWidth,
                //GraphicsDevice.PresentationParameters.BackBufferHeight,
                //false,
                //GraphicsDevice.PresentationParameters.BackBufferFormat,
                //DepthFormat.Depth24);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            DefaultCursor = Content.Load<Texture2D>("UI/Images/Cursor/DefaultCursor");
            TextCursor = Content.Load<Texture2D>("UI/Images/Cursor/TextCursor");
            CurrentCursor = DefaultCursor;
            Pixel = Content.Load<Texture2D>("UI/Images/Pixel");
            Font = Content.Load<SpriteFont>("UI/Font/Main");

            // TODO: use this.Content to load your game content here
            FPSLabel = new UI.Controls.Label();
            FPSLabel.SpriteBatch = spriteBatch;
            FPSLabel.Bounds = new Rectangle(new Point(5, 5), new Point(1, 1));
            FPSLabel.Theme = new UI.Themes.DefaultTheme(Content);
            FPSLabel.Text = "FPS: 0";
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            fps = Math.Round(1 / gameTime.ElapsedGameTime.TotalSeconds);
            

            // Has it been 30 seconds since the last garbage collection?
            if (this.GarbageCollectionTime >= 30.0)
            {
                // Force a garbage collection
                GC.Collect();

                // Reset the timer back to 0.
                this.GarbageCollectionTime = 0.0;
            }

            // Increase the garbage collection timer
            this.GarbageCollectionTime += gameTime.ElapsedGameTime.TotalSeconds;

            // Get the mouse position.
            this.MousePosition = Mouse.GetState().Position.ToVector2();

            // TODO: Add your update logic here
            FPSLabel.Text = "FPS: " + fps;

            Test1.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the entire scene in the given render target.
        /// </summary>
        /// <returns>A texture2D with the scene drawn in it.</returns>
        protected void DrawSceneToTexture(RenderTarget2D renderTarget, GameTime gameTime)
        {
            // Set the render target
            GraphicsDevice.SetRenderTarget(renderTarget);

            GraphicsDevice.DepthStencilState = new DepthStencilState() { DepthBufferEnable = true };

            // Draw the scene
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //screen.Draw(gameTime);
            //Win1.Draw(gameTime);
            FPSLabel.Draw(gameTime);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp,
                DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(CurrentCursor, MousePosition, Color.White);
            spriteBatch.End();

            // Drop the render target
            GraphicsDevice.SetRenderTarget(null);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (PostProcessing)
            {
                DrawSceneToTexture(renderTarget, gameTime);

                GraphicsDevice.Clear(Color.CornflowerBlue);

                // SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp, DepthStencilState.Default, RasterizerState.CullNone
                spriteBatch.Begin();
                spriteBatch.Draw(renderTarget, new Rectangle(0, 0, GraphicsDevice.Adapter.CurrentDisplayMode.Width, GraphicsDevice.DisplayMode.Height), Color.White);
                spriteBatch.End();

                base.Draw(gameTime);
            }
            else
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);

                // Test1.Draw(gameTime);

                spriteBatch.Begin();
                spriteBatch.Draw(CurrentCursor, MousePosition, Color.White);
                spriteBatch.End();
                FPSLabel.Draw(gameTime);
                base.Draw(gameTime);
            }
        }
    }
}
