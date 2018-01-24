/*
 * Program name: A5PatrickTang
 * 
 * Purpose: Creating a program to reserve concert seats
 * 
 * History:
 *  Patrick Tang, 2015.11.29: Created
 *  Patrick Tang, 2015.12.03: Concert.cs created with constructors and methods
 *  Patrick Tang, 2015.12.06: Slowly connecting code together with Concert.cs to GUI
 *  Patrick Tang, 2015.12.08: Finishing up mock-up GUI
 *  Patrick Tang, 2015.12.10: Retouching on GUI
 *  Patrick Tang, 2015.12.11: Attempting to make exceptions to work with program
 *  Patrick Tang, 2015.12.11: Getting some help from Rubens with throwing exceptions
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace A5PatrickTang
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Used to manage concert reservations
        private Concert _concert = new Concert();

        // Default constructor
        public MainWindow()
        {
            InitializeComponent();
        }

        // Updates the concert's seat reservation UI
        private void UpdateSeatButtons()
        {
            foreach (Button button in GridSeats.Children)
            {
                int seatNumber = Convert.ToInt32(button.Tag);

                string name = _concert.GetReservation(seatNumber);

                button.Content = String.Format("{0}. {1}", seatNumber, name);
            }
        }

        // Called when the window has been initialized
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            // Initialize the program

            radAdd.IsChecked = true;

            UpdateSeatButtons();
        }

        // Called when an operational radio button has been checked
        private void radAdd_Checked(object sender, RoutedEventArgs e)
        {
            if (radAdd.IsChecked == true)
            {
                if (_concert.SeatsAvailable == 0)
                {
                    MessageBox.Show("There are no seats available", "Notice",
                        MessageBoxButton.OK, MessageBoxImage.Information);

                    radRemove.IsChecked = true;
                }
            }

            txtName.Text = "";
            txtSeat.Text = "";
        }

        // Called when the 'Remove' button has been clicked
        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            string name = txtName.Text.Trim();
            string seat = txtSeat.Text.Trim();

            try
            {
                // Ensure that enough information has been provided by the user
                if (((name.Length == 0) && (seat.Length == 0)) || 
                    ((name.Length != 0) && (seat.Length != 0)))
                {
                    throw new Exception("Please specify either a name OR seat number (but not both)");
                }

                if (name.Length != 0)
                {
                    // Unreserve all seats associated with the customer

                    _concert.Unreserve(name);
                }
                else
                {
                    // Unreserve an individual seat

                    int seatNumber;

                    if (!int.TryParse(seat, out seatNumber))
                    {
                        throw new Exception("You must select a seat number between 0-15.");
                    }
                    else
                    {
                        _concert.Unreserve(seatNumber);
                    }

                }

                UpdateSeatButtons();

                MessageBox.Show("Operation completed.", "Notice",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Called when a seat button has been clicked
        private void BtnSeat_Click(object sender, RoutedEventArgs e)
        {
         // Button button = sender as Button;
            Button button = e.OriginalSource as Button;

            try
            {
                // Reserve a seat

                int seatNumber = Convert.ToInt32(button.Tag);

                string name = txtName.Text.Trim();

                _concert.Reserve(name, seatNumber);

                UpdateSeatButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            e.Handled = true;
        }
    }
}
