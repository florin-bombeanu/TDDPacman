using System;
using System.Linq;

namespace Pacman.Test
{
    public struct VisualBoard : IEquatable<VisualBoard>
    {
        private readonly string[] _lines;

        public VisualBoard(params string[] lines)
        {
            _lines = lines;
        }

        public bool Equals(VisualBoard other)
        {
            return _lines.SequenceEqual(other._lines);
        }

        public override int GetHashCode()
        {
            return _lines.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is VisualBoard)
            {
                return Equals((VisualBoard)obj);
            }
            return false;
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _lines);
        }
    }
}