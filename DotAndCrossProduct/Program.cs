using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotAndCrossProduct
{
    class Program
    {
        public struct Vector3
        {
            public float x, y, z;
        }

        public static float x;
        public static float y;
        public static float z;

        public static float Dot(Vector3 rhs)
        {
            float scalar = x * rhs.x + y * rhs.y + z * rhs.z;
            return scalar;
        }
        static void Main(string[] args)
        {
            Dot();
        }
    }
}
