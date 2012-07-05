using System;

namespace Cyclone.NET
{
    public class SleepEpsilon
    {
        static double sleepEpsilon;
        static void setSleepEpsilon(double value) { sleepEpsilon = value; }
        static double getSleepEpsilon() { return sleepEpsilon; }
    }

    public class Vector3
    {
        public double x;
        public double y;
        public double z;

        public Vector3()
        {
            x = y = z = 0.0f;
        }

        public Vector3(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        static readonly Vector3 GRAVITY = new Vector3(0, -9.8, 0);
        static readonly Vector3 HIGH_GRAVITY = new Vector3(0, -19.62, 0);
        static readonly Vector3 UP = new Vector3(0, 1, 0);
        static readonly Vector3 RIGHT = new Vector3(1, 0, 0);
        static readonly Vector3 OUT_OF_SCREEN = new Vector3(0, 0, 1);
        // a mistake in original cyclone code: x is set (0, 1, 0), y is set to (1,0,0)
        static readonly Vector3 X = new Vector3(1, 0, 0);
        static readonly Vector3 Y = new Vector3(0, 1, 0);
        static readonly Vector3 Z = new Vector3(0, 0, 1);

        public double this[UInt16 index]
        {
            get {
                switch (index)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    case 2:
                        return z;
                    default:
                        throw new Exception(string.Format("{0} wrong Vector3 index!", index));
                }
            }
            set {
                switch (index)
                {
                    case 0:
                        {
                            x = value;
                        }
                        break;
                    case 1:
                        {
                            y = value;
                        }
                        break;
                    case 2:
                        {
                            z = value;
                        }
                        break;
                    default:
                        throw new Exception(string.Format("{0} wrong Vector3 index!", index));
                }
            }
        }

        public static Vector3 operator  + (Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3 operator - (Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3 operator * (Vector3 v, double value)
        {
            return new Vector3(v.x * value, v.y * value, v.z * value);
        }

        public static Vector3 operator %(Vector3 v1, Vector3 v2)
        {
            return v1.vectorProduct(v2);
        }

        public static double operator *(Vector3 v1, Vector3 v2)
        {
            return v1.scalarProduct(v2);
        }

        public Vector3 componentProduct(Vector3 vector)
        {
            return new Vector3(x * vector.x, y * vector.y, z * vector.z);
        }

        public void componentProductUpdate(Vector3 vector)
        {
            x *= vector.x;
            y *= vector.y;
            z *= vector.z;
        }

        public Vector3 vectorProduct(Vector3 vector)
        {
            return new Vector3(y * vector.z - z * vector.y,
                z * vector.x - x * vector.z, x * vector.y - y * vector.z);
        }

        public double scalarProduct(Vector3 vector)
        {
            return x * vector.x + y * vector.y + z * vector.z;
        }

        public void addScaledVector(Vector3 vector, double scale)
        {
            x += vector.x * scale;
            y += vector.y * scale;
            z += vector.z * scale;
        }

        public double magnitude()
        {
            return Math.Sqrt(x * x + y * y + z * z);
        }

        public double squareMagnitude()
        {
            return x * x + y * y + z * z;
        }

        public void trim(double size)
        {
            if (squareMagnitude() > size * size)
            {
                normalize();
                x *= size;
                y *= size;
                z *= size;
            }
        }

        public void normalize()
        {
            double i = magnitude();
            if (i > 0)
            {
                x *= (double)(1 / i);
                y *= (double)(1 / i);
                z *= (double)(1 / i);
            }
        }

        public Vector3 unit()
        {
            Vector3 result = new Vector3(x, y, z);
            result.normalize();
            return result;
        }

        public static bool operator ==(Vector3 v1, Vector3 v2)
        {
            return (v1.x == v2.x && v1.y == v2.y && v1.z == v2.z);
        }

        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            return !(v1 == v2);
        }

        public static bool operator <(Vector3 v1, Vector3 v2)
        {
            return (v1.x < v2.x && v1.y < v2.y && v1.z < v2.z);
        }

        public static bool operator >(Vector3 v1, Vector3 v2)
        {
            return (v1.x > v2.x && v1.y > v2.y && v1.z > v2.z);
        }

        public static bool operator <=(Vector3 v1, Vector3 v2)
        {
            return (v1.x <= v2.x && v1.y <= v2.y && v1.z <= v2.z);
        }

        public static bool operator >=(Vector3 v1, Vector3 v2)
        {
            return (v1.x >= v2.x && v1.y >= v2.y && v1.z >= v2.z);
        }

        public void clear()
        {
            x = y = z = 0;
        }

        public void invert()
        {
            x = -x; y = -y; z = -z;
        }
    }

