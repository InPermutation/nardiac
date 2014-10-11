using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NARDIAC
{
    public abstract class Output
    {
        public abstract void Write(Cell tuple);
    }

    class ConsoleOutput : Output
    {
        public override void Write(Cell tuple)
        {
            Console.Write((uint)tuple.Item1);
            Console.Write((uint)tuple.Item2);
            Console.WriteLine((uint)tuple.Item3);
        }   
    }
}
