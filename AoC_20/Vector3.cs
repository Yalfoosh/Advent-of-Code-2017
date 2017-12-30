using System;

namespace AoC_20
{
    public class Vector3
    {
        public long X { get; set; }
        public long Y { get; set; }
        public long Z { get; set; }

        public Vector3(long x = 0, long y = 0, long z = 0)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(Vector3 old)
        {
            X = old.X;
            Y = old.Y;
            Z = old.Z;
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector3 vector3)
                return Equals(vector3);

            return false;
        }
        private bool Equals(Vector3 other) => X == other.X 
                                              && Y == other.Y 
                                              && Z == other.Z;

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static bool operator ==(Vector3 left, Vector3 right) => left != null && left.Equals(right);
        public static bool operator !=(Vector3 left, Vector3 right) => left != null && !left.Equals(right);

        public ulong DistanceFromCenter() => (ulong)Math.Abs(X) + (ulong)Math.Abs(Y) + (ulong)Math.Abs(Z);
        public ulong DistanceFromCenter(Vector3 other) => (ulong)Math.Abs(other.X) + (ulong)Math.Abs(other.Y) + (ulong)Math.Abs(other.Z);
        public ulong DistanceFrom(Vector3 other) => DistanceFromCenter(other - this);

        public double Weight() => Math.Pow(X * X + Y * Y + Z * Z, 0.5);
    }
}