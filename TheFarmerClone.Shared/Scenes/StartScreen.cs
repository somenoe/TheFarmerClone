using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;

namespace TheFarmerClone.Scenes
{
    public class StartScreen : GameScreen
    {
        private TheFarmerCloneGame _game;
        private SpriteFont _font;
        private SpriteBatch _spriteBatch;
        private Texture2D _logoTexture;
        private Texture2D _loadGameButtonTexture;
        private Texture2D _newGameButtonTexture;

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
            _loadGameButtonTexture = Content.Load<Texture2D>("button.load-game");
            _newGameButtonTexture = Content.Load<Texture2D>("button.new-game");
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

            // Bottom right buttons with scale
            float buttonSpacing = 20f;
            var scaledLoadGameWidth = _loadGameButtonTexture.Width * _uiScale;
            var scaledNewGameWidth = _newGameButtonTexture.Width * _uiScale;
            var scaledLoadGameHeight = _loadGameButtonTexture.Height * _uiScale;
            var scaledNewGameHeight = _newGameButtonTexture.Height * _uiScale;
            float buttonsStartY = viewport.Height - scaledLoadGameHeight - scaledNewGameHeight - buttonSpacing;

            var newGamePos = new Vector2(viewport.Width - scaledNewGameWidth - 10, buttonsStartY);
            _spriteBatch.Draw(_newGameButtonTexture, newGamePos, null, Color.White, 0f, Vector2.Zero, _uiScale, SpriteEffects.None, 0f);

            var loadGamePos = new Vector2(viewport.Width - scaledLoadGameWidth - 10, buttonsStartY + scaledLoadGameHeight + buttonSpacing);
            _spriteBatch.Draw(_loadGameButtonTexture, loadGamePos, null, Color.White, 0f, Vector2.Zero, _uiScale, SpriteEffects.None, 0f);

            _spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            var mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                var viewport = GraphicsDevice.Viewport;
                var scaledNewGameWidth = _newGameButtonTexture.Width * _uiScale;
                var scaledNewGameHeight = _newGameButtonTexture.Height * _uiScale;
                float buttonSpacing = 20f;
                float buttonsStartY = viewport.Height - _loadGameButtonTexture.Height * _uiScale - _newGameButtonTexture.Height * _uiScale - buttonSpacing;
                var newGamePos = new Vector2(viewport.Width - scaledNewGameWidth - 10, buttonsStartY);

                var mousePos = new Vector2(mouseState.X, mouseState.Y);
                var newGameRect = new Rectangle(
                    (int)newGamePos.X,
                    (int)newGamePos.Y,
                    (int)scaledNewGameWidth,
                    (int)scaledNewGameHeight
                );

                if (newGameRect.Contains(mousePos))
                {
                    _game.LoadFarmScreen();
                }
            }
        }
    }
}