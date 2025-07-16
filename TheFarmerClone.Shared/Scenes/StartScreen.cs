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

        public StartScreen(TheFarmerCloneGame game) : base(game)
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
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.DrawString(_font, "StartScreen", new Vector2(10, 10), Color.White);
            _spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}