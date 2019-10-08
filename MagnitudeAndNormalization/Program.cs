using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnitudeAndNormalization
{
    class Program
    {
        public float x;
        public float y;
        public float z;
        public static void Magnitude()
        {
            float x = 0.5f;
            float y = -1f;
            float z = 0.25f;

            float scalar = (float)Math.Sqrt(x * x + y * y + z * z);
            Console.WriteLine($"The magnitude is {scalar}");
        }

        public float MagnitudeSqr()
        {
            return (x * x + y * y + z * z);
        }

        public static void Distance()
        {
            float x = 0f;
            float y = 1f;
            float z = 2f;

            float a = 9f;
            float b = -2f;
            float c = 7f;

            float diffX = x - a;
            float diffY = y - b;
            float diffZ = z - c;
            float scalar = (float)Math.Sqrt(diffX * diffX + diffY * diffY + diffZ * diffZ);
            Console.WriteLine($"The distance is {scalar}");
        }

        public void Normalize()
        {
            float m = Magnitude();
            x /= m;
            y /= m;
            z /= m;
        }

        static void Main(string[] args)
        {
            Magnitude();
            Console.ReadLine();
            
            Distance();
            Console.ReadLine();
        }
    }
}
