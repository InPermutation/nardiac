using System;

namespace NARDIAC
{
    public abstract class Output
    {
        public abstract void Write(Word tuple);
    }

    class ConsoleOutput : Output
    {
        public override void Write(Word tuple)
        {
            if (tuple.Negative) Console.Write('-');
            Console.Write((uint)tuple.Item1);
            Console.Write((uint)tuple.Item2);
            Console.WriteLine((uint)tuple.Item3);
        }
    }
}
