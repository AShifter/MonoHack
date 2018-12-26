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
        UI.WindowTemplate Win1 = new UI.WindowTemplate();

        // The time elapsed since the last forced garbage collection.
        double GarbageCollectionTime = 0.0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
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
            // TODO: Add your initialization logic here
            base.Initialize();
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

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            Win1.SetupWindow(spriteBatch, Content);
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
            // Has it been 30 seconds since the last garbage collection?
            if(this.GarbageCollectionTime >= 30.0)
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
            base.Update(gameTime);
            Win1.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            Win1.Draw(gameTime);

            spriteBatch.Begin();

            // Fix: Explicitly specify the tint color of the sprite, not doing so results in "deprecated" warnings
            spriteBatch.Draw(CurrentCursor, MousePosition, Color.White);

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
