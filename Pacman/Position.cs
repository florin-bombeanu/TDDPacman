using System;

namespace Pacman
{
    public struct Position : IEquatable<Position>
    {
        public readonly int Row;
        public readonly int Column;

        public Position(int column, int row)
        {
            Row = row;
            Column = column;
        }

        public bool Equals(Position other)
        {
            return Row == other.Row && Column == other.Column;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Row * 397) ^ Column;
            }
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Position && Equals((Position)obj);
        }
    }
}