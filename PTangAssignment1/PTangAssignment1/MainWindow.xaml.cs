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

namespace PTangAssignment1
{
    /// <summary>
    /// Program name: PTangAssignment1
    ///
    /// Purpose: Creating a program to reserve airline reservations with interactive buttons
    /// 
    /// Created by Patrick Tang
    /// 
    /// History:
    ///     September 13, 2016 - Created
    ///     September 18, 2016 - Added code to separate classes
    ///                             -> Reserveration.cs
    ///                             -> WaitList.cs
    ///     September 19, 2016 - Added code to buttons
    ///     September 20, 2016 - Fixed crashes
    ///     September 21, 2016 - Added most requirements
    ///     September 23, 2016 - Changed from the old format(2 cs files)
    ///     Note: It was giving me a headache
    ///     September 24, 2016 - Added waiting list -> reserve list function
    /// </summary>
    public partial class MainWindow : Window
    {
        //
        // Used to store an array of customer names (15 seats)
        //

        private string[,] seats = new string[5, 3];

        //
        // Used to store an array of customer names in wait list (10 seats max)
        // 
        private string[] waitList = new string[10];

        //
        // Used to colour coordinate reserved (red) vs not reserved (green)
        //

        private Button[,] seatGrid = new Button[5, 3];

        //
        // On initialize
        //
        public MainWindow()
        {
            InitializeComponent();

            seatGrid[0, 0] = btn0;
            seatGrid[0, 1] = btn1;
            seatGrid[0, 2] = btn2;
            seatGrid[1, 0] = btn3;
            seatGrid[1, 1] = btn4;
            seatGrid[1, 2] = btn5;
            seatGrid[2, 0] = btn6;
            seatGrid[2, 1] = btn7;
            seatGrid[2, 2] = btn8;
            seatGrid[3, 0] = btn9;
            seatGrid[3, 1] = btn10;
            seatGrid[3, 2] = btn11;
            seatGrid[4, 0] = btn12;
            seatGrid[4, 1] = btn13;
            seatGrid[4, 2] = btn14;

            listBoxA.Items.Clear();
            listBoxA.Items.Add("A");
            listBoxA.Items.Add("B");
            listBoxA.Items.Add("C");
            listBoxA.Items.Add("D");
            listBoxA.Items.Add("E");

            listBoxB.Items.Clear();
            listBoxB.Items.Add("0");
            listBoxB.Items.Add("1");
            listBoxB.Items.Add("2");
        }

        //
        // Called when "Fill All" button has been clicked
        //
        private void btnFillAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (seats[i, j] == null)
                        {
                            Reserve("Reserved", i, j);
                            seatGrid[i, j].Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //
        // Called when "Book" button has been clicked
        //
        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxA.SelectedIndex != -1 || listBoxB.SelectedIndex != -1)
                {
                    if (SeatsAvailable == 0)
                    {
                        if (WaitListAvailable == 0)
                        {
                            MessageBox.Show("Waiting list is full.");
                        }
                        else
                        {
                            string name = textBoxName.Text.Trim();

                            for (int i = 0; i < 10; i++)
                            {
                                WaitingList(name, i);
                            }
                        }
                    }
                    else
                    {
                        string name = textBoxName.Text.Trim();
                        int i = listBoxA.SelectedIndex;
                        int j = listBoxB.SelectedIndex;

                        Reserve(name, i, j);
                        seatGrid[i, j].Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));

