/*
 * Program name: A4PatrickTang
 * 
 * Purpose: Creating a program to create and record information about a dog
 * 
 * History:
 *  Patrick Tang, 2015.11.13: Created
 *  Patrick Tang, 2015.11.14: DogRecord.cs created with constructors and methods
 *  Patrick Tang, 2015.11.19: Finishing the DogRecord code and making the program more presentable
 *  
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4PatrickTang
{
    class Program
    {
        private static DogRecord CreateRecord()
        {
            // Prompts user to create a dog record

            Console.Write("New name  : ");
            string name = Console.ReadLine();

            Console.Write("New breed : ");
            string breed = Console.ReadLine();

            Console.Write("New colour: ");
            string colour = Console.ReadLine();

            while (true)
            {
                Console.Write("New gender: ");
                string sex = Console.ReadLine();

                try
                {
                    return new DogRecord(name, breed, colour, sex);
                }
                catch (Exception ex)
                {
                    // Catches exception of an invalid input

                    Console.WriteLine(ex.Message);
                }
            }
        }
        static void Main(string[] args)
        {
            DogRecord record = null;

            while (true)
            {
                // Display the main menu

                Console.WriteLine("Please select one option [A, B, C, or D]:");
                Console.WriteLine();
                Console.WriteLine("A. Display the name, breed, colour, and sex of the dog (if one already exists)");
                Console.WriteLine("B. Add a new dog");
                Console.WriteLine("C. Edit an existing dog");
                Console.WriteLine("D. Exit the program");
                Console.WriteLine();
                Console.Write("> ");

                // Process the user's selection

                string selection = Console.ReadLine();

                StringComparison sc = StringComparison.CurrentCultureIgnoreCase;

                if (selection.Equals("A", sc))
                {
                    // Display the record if it exists

                    if (record != null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Displaying an existing record:");
                        Console.WriteLine();

                        record.DisplayDogInformation();
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No dog record exists");
                    }
                }
                else if (selection.Equals("B", sc))
                {
                    // Create the record if it doesn't exist

                    if (record == null)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Please enter the following information:");
                        Console.WriteLine();

                        record = CreateRecord();

                        Console.WriteLine();
                        Console.WriteLine("You have successfully added a record to the database.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("Dog record already exists");
                    }
                }
                else if (selection.Equals("C", sc))
                {
                    // Modify the record if it exists

                    if (record != null)
                    {

                        Console.WriteLine();
                        Console.WriteLine("Displaying an existing record:");
                        Console.WriteLine();

                        record.DisplayDogInformation();

                        Console.WriteLine();

                        // Replace the existing record with a new one

                        Console.WriteLine("Please edit the existing record:");
                        Console.WriteLine();

                        record = CreateRecord();

                        Console.WriteLine();
                        Console.WriteLine("You have successfully edited the existing record.");
                    }
                    else
                    {
                        Console.WriteLine();
                        Console.WriteLine("No dog record exists");
                    }
                }
                else if (selection.Equals("D", sc))
                {
                    // Exit the program

                    Console.WriteLine();
                    Console.WriteLine("Exiting the program...");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                }

                Console.WriteLine();
            }
        }
    }
}
