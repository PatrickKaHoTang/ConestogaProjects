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
using System.Threading.Tasks;

namespace A5PatrickTang
{
    class Concert
    {
        // Used to store an array of customer names
        private string[] _seats = new string[16]; // 16 seats

        // Checks if the name has characters or digits in the field
        // If characters, will not throw exception
        // If digits, will throw exception
        private bool IsValidName(string name) // Rubens helped me with this method
        {
            bool valid = true;
            if (name.Length < 2)
            {
                valid = false;
            }
            else
            {
                for (int i = 0; i < name.Length; i++)
                {
                    if (!char.IsLetter(name[i]))
                    {
                        valid = false;
                        break;
                    }
                }
            }
            return valid;
        }

        // Reserves a seat for the specified customer
        public void Reserve(string name, int seatNumber)
        {
            if (IsValidName(name)) // Rubens helped me with this statement
            {
                if (_seats[seatNumber] == null)
                {
                    _seats[seatNumber] = name;
                }
                else
                {
                    throw new Exception("This seat has been reserved.");
                }
            }
            else
            {
                throw new Exception("You must enter a valid name and two or more characters.");
            }
        }

        // Unreserves all seats associated with the specified customer
        public void Unreserve(string name)
        {
            if (IsValidName(name))  // Rubens helped me with with throwing these exceptions
            {
                bool buttonFound = false;
                for (int seatNumber = 0; seatNumber < _seats.Length; ++seatNumber)
                {
                    if (IsReserved(seatNumber) && GetReservation(seatNumber).Equals(name))
                    {
                        buttonFound = true;

                        Unreserve(seatNumber);
                    }
                }
                if (buttonFound == false)
                {
                    throw new Exception("There is no reservation with this name to unreserve.");
                }
            }
            else
            {
                throw new Exception("You must enter a valid name.");
            }
        }

        // Unreserves the specified seat
        public void Unreserve(int seatNumber)
        {
            if (seatNumber > 15) // Rubens helped me with throwing these exceptions
            {
                throw new Exception("You must select a seat number between 0-15.");
            }
            else if (_seats[seatNumber] != null)
            {
                _seats[seatNumber] = null;
            }
            else
            {
                throw new Exception("Unable to unreserve an empty seat.");
            }
        }

        // Returns the name of the customer associated with the specified seat
        public string GetReservation(int seatNumber)
        {
            return _seats[seatNumber];
        }

        // Returns true if the specified seat is reserved
        public bool IsReserved(int seatNumber)
        {
            return GetReservation(seatNumber) != null;
        }

        // Gets the number of available seats
        public int SeatsAvailable
        {
            get
            {
                int count = 0;

                foreach (string name in _seats)
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
