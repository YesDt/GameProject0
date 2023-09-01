using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace GameProject0
{
    public class CoinSprite
    {
        private const float ANIMATION_SPEED = 0.1f;

        public double animationTimer;

        private int _animationFrame;

        private Vector2 _position;

        private Texture2D _texture;

        public CoinSprite(Vector2 position)
        {
            this._position = position;
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("Coins");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if(animationTimer > ANIMATION_SPEED)
            {
                _animationFrame++;
                if (_animationFrame > 7) _animationFrame = 0;
                animationTimer -= ANIMATION_SPEED;
            }

            var source = new Rectangle(_animationFrame * 16, 0, 16, 16);
            spriteBatch.Draw(_texture, _position, source, Color.White);
        }
    }
}
