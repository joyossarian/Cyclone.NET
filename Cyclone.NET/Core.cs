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

        public static Vector3 operator *(Matrix4 m, Vector3 v)
        {
            // matrix left multiply vector
            Vector3 result = new Vector3(
                m.data[0] * v.x + m.data[1] * v.y + m.data[2] * v.z + m.data[3],
                m.data[4] * v.x + m.data[5] * v.y + m.data[6] * v.z + m.data[7],
                m.data[8] * v.x + m.data[9] * v.y + m.data[10] * v.z + m.data[11]
                );
            
            return result;
        }

        public Vector3 transform(Vector3 v)
        {
            return (this * v);
        }

        public double getDeterminant()
        {
            // Let A be a square matrix of order n. Write A = (aij), 
            // where aij is the entry on the row number i and the column number j, 
            // for   and  . For any i and j, set Aij (called the cofactors) to be 
            // the determinant of the square matrix of order (n-1) obtained from 
            // A by removing the row number i and the column number j multiplied by (-1)i+j. 
            // We have det(A) = sum (j = 1 -> j=n) aij * Aij
            return data[8] * data[5] * data[2] +
            data[4] * data[9] * data[2] +
            data[8] * data[1] * data[6] -
            data[0] * data[9] * data[6] -
            data[4] * data[1] * data[10] +
            data[0] * data[5] * data[10];
        }

        // Sets the matrix to be the inverse of the given matrix
        public void setInverse(Matrix4 m)
        {
            double det = getDeterminant();
            if (det == 0) return;
            det = 1.0f / det;

            data[0] = (-m.data[9] * m.data[6] + m.data[5] * m.data[10]) * det;
            data[4] = (m.data[8] * m.data[6] - m.data[4] * m.data[10]) * det;
            data[8] = (-m.data[8] * m.data[5] + m.data[4] * m.data[9]) * det;

            data[1] = (m.data[9] * m.data[2] - m.data[1] * m.data[10]) * det;
            data[5] = (-m.data[8] * m.data[2] + m.data[0] * m.data[10]) * det;
            data[9] = (m.data[8] * m.data[1] - m.data[0] * m.data[9]) * det;

            data[2] = (-m.data[5] * m.data[2] + m.data[1] * m.data[6]) * det;
            data[6] = (+m.data[4] * m.data[2] - m.data[0] * m.data[6]) * det;
            data[10] = (-m.data[4] * m.data[1] + m.data[0] * m.data[5]) * det;

            data[3] = (m.data[9] * m.data[6] * m.data[3]
                       - m.data[5] * m.data[10] * m.data[3]
                       - m.data[9] * m.data[2] * m.data[7]
                       + m.data[1] * m.data[10] * m.data[7]
                       + m.data[5] * m.data[2] * m.data[11]
                       - m.data[1] * m.data[6] * m.data[11]) * det;
            data[7] = (-m.data[8] * m.data[6] * m.data[3]
                       + m.data[4] * m.data[10] * m.data[3]
                       + m.data[8] * m.data[2] * m.data[7]
                       - m.data[0] * m.data[10] * m.data[7]
                       - m.data[4] * m.data[2] * m.data[11]
                       + m.data[0] * m.data[6] * m.data[11]) * det;
            data[11] = (m.data[8] * m.data[5] * m.data[3]
                       - m.data[4] * m.data[9] * m.data[3]
                       - m.data[8] * m.data[1] * m.data[7]
                       + m.data[0] * m.data[9] * m.data[7]
                       + m.data[4] * m.data[1] * m.data[11]
                       - m.data[0] * m.data[5] * m.data[11]) * det;
        }

        public Matrix4 inverse()
        {
            Matrix4 m = new Matrix4();
            m.setInverse(this);
            return m;
        }

        Vector3 transformDirection(Vector3 vector)
        {
            return new Vector3(
                vector.x * data[0] + vector.y * data[1] + vector.z * data[2],
                vector.x * data[4] + vector.y * data[5] + vector.z * data[6],
                vector.x * data[8] + vector.y * data[9] + vector.z * data[10]
                );
        }

        Vector3 transformInverseDirection( Vector3 vector)
        {
            return new Vector3(
                vector.x * data[0] +
                vector.y * data[4] +
                vector.z * data[8],

                vector.x * data[1] +
                vector.y * data[5] +
                vector.z * data[9],

                vector.x * data[2] +
                vector.y * data[6] +
                vector.z * data[10]
            );
        }

        Vector3 transformInverse(Vector3 vector)
        {
            Vector3 tmp = vector;
            tmp.x -= data[3];
            tmp.y -= data[7];
            tmp.z -= data[11];
            return new Vector3(
                tmp.x * data[0] +
                tmp.y * data[4] +
                tmp.z * data[8],

                tmp.x * data[1] +
                tmp.y * data[5] +
                tmp.z * data[9],

                tmp.x * data[2] +
                tmp.y * data[6] +
                tmp.z * data[10]
            );
        }

        Vector3 getAxisVector(int i)
        {
            return new Vector3(data[i], data[i+4], data[i+8]);
        }

        void setOrientationAndPos(Quaternion q, Vector3 pos)
        {
            data[0] = 1 - (2 * q.j * q.j + 2 * q.k * q.k);
            data[1] = 2 * q.i * q.j + 2 * q.k * q.r;
            data[2] = 2 * q.i * q.k - 2 * q.j * q.r;
            data[3] = pos.x;

            data[4] = 2 * q.i * q.j - 2 * q.k * q.r;
            data[5] = 1 - (2 * q.i * q.i + 2 * q.k * q.k);
            data[6] = 2 * q.j * q.k + 2 * q.i * q.r;
            data[7] = pos.y;

            data[8] = 2 * q.i * q.k + 2 * q.j * q.r;
            data[9] = 2 * q.j * q.k - 2 * q.i * q.r;
            data[10] = 1 - (2 * q.i * q.i + 2 * q.j * q.j);
            data[11] = pos.z;
        }

        // may be not necessary or replaced by fillDXArray
        void fillGLArray(float[] array)
        {
            array[0] = (float)data[0];
            array[1] = (float)data[4];
            array[2] = (float)data[8];
            array[3] = (float)0;

            array[4] = (float)data[1];
            array[5] = (float)data[5];
            array[6] = (float)data[9];
            array[7] = (float)0;

            array[8] = (float)data[2];
            array[9] = (float)data[6];
            array[10] = (float)data[10];
            array[11] = (float)0;

            array[12] = (float)data[3];
            array[13] = (float)data[7];
            array[14] = (float)data[11];
            array[15] = (float)1;
        }
    }

    class Matrix3
    {
        public double[] data;

        public Matrix3()
        {
            data[0] = data[1] = data[2] = data[3] = data[4] = data[5] =
                data[6] = data[7] = data[8] = 0;
        }

        public Matrix3(Vector3 compOne, Vector3 compTwo, Vector3 compThree)
        {
            setComponents(compOne, compTwo, compThree);
        }

        public Matrix3(double c0, double c1, double c2, double c3, double c4, double c5,
            double c6, double c7, double c8)
        {
            data[0] = c0; data[1] = c1; data[2] = c2;
            data[3] = c3; data[4] = c4; data[5] = c5;
            data[6] = c6; data[7] = c7; data[8] = c8;
        }

        public void setDiagonal(double a, double b, double c)
        {
            setInertiaTensorCoeffs(a, b, c);
        }

        public void setInertiaTensorCoeffs(double ix,double iy, double iz,
            double ixy = 0, double ixz = 0, double iyz = 0)
        {
            data[0] = ix;
            data[1] = data[3] = -ixy;
            data[2] = data[6] = -ixz;
            data[4] = iy;
            data[5] = data[7] = -iyz;
            data[8] = iz;
        }
        
        public void setBlockInertiaTensor(Vector3 halfSizes, double mass)
        {
            Vector3 squares = halfSizes.componentProduct(halfSizes);
            setInertiaTensorCoeffs(0.3f*mass*(squares.y + squares.z),
                0.3f*mass*(squares.x + squares.z),
                0.3f*mass*(squares.x + squares.y));
        }

        public void setSkewSymmetric(Vector3 vector)
        {
            data[0] = data[4] = data[8] = 0;
            data[1] = -vector.z;
            data[2] = vector.y;
            data[3] = vector.z;
            data[5] = -vector.x;
            data[6] = -vector.y;
            data[7] = vector.x;
        }

        public void setComponents(Vector3 compOne, Vector3 compTwo, Vector3 compThree)
        {
            data[0] = compOne.x;
            data[1] = compTwo.x;
            data[2] = compThree.x;
            data[3] = compOne.y;
            data[4] = compTwo.y;
            data[5] = compThree.y;
            data[6] = compOne.z;
            data[7] = compTwo.z;
            data[8] = compThree.z;
        }

        public static Vector3 operator *(Matrix3 m, Vector3 v)
        {
            Vector3 result = new Vector3();
            result.x = v.x * m.data[0] + v.y * m.data[1] + v.z * m.data[2];
            result.y = v.x * m.data[3] + v.y * m.data[4] + v.z * m.data[5];
            result.z = v.z * m.data[6] + v.y * m.data[7] + v.z * m.data[8];
            return result;
        }

    }

}
