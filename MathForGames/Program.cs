using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathForGames
{
    class Program
    {
        static float FunctionA(float x)
        {
            float y;
            y = x * x + 2 * x - 7;
            return y;
        }

        static void FunctionB(double a, double b, double c)
        {
            double y = b * b - 4 * a * c;
            double root = Math.Sqrt(y);
            if (root < 0)
            {
                Console.WriteLine("Polynomial has no roots");
                Console.ReadKey();
            }
            else
            {
                double plus = (b * (-1) + root) / (2 * a);
                double minus = (b * (-1) - root) / (2 * a);
                Console.WriteLine($"{plus}, {minus}");
                Console.ReadKey();
            }
        }

        static float FunctionC(float s, float e, float t)
        {
            float y;
            y = s + t * (e - s);
            return y;
        }

        static double FunctionD(int x1, int y1, int x2, int y2)
        {
            double eq = (x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1);
            double root = Math.Sqrt(eq);
            return root;
        }

        static int FunctionE(int x1, int y1, int z1, int x2, int y2, int z2)
        {
            int inner = (x1 * x2) + (y1 * y2) + (z1 * z2);
            return inner;
        }

        static void Main(string[] args)
        {
            float r = FunctionA(3f);
            Console.WriteLine(r);
            Console.ReadKey();

            FunctionB(5, 6, 1);

            float s = FunctionC(2, 5, 4);
            Console.WriteLine(s);
            Console.ReadKey();

            double t = FunctionD(2, 3, 10, 7);
            Console.WriteLine(t);
            Console.ReadKey();

            int u = FunctionE(2, 5, 6, 3, 1, 9);
            Console.WriteLine(u);
            Console.ReadKey();
        }
    }
}
