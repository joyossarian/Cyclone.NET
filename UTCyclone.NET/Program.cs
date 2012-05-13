using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cyclone.NET;

namespace UTCyclone.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector3 t1 = new Vector3(1.0f, 1.0f, 1.0f);
            Vector3 t2 = new Vector3(2.0f, 2.0f, 2.0f);
            Vector3 t3 = t1 + t2;
            t1 += t3;
            Console.WriteLine("x {0}, y {1}, z{1}", t3.x, t3.y, t3.z);
            Console.WriteLine("x {0}, y {1}, z{1}", t1.x, t1.y, t1.z);
            t3 -= t1;
            Console.WriteLine("x {0}, y {1}, z{1}", t3.x, t3.y, t3.z);
        }
    }
}
