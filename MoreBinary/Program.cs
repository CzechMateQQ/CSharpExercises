using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoreBinary
{
    class Program
    {
        public static bool IsLeftMostBitSet(int value)
        {
            const byte check = 0x01 << 7;
            if ((value & check) == check)
            {
                return true;

            }
            else
            {
                return false;
            }
        }

        public static bool IsRightMostBitSet(int value)
        {
            const byte check = 0x01;
            if ((value & check) == check)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsBitSet(int value, int bit_to_check)
        {
            int mask = 0x01 << bit_to_check;
            if ((value & mask) == mask)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void PrintBinary()
        {
            Console.WriteLine("Enter number");
            int input = int.Parse(Console.ReadLine());
            int[] array = new int[8];
            string arrayString = "";
            while(input / 2 >= 1)
            {
                for(int i =7; i >= 0; --i)
                {                  
                    if(input % 2 == 0)
                    {
                        array[i] = 0;
                    }
                    else if(input % 2 != 0)
                    {
                       
                        array[i] = 1;
                    }
                    input /= 2;
                }

                for(int idx = 0; idx < array.Length; ++idx)
                {
                    arrayString += array[idx];
                }
            }
            Console.WriteLine(arrayString);
            Console.ReadKey();
        }

        //public static int Get RightMostBitSet(int value)
        

        static void Main(string[] args)
        {
            const byte inputA = 0x01 << 7;
            bool resultA = IsLeftMostBitSet(inputA);
            Console.WriteLine("{0}", resultA);
            Console.ReadKey();

            const byte inputB = 0x01;
            bool resultB = IsRightMostBitSet(inputB);
            Console.WriteLine("{0}", resultB);
            Console.ReadKey();

            const byte inputC = 0x01 << 5;
            bool resultC = IsBitSet(inputC, 5);
            Console.WriteLine("{0}", resultC);
            Console.ReadKey();

            PrintBinary();
        }
    }
}
