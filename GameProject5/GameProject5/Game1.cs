using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject5
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        SpriteFont spriteFont;

        Crate crate;
        Camera camera;
        Arrow arrow;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            arrow = new Arrow(new Vector2(_graphics.GraphicsDevice.Viewport.Width - 170, _graphics.GraphicsDevice.Viewport.Height - 170));
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            arrow.LoadContent(Content);
            crate = new Crate(this, Matrix.Identity);
            camera = new Camera(this, new Vector3(0,5,10), 1f);
            spriteFont = Content.Load<SpriteFont>("arial");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //arrow.Update(gameTime);
            camera.Update(gameTime);
            // TODO: Add your update logic here
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            _spriteBatch.DrawString(spriteFont, "Use arrow keys to rotate the box!", new Vector2(32, (GraphicsDevice.Viewport.Height) - 48), Color.White);
            arrow.Draw(gameTime, _spriteBatch);
            crate.Draw(camera);
            _spriteBatch.End();
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
