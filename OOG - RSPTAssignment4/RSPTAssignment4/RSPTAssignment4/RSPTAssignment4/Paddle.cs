using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace RSPTAssignment4
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Paddle : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //
        // Attributes for the paddle
        //

        private Texture2D paddleTexture;
        private Rectangle paddleRectangle;

        public Rectangle PaddleRectangle
        {
            get
            {
                return paddleRectangle;
            }
        }

        //
        // Constants for the score bar height, paddle width, paddle length and the speed of the paddle
        //

        private const int SCORE_BAR_HEIGHT = 61;
        private const int PADDLE_WIDTH = 15;
        private const int PADDLE_LENGTH = 80;
        private const int SPEED = 6;

        //
        // Bool for if it is paddle one or paddle two
        //

        bool isPlayerOne = true;

        //
        // Constructor for the Paddle class
        //

        public Paddle(Game game, GraphicsDeviceManager graphics, SpriteBatch spriteBatch, bool isPlayerOne)
            : base(game)
        {
            // TODO: Construct any child components here

            this.graphics = graphics;
            this.isPlayerOne = isPlayerOne;
            this.spriteBatch = spriteBatch;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            //
            // Initializes and loads the left and right paddle
            //

            if (isPlayerOne == true) // Player One
            {
                paddleTexture = Game.Content.Load<Texture2D>("images/BatLeft");
                paddleRectangle = new Rectangle(20, (((graphics.PreferredBackBufferHeight - SCORE_BAR_HEIGHT) / 2) - (paddleTexture.Height / 2)),
                                                PADDLE_WIDTH, PADDLE_LENGTH);
            }
            else                     // Player Two
            {
                paddleTexture = Game.Content.Load<Texture2D>("images/BatRight");
                paddleRectangle = new Rectangle((graphics.GraphicsDevice.Viewport.Width - paddleTexture.Width - 20), 
                                                (((graphics.PreferredBackBufferHeight - SCORE_BAR_HEIGHT) / 2) - (paddleTexture.Height / 2)),
                                                PADDLE_WIDTH, PADDLE_LENGTH);
            }

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            
            //
            // Calls the paddle movement method below
            //

            PaddleMovement();

            //
            // Keeps the paddle better the window and the score bar
            //

            if (paddleRectangle.Y > ((graphics.PreferredBackBufferHeight - SCORE_BAR_HEIGHT) - paddleRectangle.Height))
            {
                paddleRectangle.Y = (graphics.PreferredBackBufferHeight - SCORE_BAR_HEIGHT) - paddleRectangle.Height;
            }
            if (paddleRectangle.Y <= 0)
            {
                paddleRectangle.Y = 0;
            }

            base.Update(gameTime);
        }

        //
        // Method for the movement of the paddles
        //

        public void PaddleMovement()
        {
            KeyboardState kbs = Keyboard.GetState();

            if (isPlayerOne == true)
            {
                if (kbs.IsKeyDown(Keys.A))
                {
                    paddleRectangle.Y -= SPEED;
                }
                else if (kbs.IsKeyDown(Keys.Z))
                {
                    paddleRectangle.Y += SPEED;
                }
            }
            else
            {
                if (kbs.IsKeyDown(Keys.Up))
                {
                    paddleRectangle.Y -= SPEED;
                }
                else if (kbs.IsKeyDown(Keys.Down))
                {
                    paddleRectangle.Y += SPEED;
                }
            }
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            // TODO: Add your draw code here

            //
            // Draws the paddle
            //

            spriteBatch.Begin();
            spriteBatch.Draw(paddleTexture, paddleRectangle, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
