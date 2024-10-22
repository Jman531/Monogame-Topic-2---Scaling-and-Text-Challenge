using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame_Topic_2___Scaling_and_Text_Challenge
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        int colorType;

        Rectangle window;

        Texture2D rectangleTexture;
        Rectangle boardTileRect;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 640, 640);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            boardTileRect = new Rectangle(0, 0, 80, 80);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            rectangleTexture = Content.Load<Texture2D>("rectangle");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            boardTileRect.X = 0;
            boardTileRect.Y = 0;
            colorType = 0;

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            for (int i = 0; i <= 8; i++)
            {
                for (int x = 0; x <= 8; x++)
                {
                    if (colorType == 0)
                    {
                        _spriteBatch.Draw(rectangleTexture, boardTileRect, Color.Tan);
                        colorType = 1;
                    }
                    else if (colorType == 1)
                    {
                        _spriteBatch.Draw(rectangleTexture, boardTileRect, Color.SaddleBrown);
                        colorType = 0;
                    }
                    boardTileRect.X += 80;
                }
                boardTileRect.X = 0;
                boardTileRect.Y += 80;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
