/*
 * Program Name: A3PatrickTangP2
 * 
 * Purpose: To calculate two inputs together and creating a result
 * 
 * Created:
 * Patrick Tang, 2015.10.27: Created
 * 
 */

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

namespace A3PatrickTangP2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Clears the result if there is an exception
                textResult.Clear();
                // Clears the error if it doesn't create an exception
                textError.Clear();
                
                // Creates an addition result
                int result = Int32.Parse(textValue1.Text) + Int32.Parse(textValue2.Text);

                // End result
                textResult.Text = result.ToString();
            }
            catch (FormatException ex)
            {
                // Creates an error if there are non-numeric characters in the textbox
                textResult.Text = "ERROR";
                textError.Text = "You cannot use non-numeric characters.";
            }
            catch (OverflowException ex)
            {
                // Creates an error if the numbers exceed -2147483648 and 2147483647
                textResult.Text = "ERROR";
                textError.Text = "Numbers are too large to be calculated.";
            }
        }

        private void btnSubtract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Clears the result if there is an exception
                textResult.Clear();
                // Clears the error if it doesn't create an exception
                textError.Clear();

                // Creates a subtraction result
                int result = Int32.Parse(textValue1.Text) - Int32.Parse(textValue2.Text);

                // End result
                textResult.Text = result.ToString();
            }
            catch (FormatException ex)
            {
                // Creates an error if there are non-numeric characters in the textbox
                textResult.Text = "ERROR";
                textError.Text = "You cannot use non-numeric characters.";
            }
            catch (OverflowException ex)
            {
                // Creates an error if the numbers exceed -2147483648 and 2147483647
                textResult.Text = "ERROR";
                textError.Text = "Numbers are too large to be calculated.";
            }
        }

        private void btnMultiply_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Clears the result if there is an exception
                textResult.Clear();
                // Clears the error if it doesn't create an exception
                textError.Clear();

                // Creates a multiplication result
                int result = Int32.Parse(textValue1.Text) * Int32.Parse(textValue2.Text);

                // End result
                textResult.Text = result.ToString();
            }
            catch (FormatException ex)
            {
                // Creates an error if there are non-numeric characters in the textbox
                textResult.Text = "ERROR";
                textError.Text = "You cannot use non-numeric characters.";
            }
            catch (OverflowException ex)
            {
                // Creates an error if the numbers exceed -2147483648 and 2147483647
                textResult.Text = "ERROR";
                textError.Text = "Numbers are too large to be calculated.";
            }
        }

        private void btnDivide_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Clears the result if there is an exception
                textResult.Clear();
                // Clears the error if it doesn't create an exception
                textError.Clear();

                // Creates a division result
                int result = Int32.Parse(textValue1.Text) / Int32.Parse(textValue2.Text);

                // End result
                textResult.Text = result.ToString();
            }
            catch (DivideByZeroException ex)
            {
                // Creates an error if there "zero" is in the second input
                textResult.Text = "ERROR";
                textError.Text = "You cannot divide by zero.";
            }
            catch (FormatException ex)
            {
                // Creates an error if there are non-numeric characters in the textbox
                textResult.Text = "ERROR";
                textError.Text = "You cannot use non-numeric characters.";
            }
            catch (OverflowException ex)
            {
                // Creates an error if the numbers exceed -2147483648 and 2147483647
                textResult.Text = "ERROR";
                textError.Text = "Numbers are too large to be calculated.";
            }
        }

    }
}
