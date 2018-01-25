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
    public class ScoreBar : Microsoft.Xna.Framework.DrawableGameComponent
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        //
        // Attributes for the score bar
        //
        
        private Texture2D scoreBarTexture;
        private Rectangle scoreBarRectangle;
        private SpriteFont spriteFont;
        private SoundEffect soundEffectMiss;

        //
        // Constants for the maximum win and the instructions for restart
        //

        private const int MAX_POINT_MATCH = 2;
        private const string RESTART_INSTRUCTION = "Press space bar to restart";

        //
        // String for player one/two name, player one/two score, the "Score" string and player's win count
        //

        private string playerOneName;
        private string playerTwoName;
        private int playerOneScore = 0;
        private int playerTwoScore = 0;
        private string scoreString;
        private string winnerName = "";

        //
        // Constructor for the score bar
        //
        
        public ScoreBar(Game game, GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
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
            // Initializes and loads the score bar, the sound for when it misses, the "Score" string
            // and our names (Rubens and Patrick)
            //

            spriteFont = Game.Content.Load<SpriteFont>("fonts/SpriteFont1");

            soundEffectMiss = Game.Content.Load<SoundEffect>("sounds/click");

            playerOneName = "Rubens Silva";
            playerTwoName = "Patrick Tang";
            scoreString = "Score"; 

            scoreBarTexture = Game.Content.Load<Texture2D>("images/Scorebar");
            scoreBarRectangle = new Rectangle(0, (graphics.GraphicsDevice.Viewport.Height - 61),
                                              800, 61);

            base.Initialize();
        }

        //
        // Method for resetting the score and winner's name
        //

        public void resetScore()
        {
            playerOneScore = 0;
            playerTwoScore = 0;
            winnerName = "";
        }

        //
        // Increments the score of player one and player two when they score
        // Plays the sound for miss
        //

        #region Incrementing the score
        public void playerOneAddScore()
        {
            soundEffectMiss.Play();
            playerOneScore++;
        }

        public void playerTwoAddScore()
        {
            soundEffectMiss.Play();
            playerTwoScore++;
        }
        #endregion

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        /// <summary>
        /// Allows the game component to draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Draw(GameTime gameTime)
        {
            // TODO: Add your draw code here

            //
            // Draws and DrawStrings the attributes listed above
            //

            spriteBatch.Begin();
            spriteBatch.Draw(scoreBarTexture, scoreBarRectangle, Color.White);
            spriteBatch.DrawString(spriteFont, playerOneName, new Vector2(10, 450), Color.Red);
            spriteBatch.DrawString(spriteFont, playerTwoName, new Vector2(660, 450), Color.Blue);

            if(winnerName != "")
            {
                spriteBatch.DrawString(spriteFont, winnerName, new Vector2((graphics.PreferredBackBufferWidth / 2), 10), Color.Yellow);
            }

            spriteBatch.DrawString(spriteFont, scoreString, new Vector2((graphics.PreferredBackBufferWidth / 2) - 21, 425), Color.Black);
            spriteBatch.DrawString(spriteFont, playerOneScore.ToString(), new Vector2(((graphics.PreferredBackBufferWidth / 2) - 25), 450), Color.Black);
            spriteBatch.DrawString(spriteFont, playerTwoScore.ToString(), new Vector2(((graphics.PreferredBackBufferWidth / 2) + 25), 450), Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        //
        // Method for checking the winner
        //

        public bool CheckWinner()
        {
            if (playerOneScore >= MAX_POINT_MATCH)
            {
                winnerName = playerOneName + " wins!\n" + RESTART_INSTRUCTION;
            }
            else if (playerTwoScore >= MAX_POINT_MATCH)
            {
                winnerName = playerTwoName + " wins!\n" + RESTART_INSTRUCTION;
            }
            return winnerName != "";
        }
    }
}