                        MessageBox.Show("Seat " + listBoxA.Items[i].ToString() + listBoxB.Items[j].ToString() + " has been reserved by " + name);
                    }
                }
                else
                {
                    throw new Exception("Please select a seat position.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //
        // Called when "Cancel" button has been clicked
        //
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxA.SelectedIndex != -1 || listBoxB.SelectedIndex != -1)
                {
                    int i = listBoxA.SelectedIndex;
                    int j = listBoxB.SelectedIndex;

                    Unreserve(i, j);
                    seatGrid[i, j].Background = new SolidColorBrush(Color.FromRgb(0, 255, 0));

                    MessageBox.Show("Seat " + listBoxA.Items[i].ToString() + listBoxB.Items[j].ToString() + " has been unreserved");

                    seats[i, j] = waitList[0];
                    waitList[0] = null;

                    if (waitList[0] == null)
                    {
                        Array.Copy(waitList, 1, waitList, 0, waitList.Length - 1);
                        waitList[9] = null;
                        MessageBox.Show("Seat " + listBoxA.Items[i].ToString() + listBoxB.Items[j].ToString() + " has been reserved by " + seats[i, j] + " from the waiting list");
                        seatGrid[i, j].Background = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    }
                }
                else
                {
                    throw new Exception("Please select a seat position");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //
        // Called when "Add to Waiting List" button has been clicked
        //
        private void btnAddWaitingList_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (SeatsAvailable == 0)
                {
                    string name = textBoxName.Text.Trim();

                    for (int i = 0; i < 10; i++)
                    {
                        WaitingList(name, i);
                    }
                }
                else
                {
                    MessageBox.Show("Seats are available. Please click on \"Show All\".");
                }

                if (WaitListAvailable == 0)
                {
                    MessageBox.Show("The waiting list is full.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        //
        // Called when "Show Waiting List" button has been clicked
        //
        private void btnShowWaitingList_Click(object sender, RoutedEventArgs e)
        {
            richTextBoxWaitingList.Document.Blocks.Clear();

            for (int i = 0; i < 10; i++)
            {
                richTextBoxWaitingList.Document.Blocks.Add(new Paragraph(new Run(i + " - " + GetWaitList(i))));
            }
        }

        //
        // Called when "Show All" button has been clicked
        //
        private void btnShowAll_Click(object sender, RoutedEventArgs e)
        {
            richTextBoxShowAll.Document.Blocks.Clear();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    richTextBoxShowAll.Document.Blocks.Add(new Paragraph(new Run(listBoxA.Items[i].ToString() + listBoxB.Items[j].ToString() + " - " + GetPassengerName(i, j))));
                }
            }
        }

        //
        // Called when "Status" button has been clicked
        //
        private void btnStatus_Click(object sender, RoutedEventArgs e)
        {
            int i = listBoxA.SelectedIndex;
            int j = listBoxB.SelectedIndex;

            if (IsReserved(i, j) != true)
            {
                textBoxStatus.Text = "Available";
            }
            else
            {
                textBoxStatus.Text = "Unavailable";
            }
        }

        //
        // Selections for list box (Letters)
        //

        private void listBoxA_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBoxA.Items.Clear();
            listBoxA.Items.Add("A");
            listBoxA.Items.Add("B");
            listBoxA.Items.Add("C");
            listBoxA.Items.Add("D");
            listBoxA.Items.Add("E");
        }

        //
        // Selections for list box (Numbers)
        //

        private void listBoxB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            listBoxB.Items.Clear();
            listBoxB.Items.Add("0");
            listBoxB.Items.Add("1");
            listBoxB.Items.Add("2");
        }

        //
        // Checks to see if the name is valid and is longer than 1 character
        // If the name has any digits, it will throw an exception
        //
        private bool IsValidName(string name)
        {
            bool isValidName = true;

            if (name.Length < 1)
            {
                isValidName = false;
            }
            else
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if (!char.IsLetter(name[i]))
                    {
                        isValidName = false;
                        break;
                    }
                }
            }
            return isValidName;
        }

        //
        // Unreserves the seat for the specified customer
        //

        public void Unreserve(int i, int j)
        {
            if (seats[i, j] != null)
            {
                seats[i, j] = null;
            }
            else
            {
                throw new Exception("Unable to unreserve an empty seat.");
            }
        }

        //
        // Reserves the name to the specified seat
        //
        public void Reserve(string name, int i, int j)
        {
            if (IsValidName(name))
            {
                if (seats[i, j] == null)
                {
                    seats[i, j] = name;
                }
                else
                {
                    throw new Exception("This seat has been reserved.");
                }
            }
            else
            {
                throw new Exception("You must enter a valid name.");
            }
        }

        //
        // Returns true if the specified seat is reserved
        //
        public bool IsReserved(int i, int j)
        {
            return GetReservation(i, j) != null;
        }

        //
        // Returns the name of the customer associated with the specified seat
        //
        public string GetReservation(int i, int j)
        {
            return seats[i, j];
        }

        //
        // Gets the number of available seats
        //
        public int SeatsAvailable
        {
            get
            {
                int count = 0;

                foreach (string name in seats)
                {
                    if (name == null)
                    {
                        ++count;
                    }
                }
                return count;
            }
        }

        //
        // Returns name of passenger in specified seat
        //
        public string GetPassengerName(int i, int j)
        {
            return seats[i, j];
        }

        public void WaitingList(string name, int i)
        {
            if (IsValidName(name))
            {
                if (waitList[i] == null)
                {
                    waitList[i] = name;
                    throw new Exception(name + " has been added to the waiting list");
                }
            }
            else
            {
                throw new Exception("You must enter a valid name.");
            }
        }

        //
        // Returns the names of the customers in waiting list
        //
        public string GetWaitList(int i)
        {
            return waitList[i];
        }

        //
        // Gets waiting list
        //
        public int WaitListAvailable
        {
            get
            {
                int count = 0;

                foreach (string name in waitList)
                {
                    if (name == null)
                    {
                        ++count;
                    }
                }
                return count;
            }
        }
    }
}
