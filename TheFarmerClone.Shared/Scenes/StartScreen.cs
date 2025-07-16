using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using TheFarmerClone.Scenes;

namespace TheFarmerClone.Scenes
{
    public class StartScreen : GameScreen
    {
        private TheFarmerCloneGame _game;
        private SpriteFont _font;
        private SpriteBatch _spriteBatch;
        private Texture2D _logoTexture;
        private Texture2D _whiteTexture;
        private bool _isDebug = true;

        // Button components
        private Button _newGameButton;
        private Button _loadGameButton;

        // Scale factor for logo and buttons
        private const float _uiScale = 0.5f;

        public StartScreen(TheFarmerCloneGame game) : base(game)
        {
            _game = game;
        }

        public override void LoadContent()
        {
            base.LoadContent();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("font");
            _logoTexture = Content.Load<Texture2D>("logo");
            // Create 1x1 white texture for rectangles
            _whiteTexture = new Texture2D(GraphicsDevice, 1, 1);
            _whiteTexture.SetData(new[] { Color.White });

            // Button layout
            var viewport = GraphicsDevice.Viewport;
            float buttonMargin = 40f;
            float buttonSpacing = 20f;
            int buttonWidth = 200;
            int buttonHeight = 60;
            float buttonsStartY = viewport.Height - buttonHeight * 2 - buttonSpacing - buttonMargin;

            var newGamePos = new Vector2(viewport.Width - buttonWidth - buttonMargin, buttonsStartY);
            var loadGamePos = new Vector2(viewport.Width - buttonWidth - buttonMargin, buttonsStartY + buttonHeight + buttonSpacing);

            _newGameButton = new Button(_whiteTexture, _font, newGamePos, buttonWidth, buttonHeight, "New Game")
            {
                isDebug = _isDebug,
                TextColor = Color.Blue,
                BackgroundColor = Color.White,
                HoverTextColor = Color.Red,
                HoverBackgroundColor = Color.White,
                OnClick = () => _game.LoadFarmScreen()
            };

            _loadGameButton = new Button(_whiteTexture, _font, loadGamePos, buttonWidth, buttonHeight, "Load Game")
            {
                isDebug = _isDebug,
                TextColor = Color.Blue,
                BackgroundColor = Color.White,
                HoverTextColor = Color.Red,
                HoverBackgroundColor = Color.White,
                OnClick = () =>
                {
                    /* TODO: Change to load game screen */
                    System.Console.WriteLine("Click Load Game Button");
                }
            };
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PaleGreen);
            _spriteBatch.Begin();

            // Center logo with scale
            var viewport = GraphicsDevice.Viewport;
            var scaledLogoWidth = _logoTexture.Width * _uiScale;
            var scaledLogoHeight = _logoTexture.Height * _uiScale;
            var logoPos = new Vector2(
                (viewport.Width - scaledLogoWidth) / 2f,
                (viewport.Height - scaledLogoHeight) / 2f
            );
            _spriteBatch.Draw(_logoTexture, logoPos, null, Color.White, 0f, Vector2.Zero, _uiScale, SpriteEffects.None, 0f);

            // Draw buttons using Button component
            _newGameButton.Draw(_spriteBatch);
            _loadGameButton.Draw(_spriteBatch);

            _spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            var mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            _newGameButton.Update(mouseState);
            _loadGameButton.Update(mouseState);
        }
    }
}