using System;

namespace NARDIAC
{
    public struct Word
    {
        public readonly byte Item1;
        public readonly byte Item2;
        public readonly byte Item3;
        public readonly bool Negative;

        public Word(byte a, byte b, byte c, bool negative = false)
        {
            if (a > 9) throw new ArgumentException("Out of bounds", nameof(a));
            if (b > 9) throw new ArgumentException("Out of bounds", nameof(b));
            if (c > 9) throw new ArgumentException("Out of bounds", nameof(c));

            Item1 = a; Item2 = b; Item3 = c; Negative = negative;
        }
    }


}
