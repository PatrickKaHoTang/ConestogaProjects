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
    /// File Name: RSPTAssignment4
    /// 
    /// Purpose: Create a game of pong using XNA in a group of two
    /// 
    /// Created by Rubens Silva and Patrick Tang
    /// 
    /// Revision History:
    ///     November 7, 2016  - Created
    ///     November 8, 2016  - Created game component classes Ball.cs, Paddle.cs and added code to Game1.cs
    ///                       - Added code to the game component classes above (movement, logic, collision)
    ///                       - Added images to appear for the ball and paddle
    ///     November 9, 2016  - Created game component class ScoreBar.cs
    ///                       - Added the score bar and strings to appear on the screen
    ///     November 10, 2016 - Fixed the score increment
    ///                       - Added sound effects
    ///                       - Finishing up the game and checking the marking sheet if we missed anything
    ///                       - Adding comments to methods and attributes
    ///                       - Special effect added - background changes colour every time it hits Enter during
    ///                         start of round
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //
        // Attributes for left paddle, right paddle, ball, score bar and sound effects
        //

        Paddle paddleLeft;
        Paddle paddleRight;
        Ball ball;
        ScoreBar scoreBar;
        SoundEffect soundEffectWin;
        SoundEffect soundEffectPaddleWall;

        //
        // Bools for if the match is being played or if the game has ended
        //

        bool isPlaying = false;
        bool hasMatchEnded = false;

        //
        // RGB colours for randomized background colour effect
        //

        int red = 0;
        int blue = 0;
        int green = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            //
            // Loads the sound effects for applause1 (win the game) and ding (when it hits the wall or paddle)
            // Loads the Paddle class with the left Paddle image
            // Loads the Paddle class with the right Paddle image
            // Loads the Ball class with the ball image
            // Loads the score bar image
            //

            soundEffectWin = Content.Load<SoundEffect>("sounds/applause1");
            soundEffectPaddleWall = Content.Load<SoundEffect>("sounds/ding");

            paddleLeft = new Paddle(this, graphics, spriteBatch, true);
            paddleLeft.Initialize();

            paddleRight = new Paddle(this, graphics, spriteBatch, false);
            paddleRight.Initialize();

            ball = new Ball(this, graphics, spriteBatch);
            ball.Initialize();

            scoreBar = new ScoreBar(this, graphics, spriteBatch);
            scoreBar.Initialize();

            Components.Add(paddleLeft);
            Components.Add(paddleRight);
            Components.Add(scoreBar);
            Components.Add(ball);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

            KeyboardState kbs = Keyboard.GetState();

            //
            // Closes the game
            //

            if (kbs.IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            //
            // Starts the game by pressing enter
            // Special background effect: added a RGB randomizer
            //

            if (kbs.IsKeyDown(Keys.Enter) && isPlaying == false && hasMatchEnded == false)
            {
                isPlaying = true;
                ball.GameStart();

                Random randomizeBG = new Random();

                red = randomizeBG.Next(255);
                blue = randomizeBG.Next(255);
                green = randomizeBG.Next(255);
            }

            //
            // Restarts the game by pressing Space when there is a winner
            //

            if (kbs.IsKeyDown(Keys.Space) && isPlaying == false && hasMatchEnded == true)
            {
                isPlaying = false;
                hasMatchEnded = false;
                ball.GameRestart();
                scoreBar.resetScore();
                paddleLeft.Initialize();
                paddleRight.Initialize();
            }

            //
            // Keeps the ball inside the window in the X co-ordinates walls and checks the winner
            // Plays applause1 when there's a winner
            //

            if (ball.BallRectangle.X <= 0 && isPlaying)
            {
                isPlaying = false;
                scoreBar.playerOneAddScore();
                ball.GameRestart();

                if (scoreBar.CheckWinner())
                {
                    soundEffectWin.Play();
                    hasMatchEnded = true;
                }
            }
            else if (ball.BallRectangle.X >= graphics.GraphicsDevice.Viewport.Width && isPlaying)
            {
                isPlaying = false;
                scoreBar.playerTwoAddScore();
                ball.GameRestart();

                if (scoreBar.CheckWinner())
                {
                    soundEffectWin.Play();
                    hasMatchEnded = true;
                }
            }

            //
            // Creates a collision for the ball to change directions when it hits the paddle
            // Plays sound when it hits the wall and it misses/wins
            //

            if (ball.BallRectangle.Intersects(paddleLeft.PaddleRectangle))
            {
                if (ball.speed.X < 0)
                {
                    soundEffectPaddleWall.Play();
                    ball.ChangeDirection();
                }
            }
            if (ball.BallRectangle.Intersects(paddleRight.PaddleRectangle))
            {
                if (ball.speed.X > 0)
                {
                    soundEffectPaddleWall.Play();
                    ball.ChangeDirection();
                }
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //
            // Changes the colour of the background every time you start the game
            //

            Color bgColor = new Color(red, blue, green);
            GraphicsDevice.Clear(bgColor);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
