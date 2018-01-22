/*
 * Program Name: A2PatrickTangP1
 * 
 * Purpose: Creating a program to calculate a certain cost for the age of the student and if they are a Canadian citizen or an international student
 * 
 * Revision History:
 * Patrick Tang, 2015.10.13: Created
 * Patrick Tang, 2015.10.20: Added switch statement
 * Patrick Tang, 2015.10.22: Added total box, try-catch statement, code for math
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

namespace A2PatrickTangP1
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

        private int GetStudentAge()
        {
            try
            {
                return int.Parse(textAge.Text);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            double total = 0.0;

            int age = GetStudentAge();

            if (age <= 18) // 18 or below
            {
                total += 300.0;
            }
            else if (age <= 49) // 19 to 49
            {
                total += 500.0;
            }
            else // 50+
            {
                total += 400.0;
            }

            if (radioInternational.IsChecked == true)
            {
                total += 100.0;
            }

            switch (textMonth.Text)
            {
                case "January":
                case "Jan":
                case "February":
                case "Feb":
                case "March":
                case "Mar":
                case "April":
                case "Apr":
                    
                    total += 220.0;
                    break;

                case "May":
                case "June":
                case "Jun":
                case "July":
                case "Jul":
                case "August":
                case "Aug":

                    total += 150.0;
                    break;

                case "September":
                case "Sept":
                case "October":
                case "Oct":
                case "November":
                case "Nov":
                case "December":
                case "Dec":

                    total += 250.0;
                    break;

                default:
                    MessageBox.Show("Not a valid month. Please try again.");
                    break;
            }

            double tax = total * (13.0 / 100.0);

            textTotal.Text = "$" + (total + tax);
        }
    }
}
