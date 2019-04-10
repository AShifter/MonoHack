
using MonoHack.Engine;
using MonoHack.Engine.WindowTypes;
using MonoHack.TitleScreen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoHack
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class MonoHackGame : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D DefaultCursor;
        Texture2D TextCursor;
        Texture2D CurrentCursor;
        Texture2D Pixel;
        Vector2 MousePosition;
        SpriteFont Font;
        IMonoHackApp Win1;

        Engine.UI.Control FPSLabel;
        double fps;

        Engine.UI.ITitleScreen title;

        // Create a new render target
        RenderTarget2D renderTarget;

        // The time elapsed since the last forced garbage collection.
        double GarbageCollectionTime = 0.0;

        public MonoHackGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1024;
            graphics.PreferredBackBufferHeight = 768;
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

           

            Win1 = new Applications.TestApp1(spriteBatch, Content);

            ClassicWindow Test1 = new ClassicWindow(spriteBatch, Content, GraphicsDevice, Win1);

            Components.Add(Win1);

            Components.Add(Test1);

            title = new MonoHackTitleScreen(spriteBatch, Content, GraphicsDevice);

            title.Initialize();

            Components.Add(title);

            base.Initialize();

            Console.Title = "MonoHack Engine Console";

            Console.WriteLine("[" + DateTime.Now.ToString("MM/dd/yyyy H:mm:ss") + "] MonoHack Engine Initialized.");
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
            FPSLabel = new Engine.UI.Controls.Label();
            FPSLabel.SpriteBatch = spriteBatch;
            FPSLabel.Bounds = new Rectangle(new Point(5, 5), new Point(1, 1));
            FPSLabel.Theme = new Engine.UI.Themes.DefaultTheme(Content, spriteBatch);
            FPSLabel.Font = FPSLabel.Theme.Font;
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

            //Test1.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(0, 128, 128));

            base.Draw(gameTime);

            spriteBatch.Begin();
            spriteBatch.Draw(CurrentCursor, MousePosition, Color.White);
            spriteBatch.End();
            FPSLabel.Draw(gameTime);
        }
    }
}
