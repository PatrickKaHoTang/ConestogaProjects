using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTangAssignment1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Square square = new Square();

            int userSelection = 0;
            int enterLength;

            enterLength = EnterValue();
            square.ChangeSide(enterLength);

            do
            {
                Console.WriteLine("Please enter one of the following options:");
                Console.WriteLine("1. Get Square Side Length");
                Console.WriteLine("2. Change Square Side Length");
                Console.WriteLine("3. Get Square Perimeter");
                Console.WriteLine("4. Get Square Area");
                Console.WriteLine("5. Exit\n");

                try
                {
                    userSelection = int.Parse(Console.ReadLine());

                    if (userSelection == 1)
                    {
                        Console.WriteLine("\nThe lengths of the square are {0}\n", square.GetSide());
                    }
                    else if (userSelection == 2)
                    {
                        square.ChangeSide(EnterValue());
                    }
                    else if (userSelection == 3)
                    {
                        Console.WriteLine("\nThe perimeter of the square is {0}\n", square.GetPerimeter());
                    }
                    else if (userSelection == 4)
                    {
                        Console.WriteLine("\nThe area of the square is {0}\n", square.GetArea());
                    }
                    else if (userSelection == 5)
                    {
                        Console.WriteLine("\nExiting program...");
                    }
                    else
                    {
                        Console.WriteLine("\nPlease make a selection between 1-5\n");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nInvalid option. Please make another selection.\n");
                }
            } while (userSelection != 5);
        }

        private static int EnterValue()
        {
            int enterLength;

            do
            {
                Console.WriteLine("\nPlease enter a numeric value.\n");
            } while (!int.TryParse(Console.ReadLine(), out enterLength) || enterLength < 1);
            Console.WriteLine();

            return enterLength;
        }
    }
}
