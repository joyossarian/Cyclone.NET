using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cyclone.NET
{
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
    }
}
