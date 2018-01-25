using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// File name: PTangAssignment3/ProjectC/Program.cs
/// 
/// Purpose: Create a C# console application where a user can convert time between seconds, minutes,
/// hours and days.  Different projects will have different stubs and integration testing.
/// 
/// Specifics: Project A will have stubs for ModifyInputStub() and GetMultiplierStub()
///            Project B will have a stub for GetMultiplerStub()
///            Project C will have no stubs
///            PTangAssignment3 will have the full program
/// 
/// Created by Patrick Tang
/// 
/// History:
///          March 22, 2017 - Created and finished
///          March 23, 2017 - Added comments
/// </summary>

namespace ProjectC
{
    class Program
    {
        /// <summary>
        /// The UI of the program.  It will start by asking the user which option (userSelection) they would like
        /// to choose (Option 1 = Convert time and Option 2 = Exiting program).  Then it will ask the user
        /// what the value (value) they would like to convert from (convertFrom) and convert to (convertTo).
        /// After that is done, it will go to TimeConversion.cs to do the calculations and modify the user input
        /// (See TimeConversion.cs for more details).  This will continue until the user selects Option 2 to exit
        /// the program.
        /// </summary>
        /// <param name="args">Console Application</param>
        public static void Main(string[] args)
        {
            int userSelection = 0;

            double value;
            string convertFrom;
            string convertTo;

            do
            {
                Console.WriteLine("Please make a selection");
                Console.WriteLine("1. Convert time");
                Console.WriteLine("2. Exit");

                try
                {
                    userSelection = int.Parse(Console.ReadLine());

                    if (userSelection == 1)
                    {
                        Console.WriteLine("Enter a value:");
                        value = ValueInput();

                        Console.WriteLine("What would you like to convert from? (seconds, minutes, hours, days)");
                        convertFrom = Console.ReadLine();

                        Console.WriteLine("What would you like to convert to? (seconds, minutes, hours, days)");
                        convertTo = Console.ReadLine();

                        Console.WriteLine("Convert " + convertFrom + " to " + convertTo + ": " +
                                          TimeConversion.Convert(value, convertFrom, convertTo));
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
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (userSelection != 2);
        }

        /// <summary>
        /// The ValueInput method will parse a positive value that the user inputs, otherwise there will be an error
        /// that will show up until it is parsed correctly.
        /// </summary>
        /// <returns>A positive valueInput</returns>
        private static double ValueInput()
        {
            double valueInput;

            while (!double.TryParse(Console.ReadLine(), out valueInput) || valueInput <= 0.0)
            {
                Console.WriteLine("Please enter a value greater than 0. Please try again.");
            }

            return valueInput;
        }
    }
}
