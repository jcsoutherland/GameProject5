using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace GameProject5
{
    public class Arrow
    {
        private Texture2D texture;
        private Vector2 position;

        private KeyboardState keyboardState;
        private KeyboardState prev;

        public string ClickedDirection { get; private set; } = "Default";
        public bool Clicked { get; set; } = false;

        public Color color { get; set; } = Color.Black;

        public Arrow(Vector2 p)
        {
            position = p;
        }

        /// <summary>
        /// Loads sprite for exit button
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Arrows");
        }

        /// <summary>
        /// Checks if mouse is over the button and if mouse is clicked on the button
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            /*keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up) && !prev.IsKeyDown(Keys.Up)) {
                color = Color.Red;
            }
            if (keyboardState.IsKeyDown(Keys.Down) && !prev.IsKeyDown(Keys.Down)) {
                color = Color.Purple;
            }
            if (keyboardState.IsKeyDown(Keys.Left) && !prev.IsKeyDown(Keys.Left))
            {
                color = Color.Orange;
            }
            if (keyboardState.IsKeyDown(Keys.Right) && !prev.IsKeyDown(Keys.Right))
            {
                color = Color.Green;
            }
            prev = keyboardState;*/
        }

        /// <summary>
        /// draws the button on the screen
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
