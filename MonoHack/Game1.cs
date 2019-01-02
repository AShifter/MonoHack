using DiscordRPC;
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
        UI.GameWindow Test1;

        public DiscordRpcClient client;

        UI.Control FPSLabel;
        double fps;

        UI.ITitleScreen title;

        // Create a new render target
        RenderTarget2D renderTarget;

        // The time elapsed since the last forced garbage collection.
        double GarbageCollectionTime = 0.0;

        public Game1()
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


            Win1 = new UI.TestApp1(spriteBatch, Content);

            Test1 = new UI.GameWindow(spriteBatch, Content, GraphicsDevice, Win1);

            Components.Add(Win1);

            Components.Add(Test1);

            title = new UI.TitleScreen.MonoHackTitleScreen(spriteBatch, Content, GraphicsDevice);

            title.Initialize();

            Components.Add(title);

            base.Initialize();

            Console.Title = "MonoHack Engine Console";

            Console.WriteLine("[" + DateTime.Now.ToString("MM/dd/yyyy H:mm:ss") + "] MonoHack Engine Initialized.");

            client = new DiscordRpcClient("529725485635338240");
            
            //Subscribe to events
            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("[" + DateTime.Now.ToString("MM/dd/yyyy H:mm:ss") + "] DiscordRPC Received Ready from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("[" + DateTime.Now.ToString("MM/dd/yyyy H:mm:ss") + "] DiscordRPC Received Update {0}", e.Presence);
            };

            //Connect to the RPC
            client.Initialize();

            //Set the rich presence
            //Call this as many times as you want and anywhere in your code.
            client.SetPresence(new RichPresence()
            {
                Details = "MonoHack Engine Demo",
                State = "Main Menu",
                Assets = new Assets()
                {
                    LargeImageKey = "monohack_512x",
                    LargeImageText = "Playing MonoHack",
                    SmallImageKey = "debug",
                    SmallImageText = "Debugging"
                },
                Timestamps = new Timestamps(DateTime.UtcNow) { }
            });
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
            FPSLabel.Theme = new UI.Themes.DefaultTheme(Content, spriteBatch);
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

            client.Invoke();

            //Test1.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        { 
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);    

            spriteBatch.Begin();
            spriteBatch.Draw(CurrentCursor, MousePosition, Color.White);
            spriteBatch.End();
            FPSLabel.Draw(gameTime);
        }
    }
}
