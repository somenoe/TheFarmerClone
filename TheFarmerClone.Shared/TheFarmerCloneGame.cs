using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using TheFarmerClone.Scenes;

namespace TheFarmerClone
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class TheFarmerCloneGame : Game
    {
        private readonly ScreenManager _screenManager;
        private GameScreen _activeScreen;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private const float DefaultScreenTransitionTime = 0.2f;

        public TheFarmerCloneGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.SupportedOrientations = DisplayOrientation.LandscapeLeft | DisplayOrientation.LandscapeRight;
#if (ANDROID || iOS)
            graphics.IsFullScreen = true;
#endif

            _screenManager = new ScreenManager();
            Components.Add(_screenManager);
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
            LoadStartScreen();
            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: Use this.Content to load your game content here
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
            MouseState mouseState = Mouse.GetState();
            KeyboardState keyboardState = Keyboard.GetState();
            GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);

            if (keyboardState.IsKeyDown(Keys.Escape) ||
                keyboardState.IsKeyDown(Keys.Back) ||
                gamePadState.Buttons.Back == ButtonState.Pressed)
            {
                try { Exit(); }
                catch (PlatformNotSupportedException) { /* ignore */ }
            }

            // TODO: Add your update logic here
            if (keyboardState.IsKeyDown(Keys.D1))
                LoadStartScreen();
            if (keyboardState.IsKeyDown(Keys.D2))
                LoadStoreMenuScreen();
            if (keyboardState.IsKeyDown(Keys.D3))
                LoadStoreOutsideScreen();
            if (keyboardState.IsKeyDown(Keys.D4))
                LoadFarmScreen();
            if (keyboardState.IsKeyDown(Keys.D5))
                LoadFieldScreen();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        private void LoadStartScreen()
        {
            if (_activeScreen is StartScreen) return;
            var screen = new StartScreen(this);
            _screenManager.LoadScreen(screen, new FadeTransition(GraphicsDevice, Color.Black, DefaultScreenTransitionTime));
            _activeScreen = screen;
        }

        private void LoadStoreMenuScreen()
        {
            if (_activeScreen is StoreMenuScreen) return;
            var screen = new StoreMenuScreen(this);
            _screenManager.LoadScreen(screen, new FadeTransition(GraphicsDevice, Color.Black, DefaultScreenTransitionTime));
            _activeScreen = screen;
        }

        private void LoadStoreOutsideScreen()
        {
            if (_activeScreen is StoreOutsideScreen) return;
            var screen = new StoreOutsideScreen(this);
            _screenManager.LoadScreen(screen, new FadeTransition(GraphicsDevice, Color.Black, DefaultScreenTransitionTime));
            _activeScreen = screen;
        }

        public void LoadFarmScreen()
        {
            if (_activeScreen is FarmScreen) return;
            var screen = new FarmScreen(this);
            _screenManager.LoadScreen(screen, new FadeTransition(GraphicsDevice, Color.Black, DefaultScreenTransitionTime));
            _activeScreen = screen;
        }

        private void LoadFieldScreen()
        {
            if (_activeScreen is FieldScreen) return;
            var screen = new FieldScreen(this);
            _screenManager.LoadScreen(screen, new FadeTransition(GraphicsDevice, Color.Black, DefaultScreenTransitionTime));
            _activeScreen = screen;
        }
    }
}
