using System;

namespace NARDIAC
{
    public struct Cell
    {
        public readonly byte Item1;
        public readonly byte Item2;
        public readonly byte Item3;
        public bool Negative;

        public Cell(byte a, byte b, byte c) : this(a, b, c, false) { }
        public Cell(byte a, byte b, byte c, bool negative)
        {
            if (a > 9) throw new ArgumentException("Out of bounds", "a");
            if (b > 9) throw new ArgumentException("Out of bounds", "b");
            if (c > 9) throw new ArgumentException("Out of bounds", "c");

            Item1 = a; Item2 = b; Item3 = c; Negative = negative;
        }
    }


}
