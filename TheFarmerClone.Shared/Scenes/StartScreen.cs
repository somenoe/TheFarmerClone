using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using TheFarmerClone.Scenes;

namespace TheFarmerClone.Scenes
{
    public class StartScreen : GameScreen
    {
        private TheFarmerCloneGame _game;
        private SpriteBatch _spriteBatch;

        // Struct for background calculations
        private struct Background
        {
            public Texture2D Texture;
            public float Scale;
            public float ScaledWidth;
            public float ScaledHeight;
            public Vector2 Position;
        }
        private Background _background;

        // Button components
        private Button _newGameButton;
        private Button _loadGameButton;

        // Struct for mouse state
        private struct Mouse
        {
            public Texture2D Texture;
            public Vector2 Position;
        }
        private Mouse _mouse;

        public StartScreen(TheFarmerCloneGame game) : base(game)
        {
            _game = game;
        }

        public override void LoadContent()
        {
            base.LoadContent();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _background.Texture = Content.Load<Texture2D>("screen.start");
            _mouse.Texture = Content.Load<Texture2D>("cursor");

            var font = Content.Load<SpriteFont>("font");
            var whiteTexture = new Texture2D(GraphicsDevice, 1, 1);
            whiteTexture.SetData([Color.White]);

            // Button layout is now handled in Update() to support resizing.
            // Initialize buttons with dummy positions.
            _newGameButton = new Button(whiteTexture, font, Vector2.Zero, 200, 60, "New Game")
            {
                isDebug = _game.isDebug,
                TextColor = Color.White,
                BackgroundColor = Color.Transparent,
                HoverTextColor = Color.Red,
                HoverBackgroundColor = Color.Transparent,
                OnClick = () => _game.LoadScreen(new NewGameScreen(_game))
            };

            _loadGameButton = new Button(whiteTexture, font, Vector2.Zero, 200, 60, "Load Game")
            {
                isDebug = _game.isDebug,
                TextColor = Color.White,
                BackgroundColor = Color.Transparent,
                HoverTextColor = Color.Red,
                HoverBackgroundColor = Color.Transparent,
                OnClick = () => _game.LoadScreen(new LoadGameScreen(_game))
            };
        }

        public override void Update(GameTime gameTime)
        {
            // Calculate background scale and position
            var viewport = GraphicsDevice.Viewport;
            float scaleX = (float)viewport.Width / _background.Texture.Width;
            float scaleY = (float)viewport.Height / _background.Texture.Height;
            _background.Scale = System.Math.Min(scaleX, scaleY);
            _background.ScaledWidth = _background.Texture.Width * _background.Scale;
            _background.ScaledHeight = _background.Texture.Height * _background.Scale;
            _background.Position = new Vector2(
                (viewport.Width - _background.ScaledWidth) / 2f,
                (viewport.Height - _background.ScaledHeight) / 2f
            );

            // Update button positions and dimensions
            _newGameButton.Position = new Vector2(1_080, 820) * _background.Scale + _background.Position;
            _newGameButton.Width = (int)(490 * _background.Scale);
            _newGameButton.Height = (int)(100 * _background.Scale);

            _loadGameButton.Position = new Vector2(1_060, 970) * _background.Scale + _background.Position;
            _loadGameButton.Width = (int)(530 * _background.Scale);
            _loadGameButton.Height = (int)(100 * _background.Scale);

            // Mouse logic
            var mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            _mouse.Position = new Vector2(mouseState.X, mouseState.Y);

            _newGameButton.Update(mouseState);
            _loadGameButton.Update(mouseState);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PaleGreen);
            _spriteBatch.Begin();

            // Draw background using precomputed values from Update
            _spriteBatch.Draw(_background.Texture, _background.Position, null, Color.White, 0f, Vector2.Zero, _background.Scale, SpriteEffects.None, 0f);

            // Draw buttons using Button component
            _newGameButton.Draw(_spriteBatch);
            _loadGameButton.Draw(_spriteBatch);

            // Draw cursor at mouse position
            _spriteBatch.Draw(_mouse.Texture, _mouse.Position, null, Color.White, 0f, Vector2.Zero, _background.Scale * 0.6f, SpriteEffects.None, 0f);

            _spriteBatch.End();
        }
    }
}