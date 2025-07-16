// MonoGame reusable Button component
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TheFarmerClone.Scenes
{
    public class Button
    {
        public Vector2 Position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Label { get; set; }
        public Color BackgroundColor { get; set; } = Color.Gray;
        public Color HoverBackgroundColor { get; set; } = Color.DarkGray;
        public Color TextColor { get; set; } = Color.Black;
        public Color HoverTextColor { get; set; } = Color.White;
        public Action OnClick { get; set; }

        private Texture2D _texture;
        private SpriteFont _font;
        private bool _wasPressedLastFrame = false;
        private bool _isHovering = false;

        public Button(Texture2D texture, SpriteFont font, Vector2 position, int width, int height, string label)
        {
            _texture = texture;
            _font = font;
            Position = position;
            Width = width;
            Height = height;
            Label = label;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw button rectangle with hover effect
            var bgColor = _isHovering ? HoverBackgroundColor : BackgroundColor;
            var textColor = _isHovering ? HoverTextColor : TextColor;
            spriteBatch.Draw(_texture, new Rectangle((int)Position.X, (int)Position.Y, Width, Height), bgColor);

            // Measure text and center it
            Vector2 textSize = _font.MeasureString(Label);
            Vector2 textPosition = new Vector2(
                Position.X + (Width - textSize.X) / 2,
                Position.Y + (Height - textSize.Y) / 2
            );

            spriteBatch.DrawString(_font, Label, textPosition, textColor);
        }

        public void Update(MouseState mouseState)
        {
            Rectangle buttonRect = new Rectangle((int)Position.X, (int)Position.Y, Width, Height);
            Point mousePoint = new Point(mouseState.X, mouseState.Y);

            _isHovering = buttonRect.Contains(mousePoint);
            bool isPressed = _isHovering && mouseState.LeftButton == ButtonState.Pressed;

            // Detect click (pressed this frame, released last frame)
            if (_isHovering && mouseState.LeftButton == ButtonState.Pressed && !_wasPressedLastFrame)
            {
                OnClick?.Invoke();
            }

            _wasPressedLastFrame = mouseState.LeftButton == ButtonState.Pressed;
        }
    }
}