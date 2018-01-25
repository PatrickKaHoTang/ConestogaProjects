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
    public class Ball : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //
        // Attributes for the ball
        //

        private Texture2D ballTexture;
        private Rectangle ballRectangle;
        private SoundEffect soundEffectPaddleWall;

        public Rectangle BallRectangle
        {
            get
            {
                return ballRectangle;
            }
        }

        //
        // Constant for the score bar's height
        //

        private const int SCORE_BAR_HEIGHT = 61;

        //
        // Attribute for the speed of the ball at the beginning of the game
        //

        public Vector2 speed = Vector2.Zero;

        //
        // Constructor for the Ball class
        //

        public Ball(Game game, GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
            : base(game)
        {
            // TODO: Construct any child components here

            this.graphics = graphics;
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
            // Initializes and loads the ball and the sound effect when it hits the wall and paddle
            //

            soundEffectPaddleWall = Game.Content.Load<SoundEffect>("sounds/ding");

            ballTexture = Game.Content.Load<Texture2D>("images/ball");
            ballRectangle = new Rectangle(graphics.PreferredBackBufferWidth / 2,
                                          ((graphics.PreferredBackBufferHeight - SCORE_BAR_HEIGHT) / 2),
                                          10, 10);

            base.Initialize();
        }

        //
        // Method for starting the game
        //

        public void GameStart()
        {
            Random startSpeed = new Random();
            ballRectangle.X = graphics.PreferredBackBufferWidth / 2;
            ballRectangle.Y = ((graphics.PreferredBackBufferHeight - SCORE_BAR_HEIGHT) / 2);

            speed.X = startSpeed.Next(3, 9);
            speed.Y = startSpeed.Next(3, 9);
            startSpeed = new Random();

            if (startSpeed.Next(0, 2) == 0)
            {
                speed.X *= -1;
            }
            if (startSpeed.Next(0, 2) == 0)
            {
                speed.Y *= -1;
            }
        }

        // Method for restarting the game

        public void GameRestart()
        {
            speed = Vector2.Zero;
            ballRectangle.X = graphics.PreferredBackBufferWidth / 2;
            ballRectangle.Y = ((graphics.PreferredBackBufferHeight - SCORE_BAR_HEIGHT) / 2);
        }


        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            
            //
            // Collision for hitting the outside walls
            //

            if (ballRectangle.Y >= graphics.PreferredBackBufferHeight - SCORE_BAR_HEIGHT - 10 || ballRectangle.Y <= 0)
            {
                soundEffectPaddleWall.Play();
                speed.Y *= -1;
            }

            ballRectangle.X += (int)speed.X;
            ballRectangle.Y += (int)speed.Y;

            base.Update(gameTime);
        }

        // Changes the direction for X

        public void ChangeDirection()
        {
            speed.X *= -1;
        }

        /// <summary>
        /// Allows the game component to draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            // TODO: Add your draw code here

            //
            // Draws the ball
            //

            spriteBatch.Begin();
            spriteBatch.Draw(ballTexture, ballRectangle, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);

        }
    }
}
