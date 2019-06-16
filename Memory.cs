using System;

namespace NARDIAC
{
    public class Memory
    {
        readonly Word[] storage = new Word[100];

        public Memory()
        {
            storage[0] = new Word(0, 0, 1);
            storage[99] = new Word(8, 0, 0);
        }

        public Word this[int index]
        {
            get
            {
                if (index < 0 || index > 99) throw new ArgumentOutOfRangeException(nameof(index));

                return storage[index];
            }
            set
            {
                if (index < 0 || index > 99) throw new ArgumentOutOfRangeException(nameof(index));
                if (index == 0) throw new ArgumentOutOfRangeException(nameof(index));
                if (index == 99 && value.Item1 != 8) throw new ArgumentException("The first digit in cell 99 must be an 8", nameof(value));

                storage[index] = value;
            }
        }
    }
}
