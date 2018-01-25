using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PTangAssignment2
{
    /// <summary>
    /// File name: PTangAssignment2
    /// 
    /// Purpose: Create a Tic Tac Toe game
    /// 
    /// Created by Patrick Tang
    /// 
    /// History:
    ///         September 30, 2016 - Created
    ///         October 1, 2016 - Created UI
    ///         October 2, 2016 - Added code for turnCounter, myTurn, CheckWinCombination(), ResetGame() and Button_Click()
    ///         October 3, 2016 - Added isWinner boolean to CheckWinCombination() to work
    ///         October 6, 2016 - Touched up code to make it look easier to read
    ///         October 7, 2016 - Added background image, X and O images
    ///                         - Changed font size to 0.01 px to create the illusion of "hidden"
    ///                         * Note: Images were taken from Google and used GIMP to merge images together 
    ///                                 (grid and background image) and got rid of original white spaced areas 
    ///                                 to make the X, O's and grid transparent
    ///         October 9, 2016 - Consolidated code from ResetGame() from 35 lines to 12 lines
    ///                         - Separated code in CheckWinCombination() into separate methods instead
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //
        // Checks to see whose turn is first (true = x, false = o)
        // *Note: X is always first
        //

        bool myTurn = true;

        //
        // turnCounter increases by 1 in Button_Click()
        //

        int turnCounter = 0;

        //
        // Determines whose turn it is by alternating, then checks for any win combinations
        // Buttons will be hidden with low opacity and an image will be displayed instead
        // *Note: hidden = 0.01 px font size
        //

        // ******************************************************************************************************************
        // I'm a little confused about the whole img.ImageSource section. To make it work in Debug/Release build, I needed to
        // put the images folder inside those folders in order for them to work.  If possible, could you clarify as to why
        // this happens? Also, how I change it from making it work without having to add those folders in there?
        // ******************************************************************************************************************

        private void Button_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            var img = new ImageBrush();

            if (myTurn == true)
            {
                img.ImageSource = new BitmapImage(new Uri("images/X3.png", UriKind.Relative));
                btn.Background = img;
                btn.Content = "X";
                myTurn = false;
            }
            else
            {
                img.ImageSource = new BitmapImage(new Uri("images/O3.png", UriKind.Relative));
                btn.Background = img;
                btn.Content = "O";
                myTurn = true;
            }

            turnCounter++;
            btn.IsEnabled = false;

            CheckWinCombination();
        }

        //
        // Checks for winning combinations and then checks to see who wins through CheckIsWinner() method
        //

        private void CheckWinCombination()
        {
            bool isWinner = false;

            // Grid Position:   +---+---+---+
            //                  | 1 | 2 | 3 |
            //                  +---+---+---+
            //                  | 4 | 5 | 6 |
            //                  +---+---+---+
            //                  | 7 | 8 | 9 |
            //                  +---+---+---+

            if (((btn1.Content == btn2.Content) && (btn2.Content == btn3.Content) && (!btn1.IsEnabled)) || // Position 1-2-3
                ((btn4.Content == btn5.Content) && (btn5.Content == btn6.Content) && (!btn4.IsEnabled)) || // Position 4-5-6
                ((btn7.Content == btn8.Content) && (btn8.Content == btn9.Content) && (!btn7.IsEnabled)) || // Position 7-8-9
                ((btn1.Content == btn4.Content) && (btn4.Content == btn7.Content) && (!btn1.IsEnabled)) || // Position 1-4-7
                ((btn2.Content == btn5.Content) && (btn5.Content == btn8.Content) && (!btn2.IsEnabled)) || // Position 2-5-8
                ((btn3.Content == btn6.Content) && (btn6.Content == btn9.Content) && (!btn3.IsEnabled)) || // Position 3-6-9
                ((btn1.Content == btn5.Content) && (btn5.Content == btn9.Content) && (!btn1.IsEnabled)) || // Position 1-5-9
                ((btn7.Content == btn5.Content) && (btn5.Content == btn3.Content) && (!btn7.IsEnabled)))   // Position 7-5-3
            {
                isWinner = true;
            }

            CheckIsWinner(isWinner);
        }

        //
        // Checks who the winner is, displays who won. If no one wins, displays that is a draw
        // Then user can choose to play again or close the application
        //

        private void CheckIsWinner(bool isWinner)
        {
            if (isWinner == true)
            {
                String whoWon = "";

                if (!myTurn == true)
                {
                    whoWon = "X";
                }
                else
                {
                    whoWon = "O";
                }

                if (MessageBox.Show(whoWon + " is the winner!\n\nDo you want to play again?", "You won",
                    MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
                {
                    ResetGame();
                }
                else
                {
                    App.Current.Shutdown();
                }
            }
            else
            {
                if (turnCounter == 9)
                {
                    if (MessageBox.Show("Draw!\n\nDo you want to play again?", "Draw",
                        MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
                    {
                        ResetGame();
                    }
                    else
                    {
                        App.Current.Shutdown();
                    }
                }
            }
        }

        //
        // Resets the game by erasing the button content, enabling buttons, make X start first again and resets the turn counter
        //

        private void ResetGame()
        {
            foreach (Button btn in GridTicTacToe.Children)
            {
                btn.Content = "";
                btn.Background = Brushes.Transparent;
                btn.IsEnabled = true;
            }

            turnCounter = 0;
            myTurn = true;
        }
    }
}