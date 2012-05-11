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
    }
}
