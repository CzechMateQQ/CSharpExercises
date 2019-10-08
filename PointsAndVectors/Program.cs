using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsAndVectors
{
    class Program
    {
        public struct Vector2
        {
            public float x, y;
        }

        public struct Vector3
        {
            public float x, y, z;
        }

        public static Vector3 AddVectors(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(lhs.x + rhs.x, lhs.y + rhs.y, lhs.z + rhs.z);
        }
        static void Main(string[] args)
        {
        }
    }
}
