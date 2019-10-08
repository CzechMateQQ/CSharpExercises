using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trigonometry
{
    class Program
    {
        static double ToRadians(double deg)
        {
            double rad = (deg / 180) * Math.PI;
            return rad;
        }

        static double ToDegrees(double rad)
        {
            double deg = (rad / Math.PI) * 180;
            return deg;
        }
        static void Main(string[] args)
        {

        }
    }
}
