using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConditionsADGP
{
    class Program
    {
        static void Main(string[] args)
        {
            int userAge;
            Console.WriteLine("Please enter your age:");
            int.TryParse(Console.ReadLine(), out userAge);
            Console.WriteLine($"You are {userAge} years old.");
            Console.ReadLine();
        }
    }
}
