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

        static readonly Vector3 GRAVITY = new Vector3(0, -9.81f, 0);
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

    }
}
