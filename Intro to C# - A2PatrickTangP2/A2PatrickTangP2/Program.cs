/*
 * Program Name: A2PatrickTangP2
 * 
 * Purpose: To calculate the volume of a sphere, cylinder and a rectangular prism
 * 
 * Revision History:
 * Patrick Tang, 2015.10.09: Created
 * Patrick Tang, 2015.10.16: Revised application to use the bool statement and revised the code to fit the assignment's criteria
 * Patrick Tang. 2015.10.22: Added try-catch to code
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2PatrickTangP2
{
    class Program
    {
        // Used to specify the value of PI
        public const double PI = 3.14159;

        // Calculates the volume of a sphere
        public static double CalculateVolume(double r)
        {
            return ((4.0 / 3.0) * PI) * Math.Pow(r, 3.0);
        }

        // Calculates the volume of a cylinder
        public static double CalculateVolume(double r, double h)
        {
            return (PI * h) * Math.Pow(r, 2.0);
        }

        // Calculates the volume of a rectangular prism
        public static double CalculateVolume(double l, double w, double h)
        {
            return (l * w) * h;
        }
        public static void Main(string[] args)
        {
            bool keepGoing = true;
            do
            {
                // Prompting the user to make a selection
                Console.WriteLine("What shape would you like to calculate the volume of?");
                Console.WriteLine("Please select one option (1, 2, 3, or 4)");
                Console.WriteLine("1 - Volume of a sphere");
                Console.WriteLine("2 - Volume of a cylinder");
                Console.WriteLine("3 - Volume of a rectangular prism");
                Console.WriteLine("4 - Exit the program");

                try
                {
                    // Prompting the user to choose 1, 2, 3, or 4
                    string userAnswer = Console.ReadLine().Trim();
                    if (userAnswer.Equals("1"))
                    {
                        // Calculate and display the volume of a sphere
                        Console.WriteLine("You chose a sphere.");
                        Console.WriteLine("Please enter a radius:");
                        double r = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("The volume of the sphere is: {0}", CalculateVolume(r));
                        Console.WriteLine();
                    }
                    else if (userAnswer.Equals("2"))
                    {
                        // Calculate and display the volume of a cylinder
                        Console.WriteLine("You chose a cylinder.");
                        Console.WriteLine("Please enter a radius:");
                        double r = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Please enter a height:");
                        double h = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("The volume of the cylinder is: {0}", CalculateVolume(r, h));
                        Console.WriteLine();
                    }
                    else if (userAnswer.Equals("3"))
                    {
                        // Calculate and display the volume of a rectangular prism
                        Console.WriteLine("You chose a rectangular prism.");
                        Console.WriteLine("Please enter a length:");
                        double l = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Please enter a width:");
                        double w = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Please enter a height:");
                        double h = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("The volume of the rectangular prism is: {0}", CalculateVolume(l, w, h));
                        Console.WriteLine();
                    }
                    else if (userAnswer.Equals("4"))
                    {
                        // Exits program
                        break;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch(Exception)
                {
                    // Lets the user know that any incorrect input will display this message and lets them try again
                    Console.WriteLine("Invalid Input. Please try again.");
                    Console.WriteLine();
                }
            } while (keepGoing);
        }
    }
}
