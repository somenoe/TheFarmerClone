using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using TheFarmerClone.Scenes;

namespace TheFarmerClone.Scenes
{
    public class NewGameScreen : GameScreen
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

        private Button _okButton;


        public NewGameScreen(TheFarmerCloneGame game) : base(game)
        {
            _game = game;
        }

        public override void LoadContent()
        {
            base.LoadContent();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _background.Texture = Content.Load<Texture2D>("screen.new-game");

            var font = Content.Load<SpriteFont>("font");
            var whiteTexture = new Texture2D(GraphicsDevice, 1, 1);
            whiteTexture.SetData([Color.White]);

            // Button layout is now handled in Update() to support resizing.
            // Initialize buttons with dummy positions.
            _okButton = new Button(whiteTexture, font, Vector2.Zero, 200, 60, "Ok")
            {
                isDebug = _game.isDebug,
                TextColor = Color.White,
                BackgroundColor = Color.Transparent,
                HoverTextColor = Color.Red,
                HoverBackgroundColor = Color.Transparent,
                OnClick = () => _game.LoadScreen(new FarmScreen(_game))
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


            _okButton.Position = new Vector2(1_310, 920) * _background.Scale + _background.Position;
            _okButton.Width = (int)(200 * _background.Scale);
            _okButton.Height = (int)(140 * _background.Scale);

            var mouseState = Microsoft.Xna.Framework.Input.Mouse.GetState();
            _okButton.Update(mouseState);
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PaleGreen);
            _spriteBatch.Begin();

            // Draw background using precomputed values from Update
            _spriteBatch.Draw(_background.Texture, _background.Position, null, Color.White, 0f, Vector2.Zero, _background.Scale, SpriteEffects.None, 0f);

            _okButton.Draw(_spriteBatch);

            _spriteBatch.End();
        }
    }
}