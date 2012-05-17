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
            Vector3 t1 = new Vector3(1.0f, 1.0f, 0.0f);
            Vector3 t2 = new Vector3(2.0f, 0.0f, 2.0f);
            Vector3 t3 = t1 + t2;
            
            Console.WriteLine("x {0}, y {1}, z{1}", t3.x, t3.y, t3.z);
            Console.WriteLine("x {0}, y {1}, z{1}", t1.x, t1.y, t1.z);
            t3 -= t1;
            Console.WriteLine("x {0}, y {1}, z{1}", t3.x, t3.y, t3.z);
            Vector3 t4 = t1.componentProduct(t3);
            Console.WriteLine("x {0}, y {1}, z{1}", t4.x, t4.y, t4.z);
            Vector3 t5 = t1 % t2;
            Console.WriteLine("x {0}, y {1}, z{1}", t5.x, t5.y, t5.z);
            Vector3 t6 = new Vector3(2.0f, 2.0f, 2.0f);
            Vector3 t7 = t6.unit();
            Console.WriteLine("x {0}, y {1}, z{1}", t7.x, t7.y, t7.z);
        }
    }
}
