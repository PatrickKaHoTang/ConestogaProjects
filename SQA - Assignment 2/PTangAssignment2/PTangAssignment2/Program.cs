using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// File name: PTangAssignment2/Program.cs
/// 
/// Purpose: Create a C# console application determining the correct type of a triangle, then use Git Bash
///          for version control, NUnit for unit testing, then explain the Control Flow Graph and Cyclomatic
///          Complexity in a word document
/// 
/// Created by Patrick Tang
/// 
/// History:
///          February 14, 2017 - Created
///                            - Added more code in Program.cs and TriangleSolver.cs
///          February 22, 2017 - Added comments and finished program
/// </summary>

namespace PTangAssignment2
{
    class Program
    {
        /// <summary>
        /// Frontend of the console application for TriangleSolver.cs
        /// </summary>
        /// <param name="args">Console Application</param>
        public static void Main(string[] args)
        {
            //
            // userSelection variable is for the menu in if statement, default is 0
            //
            int userSelection = 0;

            //
            // do-while loop that will continue until the user inputs 2 to exit program. User may choose
            // option 1 or option 2 in the menu displayed.  If option 1 is selected, it will analyze the
            // three inputs in TriangleSolver.cs and displays if the triangle is "Equilateral", "Isosceles",
            // "Scalene" or "not a valid triangle". (See TriangleSolver.cs for more information)
            //
            do
            {
                Console.WriteLine("Please make a selection:");
                Console.WriteLine("1. Enter triangle dimensions");
                Console.WriteLine("2. Exit");

                try
                {
                    userSelection = int.Parse(Console.ReadLine());

                    if (userSelection == 1)
                    {
                        //
                        // Small drawing to determine which side is what.
                        // NOTE: Not to scale
                        //
                        Console.WriteLine();
                        Console.WriteLine("  *");
                        Console.WriteLine("  **");
                        Console.WriteLine("A * * C");
                        Console.WriteLine("  *  *");
                        Console.WriteLine("  *****");
                        Console.WriteLine("    B");
                        Console.WriteLine("\n***Not to scale***\n");

                        Console.WriteLine("Please enter a number for side A, side B, and side C");
                        int sideAInput = EnterInput();
                        int sideBInput = EnterInput();
                        int sideCInput = EnterInput();

                        Console.WriteLine(TriangleSolver.Analyze(sideAInput, sideBInput, sideCInput));
                    }
                    else if (userSelection == 2)
                    {
                        Console.WriteLine("Exiting program...");
                    }
                    else
                    {
                        Console.WriteLine("Please select option 1 or option 2 only.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input. Please select a valid option.");
                }
            } while (userSelection != 2);
        }

        /// <summary>
        /// Called when the program starts with option 1
        /// </summary>
        /// <returns>Users input for length of sides for TriangleSolver.cs</returns>
        private static int EnterInput()
        {
            int enterInput;

            while (!int.TryParse(Console.ReadLine(), out enterInput) || enterInput < 1)
            {
                Console.WriteLine("Please enter a numeric value greater than 0. Try again.");
            }

            return enterInput;
        }
    }
}
