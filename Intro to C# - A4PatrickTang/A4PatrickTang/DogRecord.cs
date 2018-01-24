/*
 * Program name: A4PatrickTang
 * 
 * Purpose: Creating a program to create and record information about a dog
 * 
 * History:
 *  Patrick Tang, 2015.11.13: Created
 *  Patrick Tang, 2015.11.14: DogRecord.cs created with constructors and methods
 *  Patrick Tang, 2015.11.19: Finishing creating DogRecord code and making the program more presentable
 *  
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4PatrickTang
{
    class DogRecord
    {
        // Used to store the dog's name
        private string _name;
        // Used to store the dog's breed
        private string _breed;
        // Used to store the dog's colour
        private string _colour;
        // Used to store the dog's sex
        private string _sex;
        public DogRecord()
        {
            // Default constructor

            EditDogInformation("", "", "", "Male");
        }
        public DogRecord(string name, string breed, string colour, string sex)
        {
            // Constructor that edits information with the following parametres

            EditDogInformation(name, breed, colour, sex);
        }
        public void DisplayDogInformation()
        {
            // Constructor that displays information with the following parametres

            Console.WriteLine("Name  : {0}", _name);
            Console.WriteLine("Breed : {0}", _breed);
            Console.WriteLine("Colour: {0}", _colour);
            Console.WriteLine("Sex   : {0}", _sex);
        }
        public void EditDogInformation(string name, string breed, string colour, string sex)
        {
            // Here we guarantee that '_sex' only ever contains "Male" or "Female"

            if (!sex.Equals("Male") && !sex.Equals("Female"))
            {
                throw new Exception("You must specify 'Male' or 'Female'");
            }

            _name = name;
            _breed = breed;
            _colour = colour;
            _sex = sex;
        }
    }
}
