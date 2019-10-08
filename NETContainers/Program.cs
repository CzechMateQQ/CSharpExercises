using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETContainers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> myList = new List<int>();
            myList.Add(10);
            myList.Add(1);
            foreach (int item in myList)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }
    }
}
