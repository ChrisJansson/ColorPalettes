﻿namespace ColorPalettes.Math
{
    public struct Vector3
    {
        public static Vector3 Zero = new Vector3(0, 0, 0);
        public static Vector3 UnitX = new Vector3(1, 0, 0);
        public static Vector3 UnitY = new Vector3(0, 1, 0);
        public static Vector3 UnitZ = new Vector3(0, 0, 1);

        public Vector3(double x, double y, double z)
            : this()
        {
            _x = x;
            _y = y;
            _z = z;
        }

        private readonly double _x;
        public double X
        {
            get { return _x; }
        }

        private readonly double _y;
        public double Y
        {
            get { return _y; }
        }

        private readonly double _z;
        public double Z
        {
            get { return _z; }
        }

        public Vector3 Pow(double exponent)
        {
            var x = System.Math.Pow(_x, exponent);
            var y = System.Math.Pow(_y, exponent);
            var z = System.Math.Pow(_z, exponent);

            return new Vector3(x, y, z);
        }

        public static Vector3 operator +(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X + right.X, left.Y + right.Y, left.Z + right.Z);
        }

        public static Vector3 operator -(Vector3 left, Vector3 right)
        {
            return new Vector3(left.X - right.X, left.Y - right.Y, left.Z - right.Z);
        }

        public static Vector3 operator *(Vector3 vector, double scalar)
        {
            return new Vector3(vector.X * scalar, vector.Y * scalar, vector.Z * scalar);
        }
    }
}