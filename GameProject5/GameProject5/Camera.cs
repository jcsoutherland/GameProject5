using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Windows.Forms;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using MessageBox = System.Windows.Forms.MessageBox;

namespace GameProject5
{
    public class Camera : ICamera
    {
        public string angleDirection { get; set; } = "";
        float xAngle = 0f;
        float yAngle = 0f;
        Vector3 position;
        float speed;
        Game game;
        Matrix view;
        Matrix projection;

        private KeyboardState keyboardState;
        private KeyboardState prev;
        public Matrix View => view;

        public Matrix Projection => projection;

        /// <summary>
        /// Constructs a new camera that circles the origin
        /// </summary>
        /// <param name="game">The game this camera belongs to</param>
        /// <param name="position">The initial position of the camera</param>
        /// <param name="speed">The speed of the camera</param>
        public Camera(Game game, Vector3 position, float speed)
        {
            this.game = game;
            this.position = position;
            this.speed = speed;
            this.projection = Matrix.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                game.GraphicsDevice.Viewport.AspectRatio,
                1,
                1000
            );
            this.view = Matrix.CreateLookAt(
                position,
                Vector3.Zero,
                Vector3.Up
            );
        }

        /// <summary>
        /// Updates the camera's positon
        /// </summary>
        /// <param name="gameTime">The GameTime object</param>
        public void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Up) && !prev.IsKeyDown(Keys.Up))
            {
                angleDirection = "Y";
            }
            if (keyboardState.IsKeyDown(Keys.Down) && !prev.IsKeyDown(Keys.Down))
            {
                angleDirection = "-Y";
            }
            if (keyboardState.IsKeyDown(Keys.Left) && !prev.IsKeyDown(Keys.Left))
            {
                angleDirection = "-X";
            }
            if (keyboardState.IsKeyDown(Keys.Right) && !prev.IsKeyDown(Keys.Right))
            {
                angleDirection = "X";
            }
            prev = keyboardState;

            // Calculate a new view matrix
            if (angleDirection == "Y")
            {
                yAngle -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (angleDirection == "X")
            {
                xAngle += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (angleDirection == "-X")
            {
                xAngle -= speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else if (angleDirection == "-Y")
            {
                yAngle += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            this.view =
                Matrix.CreateRotationX(yAngle) * Matrix.CreateRotationY(xAngle) *
                Matrix.CreateLookAt(position, Vector3.Zero, Vector3.Up);
        }
    }
}
