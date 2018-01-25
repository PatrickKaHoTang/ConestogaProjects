using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// File name: PTangAssignment3/ProjectA/TimeConversion.cs
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

namespace ProjectA
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
            double total = value * GetMultiplierStub(ModifyInputStub(convertFrom), ModifyInputStub(convertTo));

            return total;
        }
        /// <summary>
        /// Stub for ModifyInputStub to ensure it gives the user only minutes as a conversion
        /// </summary>
        /// <param name="input">Hard coded</param>
        /// <returns>"minutes"</returns>
        private static string ModifyInputStub(string input)
        {
            return "minutes";
        }

        /// <summary>
        /// Stub for GetMultiplierStub to ensure it gives the user only 60 as the multiplier
        /// </summary>
        /// <param name="convertFrom">"minutes"</param>
        /// <param name="convertTo">"minutes"</param>
        /// <returns>Returns 60 only</returns>
        private static double GetMultiplierStub(string convertFrom, string convertTo)
        {
            return 60;
        }
    }
}
