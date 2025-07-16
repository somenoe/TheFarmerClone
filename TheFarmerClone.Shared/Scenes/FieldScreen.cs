using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;

namespace TheFarmerClone.Scenes
{
    public class FieldScreen : GameScreen
    {
        private TheFarmerCloneGame _game;
        private SpriteFont _font;
        private SpriteBatch _spriteBatch;

        public FieldScreen(TheFarmerCloneGame game) : base(game)
        {
            _game = game;
        }

        public override void LoadContent()
        {
            base.LoadContent();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("font");
        }

        public override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkGreen);
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "FieldScreen", new Vector2(10, 10), Color.White);
            _spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}