using System;

namespace NARDIAC
{
    public class Memory
    {
        readonly Cell[] storage = new Cell[100];

        public Memory()
        {
            storage[0] = new Cell(0, 0, 1);
            storage[99] = new Cell(8, 0, 0);
        }

        public Cell this[int index]
        {
            get
            {
                if (index < 0 || index > 99) throw new ArgumentOutOfRangeException("index");

                return storage[index];
            }
            set
            {
                if (index < 0 || index > 99) throw new ArgumentOutOfRangeException("index");
                if (index == 0) throw new ArgumentOutOfRangeException("index");
                if (index == 99 && value.Item1 != 8) throw new ArgumentException("The first digit in cell 99 must be an 8", "value");
                if (value.Item1 >= 10) throw new ArgumentException("The first digit in a cell must be 0..9", "value");
                if (value.Item2 >= 10) throw new ArgumentException("The second digit in a cell must be 0..9", "value");
                if (value.Item3 >= 10) throw new ArgumentException("The third digit in a cell must be 0..9", "value");

                storage[index] = value;
            }
        }
    }
}
