using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixTransform
{
    public struct Matrix3
    {
        public float x1, x2, x3, y1, y2, y3, z1, z2, z3;
        public Matrix3(float a1, float a2, float a3, float b1, float b2, float b3, float c1, float c2, float c3)
        {
            x1 = a1; y1 = b1; z1 = c1;
            x2 = a2; y2 = b2; z2 = c2;
            x3 = a3; y3 = b3; z3 = c3;
        }

        public void SetScaled(float x, float y, float z)
        {
            x1 = x; y1 = 0; z1 = 0;
            x2 = 0; y2 = y; z2 = 0;
            x3 = 0; y3 = 0; z3 = z;
        }

        public void Set(Matrix3 input)
        {
            x1 = input.x1;
            x2 = input.x2;
            x3 = input.x3;
            y1 = input.y1;
            y2 = input.y2;
            y3 = input.y3;
            z1 = input.z1;
            z2 = input.z2;
            z3 = input.z3;
        }

        public static Matrix3 Multiply(Matrix3 m1, Matrix3 m2)
        {
            return new Matrix3(
                m1.x1 * m2.x1 + m1.y1 * m2.x2 + m1.z1 * m2.x3,
                m1.x1 * m2.y1 + m1.y1 * m2.y2 + m1.z1 * m2.y3,
                m1.x1 * m2.z1 + m1.y1 * m2.z2 + m1.z1 * m2.z3,
                m1.x2 * m2.x1 + m1.y2 * m2.x2 + m1.z2 * m2.x3,
                m1.x2 * m2.y1 + m1.y2 * m2.y2 + m1.z2 * m2.y3,
                m1.x2 * m2.z1 + m1.y2 * m2.z2 + m1.z2 * m2.z3,
                m1.x3 * m2.x1 + m1.y3 * m2.x2 + m1.z3 * m2.x3,
                m1.x3 * m2.y1 + m1.y3 * m2.y2 + m1.z3 * m2.y3,
                m1.x3 * m2.z1 + m1.y3 * m2.z2 + m1.z3 * m2.z3);
        }

        public void Scale(float x, float y, float z)
        {
            Matrix3 sm = new Matrix3();
            sm.SetScaled(x, y, z);

            Set(Multiply(this, sm));
            Console.WriteLine(ToString());
        }

        public string ToString()
        {
            return $"{x1} {y1} {z1}\n{x2} {y2} {z2}\n{x3} {y3} {z3}";
        }

        public void SetRotateX(double radians)
        {
            Matrix3 srx = new Matrix3(1, 0, 0,
                0, (float)Math.Cos(radians), (float)Math.Sin(radians),
                0, (float)-Math.Sin(radians), (float)Math.Cos(radians));

            Set(srx);
        }

        public void RotateX(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateX(radians);

            Set(Multiply(this, m));
        }

        public void SetRotateY(double radians)
        {
            Matrix3 sry = new Matrix3((float)Math.Cos(radians), 0, (float)-Math.Sin(radians),
                0, 1, 0,
                (float)Math.Sin(radians), 0, (float)Math.Cos(radians));

            Set(sry);
        }

        public void RotateY(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateY(radians);

            Set(Multiply(this, m));
        }

        public void SetRotateZ(double radians)
        {
            Matrix3 srz = new Matrix3((float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 1);

            Set(srz);
        }

        public void RotateZ(double radians)
        {
            Matrix3 m = new Matrix3();
            m.SetRotateZ(radians);

            Set(Multiply(this, m));
        }

        public void SetEuler(float pitch, float yaw, float roll)
        {
            Matrix3 x = new Matrix3();
            Matrix3 y = new Matrix3();
            Matrix3 z = new Matrix3();

            x.SetRotateX(pitch);
            y.SetRotateY(yaw);
            z.SetRotateZ(roll);

            //Combine rotations in specified order
            Matrix3 xy = new Matrix3();
            xy = Multiply(x, y);
            Set(Multiply(xy, z));
        }
    }

    public struct Vector3
    {
        public float x, y, z;

        public Vector3(float a, float b, float c)
        {
            x = a;
            y = b;
            z = c;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
