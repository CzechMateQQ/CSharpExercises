using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank
{
    class Program
    {
        static void Main(string[] args)
        {
            //Given a square matrix, calculate the absolute difference between the sums of its diagonals
            int diagonalDifference(List<List<int>> arr)
            {
                int d1 = 0;
                int d2 = 0;
                for (int i = 0; i < arr.Count; ++i)
                {
                    d1 += arr[i][i];
                    d2 += arr[i][arr.Count - i - 1];
                }
                return Math.Abs(d1 - d2);
            }

            //Given an array of integers, calculate the fractions of its elements that are positive, negative, and are zeros
            static void plusMinus(int[] arr)
            {
                float pos = 0f;
                float neg = 0f;
                float zero = 0f;
                for (int i = 0; i < arr.Length; ++i)
                {
                    if (arr[i] > 0)
                    {
                        pos++;
                    }
                    else if (arr[i] < 0)
                    {
                        neg++;
                    }
                    else
                    {
                        zero++;
                    }
                }
                Console.WriteLine($"{pos / arr.Length}");
                Console.WriteLine($"{neg / arr.Length}");
                Console.WriteLine($"{zero / arr.Length}");
            }

            //Print a staircase of size n using # symbols and spaces
            static void Main(string[] args)
            {
                int n = Convert.ToInt32(Console.ReadLine());
                for (int i = 1; i <= n; i++)
                {
                    string spaces = new String(' ', n - i);
                    string pound = new String('#', i);
                    Console.WriteLine(spaces + pound);
                }
                staircase(n);


            }
        }
    }
}
