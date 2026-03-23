using System;

namespace Grid
{
    public struct GridPosition : IEquatable<GridPosition>
    {
        public int X;
        public int Z;

        public GridPosition(int x, int z)
        {
            this.X = x;
            this.Z = z;
        }

        public override bool Equals(object obj)
        {
            return obj is GridPosition position &&
                   X == position.X &&
                   Z == position.Z;
        }

        public bool Equals(GridPosition other) => this == other;
        
        public override int GetHashCode() => HashCode.Combine(X, Z);
        
        public override string ToString() => $"x: {X}\n z: {Z}";
        
        public static bool operator ==(GridPosition a, GridPosition b) => a.X == b.X && a.Z == b.Z;
        
        public static bool operator !=(GridPosition a, GridPosition b) => !(a == b);
        
        public static GridPosition operator +(GridPosition a, GridPosition b) => new GridPosition(a.X + b.X, a.Z + b.Z);
        
        public static GridPosition operator -(GridPosition a, GridPosition b) => new GridPosition(a.X - b.X, a.Z - b.Z);
    }
}