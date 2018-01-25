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

using System.IO;
using Microsoft.Win32;

namespace PTangAssignment3
{
    /// <summary>
    /// File name: PTangAssignment3
    /// 
    /// Purpose: Create a N-Puzzle game
    /// 
    /// Created by Patrick Tang
    /// 
    /// History:
    ///         October 18, 2016 - Created
    ///         October 18, 2016 - Added UI
    ///         October 21, 2016 - Added buttons with code to generate the playing field from the
    ///                            rows and columns textboxes
    ///                          - Added WindowSize() to dynamically change when the grid gets bigger
    ///                            than the default width size
    ///                          - Added CheckWin() and CheckIsWinner() to make sure the puzzle is in the
    ///                            correct order to beat the puzzle
    ///         October 22, 2016 - Added OpenFileDialog and SaveFileDialog (Opening window properly in WPF)
    ///         October 23, 2016 - Entered the struggle bus :(
    ///         October 24, 2016 - Added and fixed Randomize() to work
    ///         October 25, 2016 - Attempted to make MoveButton() and MoveNumber() work - unsuccessful
    ///         October 26, 2016 - Fixed MoveButton() and MoveNumber() to work properly
    ///                          - Fixing OpenFileDialog and SaveFileDialog to save and load a file properly
    ///                          - FINALLY exited the struggle bus! -_-; (Had assistance from Rubens and Jacob)
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private int[,] playField;                  // Creates playing field for the game
        private int rows = 3;                      // Determines the minimum amount of rows in the game
        private int columns = 3;                   // Determines the minimum amount of columns in the game
        private const int BTN_DIMENSION = 40;      // The size of the button in pixels
        private const int RANDOMIZE_NUMBER = 750;  // Number for randomizing the game

        private int emptyX;                        // Position X for the empty spot
        private int emptyY;                        // Position Y for the empty spot

        private int counter;                       // Counter for how many moves it takes to beat the game

        //
        // When clicked, the rows and columns will be generated to create a game grid
        //

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (int.Parse(textBoxRows.Text) > 2 && int.Parse(textBoxColumns.Text) > 2)
                {
                    rows = int.Parse(textBoxRows.Text);
                    columns = int.Parse(textBoxColumns.Text);

                    PopulateField();
                    PopulateBoard();
                }
                else
                {
                    throw new Exception("You must have both the rows and columns\ngreater than 3 to start the game");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        //
        // Populates the board by assigning numbers to buttons
        //

        private void PopulateField()
        {
            ResetGrid();

            playField = new int[rows, columns];
            int btnNumber = 1;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    playField[i, j] = btnNumber++;
                }
            }

