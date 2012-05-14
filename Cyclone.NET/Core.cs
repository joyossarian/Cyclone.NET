using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }
    }
}
