using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Matrix2
    {
        public float x1, x2, y1, y2;

        public Matrix2()
        {
            x1 = 1; y1 = 2;
            x2 = 3; y2 = 4;
        }
    }

    public struct Matrix3
    {
        public float x1, x2, x3, y1, y2, y3, z1, z2, z3;
        public Matrix3(float a1, float a2, float a3, float b1, float b2, float b3, float c1, float c2, float c3)
        {
            x1 = a1; y1 = b1; z1 = c1;
            x2 = a2; y2 = b2; z2 = c2;
            x3 = a3; y3 = b3; z3 = c3;
        }
        public static Matrix3 operator *(Matrix3 m1, Matrix3 m2)
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

        public void Scale(float x, float y, float z)
        {
            Matrix3 sm = new Matrix3();
            sm.SetScaled(x, y, z);

            Set(this * sm);
            Console.WriteLine(ToString());
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

            Set(this * m);
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

            Set(this * m);
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

            Set(this * m);
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
            xy = x * y;
            Set(xy * z);
        }

        public string ToString()
        {
            return $"{x1} {y1} {z1}\n{x2} {y2} {z2}\n{x3} {y3} {z3}";
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

        public static Vector3 operator +(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs.x + rhs.x,
                lhs.y + rhs.y,
                lhs.z + rhs.z);
        }

        public static Vector3 operator -(Vector3 lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs.x - rhs.x,
                lhs.y - rhs.y,
                lhs.z - rhs.z);
        }

        public static Vector3 operator *(Matrix3 m, Vector3 v)
        {
            return new Vector3(
                m.x1 * v.x + m.y1 * v.y + m.z1 * v.z,
                m.x2 * v.x + m.y2 * v.y + m.z2 * v.z,
                m.x3 * v.x + m.y3 * v.y + m.z3 * v.z);
        }

        public static Vector3 operator *(float lhs, Vector3 rhs)
        {
            return new Vector3(
                lhs * rhs.x,
                lhs * rhs.y,
                lhs * rhs.z);
        }

        public static Vector3 operator *(Vector3 lhs, float rhs)
        {
            return new Vector3(
                lhs.x * rhs,
                lhs.y * rhs,
                lhs.z * rhs);
        }

        public float Dot(Vector3 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z;
        }

        public Vector3 Cross(Vector3 rhs)
        {
            return new Vector3(
                y * rhs.z - z * rhs.y,
                z * rhs.x - x * rhs.z,
                x * rhs.y - y * rhs.x);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt((double)x * x + y * y + z * z);
        }

        public void Normalize()
        {
            float m = Magnitude();

            x /= m;
            y /= m;
            z /= m;
        }

        public string ToString()
        {
            return $"{x}\n{y}\n{z}";
        }
    }

    public struct Matrix4
    {
        public float x1, x2, x3, x4, y1, y2, y3, y4, z1, z2, z3, z4, w1, w2, w3, w4;

        public Matrix4(float a1, float a2, float a3, float a4, float b1, float b2, float b3, float b4, 
            float c1, float c2, float c3, float c4, float d1, float d2, float d3, float d4)
        {
            x1 = a1; y1 = b1; z1 = c1; w1 = d1;
            x2 = a2; y2 = b2; z2 = c2; w2 = d2;
            x3 = a3; y3 = b3; z3 = c3; w3 = d3;
            x4 = a4; y4 = b4; z4 = c4; w4 = d4;
        }

        public static Matrix4 operator *(Matrix4 m1, Matrix4 m2)
        {
            return new Matrix4(
                m1.x1 * m2.x1 + m1.y1 * m2.x2 + m1.z1 * m2.x3 + m1.w1 * m2.x4,
                m1.x1 * m2.y1 + m1.y1 * m2.y2 + m1.z1 * m2.y3 + m1.w1 * m2.y4,
                m1.x1 * m2.z1 + m1.y1 * m2.z2 + m1.z1 * m2.z3 + m1.w1 * m2.z4,
                m1.x1 * m2.w1 + m1.y1 * m2.w2 + m1.z1 * m2.w3 + m1.w1 * m2.w4,
                m1.x2 * m2.x1 + m1.y2 * m2.x2 + m1.z2 * m2.x3 + m1.w2 * m2.x4,
                m1.x2 * m2.y1 + m1.y2 * m2.y2 + m1.z2 * m2.y3 + m1.w2 * m2.y4,
                m1.x2 * m2.z1 + m1.y2 * m2.z2 + m1.z2 * m2.z3 + m1.w2 * m2.z4,
                m1.x2 * m2.w1 + m1.y2 * m2.w2 + m1.z2 * m2.w3 + m1.w2 * m2.w4,
                m1.x3 * m2.x1 + m1.y3 * m2.x2 + m1.z3 * m2.x3 + m1.w3 * m2.x4,
                m1.x3 * m2.y1 + m1.y3 * m2.y2 + m1.z3 * m2.y3 + m1.w3 * m2.y4,
                m1.x3 * m2.z1 + m1.y3 * m2.z2 + m1.z3 * m2.z3 + m1.w3 * m2.z4,
                m1.x3 * m2.w1 + m1.y3 * m2.w2 + m1.z3 * m2.w3 + m1.w3 * m2.w4,
                m1.x4 * m2.x1 + m1.y4 * m2.x2 + m1.z4 * m2.x3 + m1.w4 * m2.x4,
                m1.x4 * m2.y1 + m1.y4 * m2.y2 + m1.z4 * m2.y3 + m1.w4 * m2.y4,
                m1.x4 * m2.z1 + m1.y4 * m2.z2 + m1.z4 * m2.z3 + m1.w4 * m2.z4,
                m1.x4 * m2.w1 + m1.y4 * m2.w2 + m1.z4 * m2.w3 + m1.w4 * m2.w4);
        }

        public void Set(Matrix4 input)
        {
            x1 = input.x1;
            x2 = input.x2;
            x3 = input.x3;
            x4 = input.x4;
            y1 = input.y1;
            y2 = input.y2;
            y3 = input.y3;
            y4 = input.y4;
            z1 = input.z1;
            z2 = input.z2;
            z3 = input.z3;
            z4 = input.z4;
            w1 = input.w1;
            w2 = input.w2;
            w3 = input.w3;
            w4 = input.w4;
        }

        public void SetRotateX(double radians)
        {
            Matrix4 srx = new Matrix4(1, 0, 0, 0,
                0, (float)Math.Cos(radians), (float)Math.Sin(radians), 0,
                0, (float)-Math.Sin(radians), (float)Math.Cos(radians), 0,
                0, 0, 0, 1);

            Set(srx);
        }

        public void SetRotateY(double radians)
        {
            Matrix4 sry = new Matrix4((float)Math.Cos(radians), 0, (float)-Math.Sin(radians), 0,
                0, 1, 0, 0,
                (float)Math.Sin(radians), 0, (float)Math.Cos(radians), 0,
                0, 0, 0, 1);

            Set(sry);
        }

        public void SetRotateZ(double radians)
        {
            Matrix4 srz = new Matrix4((float)Math.Cos(radians), (float)Math.Sin(radians), 0, 0,
                (float)-Math.Sin(radians), (float)Math.Cos(radians), 0, 0,
                0, 0, 1, 0,
                0, 0, 0, 1);

            Set(srz);
        }

        public string ToString()
        {
            return $"{x1} {y1} {z1} {w1}\n{x2} {y2} {z2} {w2}\n{x3} {y3} {z3} {w3}\n{x4} {y4} {z4} {w4}";
        }
    }

    public struct Vector4
    {
        public float x, y, z, w;

        public Vector4(float a, float b, float c, float d)
        {
            x = a;
            y = b;
            z = c;
            w = d;
        }
        public static Vector4 operator +(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(
                lhs.x + rhs.x,
                lhs.y + rhs.y,
                lhs.z + rhs.z,
                lhs.w + rhs.w);
        }

        public static Vector4 operator -(Vector4 lhs, Vector4 rhs)
        {
            return new Vector4(
                lhs.x - rhs.x,
                lhs.y - rhs.y,
                lhs.z - rhs.z,
                lhs.w - rhs.w);
        }

        public static Vector4 operator *(Matrix4 m, Vector4 v)
        {
            return new Vector4(
                m.x1 * v.x + m.y1 * v.y + m.z1 * v.z + m.w1 * v.w,
                m.x2 * v.x + m.y2 * v.y + m.z2 * v.z + m.w2 * v.w,
                m.x3 * v.x + m.y3 * v.y + m.z3 * v.z + m.w3 * v.w,
                m.x4 * v.x + m.y4 * v.y + m.z4 * v.z + m.w4 * v.w);
        }

        public static Vector4 operator *(float lhs, Vector4 rhs)
        {
            return new Vector4(
                lhs * rhs.x,
                lhs * rhs.y,
                lhs * rhs.z,
                lhs * rhs.w);
        }

        public static Vector4 operator *(Vector4 lhs, float rhs)
        {
            return new Vector4(
                lhs.x * rhs,
                lhs.y * rhs,
                lhs.z * rhs,
                lhs.w * rhs);
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt((double) x * x + y * y + z * z + w * w);
        }

        public void Normalize()
        {
            float m = Magnitude();

            x /= m;
            y /= m;
            z /= m;
            w /= m;
        }

        public float Dot(Vector4 rhs)
        {
            return x * rhs.x + y * rhs.y + z * rhs.z + w * rhs.w;
        }

        public Vector4 Cross(Vector4 rhs)
        {
            return new Vector4(
                y * rhs.z - z * rhs.y,
                z * rhs.x - x * rhs.z,
                x * rhs.y - y * rhs.x,
                0);
        }
    }


    public class IdentityMatrix
    {
        public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

        public IdentityMatrix()
        {
            m1 = 1; m4 = 0; m7 = 0;
            m2 = 0; m5 = 1; m8 = 0;
            m3 = 0; m6 = 0; m9 = 1;
        }
    }
    class Program
    {
        public static void AxisAccess()
        {
            Matrix3 M3 = new Matrix3();
            string input = Console.ReadLine();

            bool stay = true;
            while(stay)
            {
                if(input == "x")
                {
                    Console.WriteLine($"{M3.x1}, {M3.x2}, {M3.x3}");
                    Console.ReadKey();
                    stay = false;
                }
                else if(input == "y")
                {
                    Console.WriteLine($"{M3.y1}, {M3.y2}, {M3.y3}");
                    Console.ReadKey();
                    stay = false;
                }
                else if(input == "z")
                {
                    Console.WriteLine($"{M3.z1}, {M3.z2}, {M3.z3}");
                    Console.ReadKey();
                    stay = false;
                }
                else
                {
                    Console.WriteLine("Invalid input, try again");
                    input = Console.ReadLine();
                }
            }
            
        }
        public static void Transpose()
        {
            Matrix3 M3t = new Matrix3();

            Console.WriteLine(
                $"{M3t.x1}, {M3t.x2}, {M3t.x3}\n" +
                $"{M3t.y1}, {M3t.y2}, {M3t.y3}\n" +
                $"{M3t.z1}, {M3t.z2}, {M3t.z3}");
            Console.ReadLine();
        }
     
        static void Main(string[] args)
        {
            //AxisAccess();
            //Transpose();

            //Matrix3 m1 = new Matrix3(9,6,3,8,5,2,7,4,1);
            //Matrix3 m2 = new Matrix3(1,4,7,2,5,8,3,6,9);

            //Matrix3 result = Matrix3.Multiply(m1, m2);

            //Console.WriteLine(result.ToString());
            //Console.ReadLine();

            //Vector3 v = new Vector3(2, 4, 6);
            //Matrix3 m = new Matrix3(90, 114, 138, 54, 69, 84, 18, 24, 30);

            //Vector3 result = (m * v);

            //Console.WriteLine(result.ToString());
            //Console.ReadLine();


            Matrix4 m4b = new Matrix4();
            m4b.SetRotateY(-2.6f);

            Matrix4 m4c = new Matrix4();
            m4c.SetRotateZ(0.72f);

            Matrix4 m4d = m4c * m4b;

            Console.WriteLine(m4d.ToString());
            Console.ReadLine();
        }
    }
}