            Randomize();
        }

        //
        // Populates the board by resetting everything, creating the buttons and grid separators 
        // (RowDefinition and ColumnDefinition) and resizing the window.  Also allows buttons to
        // move around from the MoveNumber_Click method
        //

        private void PopulateBoard()
        {
            ResetGrid();

            lblTextCounter.Content = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    // Separators in playing field

                    RowDefinition rowSeparator = new RowDefinition();
                    rowSeparator.Height = new GridLength(BTN_DIMENSION);
                    gridPlayField.RowDefinitions.Add(rowSeparator);

                    ColumnDefinition columnSeparator = new ColumnDefinition();
                    columnSeparator.Width = new GridLength(BTN_DIMENSION);
                    gridPlayField.ColumnDefinitions.Add(columnSeparator);

                    // Adds buttons to playing field

                    Button btn = new Button();

                    btn.Content = playField[i, j];
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);

                    btn.Click += MoveNumber_Click;

                    if (playField[i, j] == rows * columns)
                    {
                        emptyX = i;
                        emptyY = j;
                        btn.Content = null;
                        btn.IsEnabled = false;
                    }
                    else
                    {
                        btn.Click += MoveNumber_Click;
                    }

                    gridPlayField.Children.Add(btn);
                }
            }

            playField[emptyX, emptyY] = rows * columns;
            
            WindowSize();
        }

        //
        // Resets the game grid and counter
        //

        private void ResetGrid()
        {
            counter = 0;

            if (gridPlayField.RowDefinitions.Count > 0)
            {
                gridPlayField.Children.RemoveRange(0, gridPlayField.RowDefinitions.Count * gridPlayField.ColumnDefinitions.Count);
                gridPlayField.RowDefinitions.RemoveRange(0, gridPlayField.RowDefinitions.Count);
            }
        }

        //
        // Resizes window when it populates the board
        //

        private void WindowSize()
        {
            gridPlayField.Height = BTN_DIMENSION * rows;
            Application.Current.MainWindow.Height = (BTN_DIMENSION * rows) + gridPlayField.Margin.Top + gridPlayField.Margin.Left;

            gridPlayField.Width = BTN_DIMENSION * columns;
            Application.Current.MainWindow.Width = (BTN_DIMENSION * columns) + (gridPlayField.Margin.Left * 2);

            if (Application.Current.MainWindow.Width <= 525)
            {
                Application.Current.MainWindow.Width = 525;
            }
        }

        //
        // Randomizes the numbers with different positions on the grid
        //

        private void Randomize()
        {
            Random random = new Random();

            int temp;
            int posToX;
            int posToY;
            int posFromX;
            int posFromY;

            for (int i = 0; i < RANDOMIZE_NUMBER; i++)
            {
                posToX = random.Next(0, rows);
                posFromX = random.Next(0, rows);

                posToY = random.Next(0, columns);
                posFromY = random.Next(0, columns);

                temp = playField[posToX, posToY];
                playField[posToX, posToY] = playField[posFromX, posFromY];
                playField[posFromX, posFromY] = temp;
            }
        }
        
        //
        // Method for moving the button content (or number)
        //

        private void MoveNumber_Click(object sender, RoutedEventArgs e)
        {
            int fromX;
            int fromY;

            Button btnSwap = sender as Button;

            fromX = Grid.GetRow(btnSwap);
            fromY = Grid.GetColumn(btnSwap);

            if (emptyX == fromX && (emptyY == fromY + 1 || emptyY == fromY - 1))
            {
                counter++;
                lblTextCounter.Content = counter;
                MoveButton(btnSwap, fromX, fromY);                
            }
            else if (emptyY == fromY && (emptyX == fromX + 1 || emptyX == fromX - 1))
            {
                counter++;
                lblTextCounter.Content = counter;
                MoveButton(btnSwap, fromX, fromY);
            }
        }

        //
        // Method for moving the button itself, then checks to see if there is a win
        //

        private void MoveButton(Button btnSwap, int fromX, int fromY)
        {
            int temp;

            var emptySpace = gridPlayField.Children
                                          .Cast<Button>()
                                          .Where(i => Grid.GetRow(i) == emptyX &&
                                                      Grid.GetColumn(i) == emptyY);

            emptySpace.ElementAt(0).Content = btnSwap.Content;
            emptySpace.ElementAt(0).IsEnabled = true;

            btnSwap.Content = null;
            btnSwap.IsEnabled = false;

            temp = playField[fromX, fromY];
            playField[fromX, fromY] = playField[emptyX, emptyY];
            playField[emptyX, emptyY] = temp;

            emptyY = fromY;
            emptyX = fromX;

            CheckWin();
        }

        //
        // CheckWin() checks to see if the numbers are in order with the buttons
        //

        private void CheckWin()
        {
            bool isWinner = true;

            int isMatching = 1;
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (isMatching++ != playField[i, j])
                    {
                        isWinner = false;
                    }
                }
            }

            CheckIsWinner(isWinner);
        }

        //
        // If there is a winner, the player will be prompt if they would like to play again or not
        //

        private void CheckIsWinner(bool isWinner)
        {
            if (isWinner == true)
            {
                if (MessageBox.Show("You have solved the puzzle in " + counter + " move(s)!\nDo you want to play again?", "Congratulations",
                    MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
                {
                    lblTextCounter.Content = 0;
                    Randomize();
                    PopulateBoard();
                }
                else
                {
                    App.Current.Shutdown();
                }
            }
        }

        //
        // In this region, the btnSave_Click() and the doSave() saves .txt File
        //

        #region Save
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.InitialDirectory = "C:\\";                          // Default directory
            dialog.DefaultExt = ".text";                               // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt";             // Filter files by extension
            dialog.FileName = "N-Puzzle - " + rows + " by " + columns; // Default file name

            if (dialog.ShowDialog() == true)
            {
                doSave(dialog.FileName);
            }
        }

        private void doSave(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);

            string savedPlay = rows + "-" + columns;

            writer.WriteLine(savedPlay);

            for (int i = 0; i < rows; i++)
            {
                savedPlay = "";
                for (int j = 0; j < columns; j++)
                {
                    savedPlay += playField[i, j] + "-";
                }
                writer.WriteLine(savedPlay);
            }

            writer.WriteLine("\n" + rows * columns + " = Empty Space");
            writer.Close();
        }
        #endregion

        //
        // In this region, the btnLoad_Click() and the doLoad() loads a .txt file
        //

        #region Load
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            
            dialog.InitialDirectory = "C:\\~";   // Default directory

            if (dialog.ShowDialog() == true)
            {
                doLoad(dialog.FileName);
            }
        }

        private void doLoad(string filename)
        {
            StreamReader reader = new StreamReader(filename);

            string savedPlay = reader.ReadLine();
            int playFieldNum;
            int hyphenPosition = savedPlay.IndexOf("-");

            rows = int.Parse(savedPlay.Substring(0, hyphenPosition));
            columns = int.Parse(savedPlay.Substring(hyphenPosition + 1));

            textBoxRows.Text = rows.ToString();
            textBoxColumns.Text = columns.ToString();

            playField = new int[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                savedPlay = reader.ReadLine();
                for (int j = 0; j < columns; j++)
                {
                    hyphenPosition = savedPlay.IndexOf("-");
                    playFieldNum = int.Parse(savedPlay.Substring(0, hyphenPosition));
                    savedPlay = savedPlay.Substring(hyphenPosition + 1);
                    playField[i, j] = playFieldNum;
                }
            }

            reader.Close();

            PopulateBoard();
        }
        #endregion
    }
}