    class Quaternion
    {
        public double r;
        public double i;
        public double j;
        public double k;

        public Quaternion()
        {
            r = 1.0;
            i = 0.0;
            j = 0.0;
            k = 0.0;
        }

        public Quaternion(double r, double i, double j, double k)
        {
            this.r = r;
            this.i = i;
            this.j = j;
            this.k = k;
        }

        void normalize()
        {
            double d = r * r + i * i + j * j + k * k;

            if (d == 0)
            {
                r = 1;
                return;
            }

            d = ((double)1.0) / Math.Sqrt(d);
            r *= d;
            i *= d;
            j *= d;
            k *= d;
        }

       public static Quaternion operator*(Quaternion q1, Quaternion q2)
        {
            Quaternion result = new Quaternion();
            result.r = q1.r * q2.r - q1.i * q2.i - q1.j * q2.j - q1.k * q2.k;
            result.i = q1.r * q2.i + q1.i * q2.r + q1.j * q2.k - q1.k * q2.j;
            result.j = q1.r * q2.j + q1.j * q2.r + q1.k * q2.i - q1.i * q2.k;
            result.k = q1.r * q2.k + q1.k * q2.r + q1.i * q2.j - q1.j * q2.i;
           
            return result;
        }

        public void addScaledVector(Vector3 vector, double scale)
       {
           Quaternion q = new Quaternion(0, vector.x * scale, vector.y * scale, vector.z * scale);
           q *= this;
           this.r += q.r * 0.5f;
           this.i += q.i * 0.5f;
           this.j += q.j * 0.5f;
           this.k += q.k * 0.5f;
       }

        public void rotateByVector(Vector3 vector)
        {
            Quaternion q = new Quaternion(0, vector.x, vector.y, vector.z);
            Quaternion result = this * q;
            this.r = result.r;
            this.i = result.i;
            this.j = result.j;
            this.k = result.k;
        }
    }

    class Matrix4
    {
        public double[] data;

        Matrix4()
        {
            data = new double[12];
            data[1] = data[2] = data[3] = data[4] = data[6] = data[7] = data[8] = data[9] = data[11] = 0;
            data[0] = data[5] = data[10] = 1;
        }

        void setDiagonal(double a, double b, double c)
        {
            data[0] = a;
            data[5] = b;
            data[10] = c;
        }

        public static Matrix4 operator*(Matrix4 m1, Matrix4 m2)
        {
            Matrix4 result = new Matrix4();
            // rewrite it in my favourite order                       
            result.data[0] = (m2.data[0] * m1.data[0] + m2.data[4] * m1.data[1] + m2.data[8] * m1.data[2]);
            result.data[1] = (m2.data[1] * m1.data[0] + m2.data[5] * m1.data[1] + m2.data[9] * m1.data[2]);
            result.data[2] = (m2.data[2] * m1.data[0] + m2.data[6] * m1.data[1] + m2.data[10] * m1.data[2]);
            result.data[3] = (m2.data[3] * m1.data[0] + m2.data[7] * m1.data[1] + m2.data[11] * m1.data[2]) + m1.data[3];

            result.data[4] = (m2.data[0] * m1.data[4] + m2.data[4] * m1.data[5] + m2.data[8] * m1.data[6]);
            result.data[5] = (m2.data[1] * m1.data[4] + m2.data[5] * m1.data[5] + m2.data[9] * m1.data[6]);
            result.data[6] = (m2.data[2] * m1.data[4] + m2.data[6] * m1.data[5] + m2.data[10] * m1.data[6]);
            result.data[7] = (m2.data[3] * m1.data[4] + m2.data[7] * m1.data[5] * m2.data[11] * m1.data[6]) + m1.data[7];

            result.data[8] = (m2.data[0] * m1.data[8] + m2.data[4] * m1.data[9] + m2.data[8] * m1.data[10]);
            result.data[9] = (m2.data[1] * m1.data[8] + m2.data[5] * m1.data[9] + m2.data[9] * m1.data[10]);
            result.data[10] = (m2.data[2] * m1.data[8] + m2.data[6] * m1.data[9] + m2.data[10] * m1.data[10]);
            result.data[11] = (m2.data[3] * m1.data[9] + m2.data[7] * m1.data[9] + m2.data[11] * m1.data[10]) + m1.data[11];


            return result;
        }

    }

}
