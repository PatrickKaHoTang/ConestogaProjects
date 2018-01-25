using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// File name: PTangAssignment3/ProjectB/TimeConversion.cs
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

namespace ProjectB
{
    public static class TimeConversion
    {
        /// <summary>
        /// The Convert method will be calculating the total of the value with what the user chooses
        /// as the units of conversion.
        /// </summary>
        /// <param name="value">User input value from the console application</param>
        /// <param name="convertFrom">User input the unit that they would like to convert from</param>
        /// <param name="convertTo">User input the unit that they would like to convert to</param>
        /// <returns>Total value</returns>
        public static double Convert(double value, string convertFrom, string convertTo)
        {
            double total = value * GetMultiplierStub(ModifyInput(convertFrom), ModifyInput(convertTo));

            return total;
        }

        /// <summary>
        /// The ModifyInput method will convert the string input that the user inputs to a specific return
        /// (See Return for more information)
        /// </summary>
        /// <param name="input">User input from the console application</param>
        /// <returns>One of four inputs ("seconds", "minutes", "hours", "days"), or an ArgumentException</returns>
        private static string ModifyInput(string input)
        {
            if (input == "seconds" || input == "Seconds" || input == "s" || input == "S")
            {
                input = "seconds";
            }
            else if (input == "minutes" || input == "Minutes" || input == "m" || input == "M")
            {
                input = "minutes";
            }
            else if (input == "hours" || input == "Hours" || input == "h" || input == "H")
            {
                input = "hours";
            }
            else if (input == "days" || input == "Days" || input == "d" || input == "D")
            {
                input = "days";
            }
            else
            {
                throw new ArgumentException("Incorrect time unit");
            }

            return input;
        }

        /// <summary>
        /// Stub for GetMultiplierStub to ensure it gives the user only 60 as the multiplier
        /// </summary>
        /// <param name="convertFrom">User input the unit that they would like to convert from</param>
        /// <param name="convertTo">User input the unit that they would like to convert to</param>
        /// <returns>Returns 60 only</returns>
        private static double GetMultiplierStub(string convertFrom, string convertTo)
        {
            return 60;
        }
    }
}
