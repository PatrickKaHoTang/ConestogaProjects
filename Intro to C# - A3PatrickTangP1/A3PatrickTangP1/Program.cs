/* 
 * Program name: A3PatrickTangP1
 * 
 * Purpose: Creating a math program that lets the user choose between selecting
 * a number of even numbers shown or displaying a sequence of perfect squares
 * 
 * Created:
 * Patrick Tang, 2015.10.28: Created
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A3PatrickTangP1
{
    class Program
    {
        private static void DisplayEvenNumbers()
        {
            // User selected even numbers and asking how many numbers the user would like to display
            Console.WriteLine("You have chosen even numbers.");
            Console.Write("How many even numbers would you like to display? ");

            int count = int.Parse(Console.ReadLine());
            Console.WriteLine();

            int n = 0;

            for (int i = 0; i < count; ++i)
            {
                Console.WriteLine(n);

                n += 2;
            }
            Console.WriteLine();
        }
        private static void DisplayPerfectSquares()
        {
            // User selected perfect squares and displays them by pressing Enter until the user types "No"
            int n = 1;

            Console.WriteLine("You have chosen perfect squares.");
            Console.WriteLine();      

            bool keepGoing = true;
            while (keepGoing)
            {
                Console.WriteLine("The square of {0} is {1}", n, (n * n));
                Console.Write("Press [ENTER] to continue, type 'No' to stop: ");

                ++n;

                string userAnswer = Console.ReadLine();
                if (userAnswer.Equals("No"))
                {
                    keepGoing = false;
                }
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            int selection = 0;

            do
            {
                // Prompting the user to make a selection
                Console.WriteLine("Which display would you like to see?");
                Console.WriteLine("Please select one option (1, 2, or 3)");
                Console.WriteLine("1 - Even numbers");
                Console.WriteLine("2 - Perfect squares");
                Console.WriteLine("3 - Exit the program");

                try
                {
                    // Asks user to choose a selection
                    selection = int.Parse(Console.ReadLine());

                    // Displays even numbers
                    if (selection == 1)
                    {
                        DisplayEvenNumbers();
                    }

                    // Displays perfect squares
                    else if (selection == 2)
                    {
                        DisplayPerfectSquares();
                    }
                }
                catch (Exception ex)
                {
                    // Displays an error exception if there is an invalid input
                    Console.WriteLine("Invalid input. Please try again.");
                }

            // Exits program
            } while (selection != 3);

            Console.WriteLine("Exiting the program...");
        }
    }
}
