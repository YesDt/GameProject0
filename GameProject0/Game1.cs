using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject0
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private CoinSprite[] _coins;

        private Texture2D _crown;
        private Texture2D _bars;
        private Texture2D _chest;

        private SpriteFont _title;
        private SpriteFont _pressEnter;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _coins = new CoinSprite[]
            {
                new CoinSprite(new Vector2(245, 90)),
                new CoinSprite(new Vector2(520, 90))
            };

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _title = Content.Load<SpriteFont>("Title");
            _crown = Content.Load<Texture2D>("gold");
            _bars = Content.Load<Texture2D>("gold");
            _chest = Content.Load<Texture2D>("gold");
            _pressEnter = Content.Load<SpriteFont>("PressEnter");
            foreach (var coin in _coins) coin.LoadContent(Content);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            if (Keyboard.GetState().IsKeyDown(Keys.Enter)) Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DeepSkyBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.DrawString(_title, "GOLD RUSH", new Vector2(270, 70), Color.Gold);
            _spriteBatch.Draw(_crown, new Vector2(460, 80), new Rectangle(0, 96, 32, 32), Color.White, .75f, new Vector2(16, 16), 1.0f, SpriteEffects.None, 0);
            _spriteBatch.DrawString(_pressEnter, "Press Enter to exit the game", new Vector2(260, 120), Color.Red);
            foreach (var coin in _coins) coin.Draw(gameTime, _spriteBatch);
            _spriteBatch.Draw(_bars, new Vector2(120, 300), new Rectangle(64, 64, 32, 32), Color.White, 0f, new Vector2(16, 16), 2.0f, SpriteEffects.None, 0);
            _spriteBatch.Draw(_chest, new Vector2(600, 300), new Rectangle(96, 64, 32, 32), Color.White, 0f, new Vector2(16, 16), 3.0f, SpriteEffects.None, 0);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}