using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;

namespace TheFarmerClone.Scenes
{
    public class StoreMenuScreen : GameScreen
    {
        private TheFarmerCloneGame _game;
        private SpriteFont _font;
        private SpriteBatch _spriteBatch;

        public StoreMenuScreen(TheFarmerCloneGame game) : base(game)
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
            GraphicsDevice.Clear(Color.Red);
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "StoreMenuScreen", new Vector2(10, 10), Color.White);
            _spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}