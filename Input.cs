using System;
using System.IO;

namespace NARDIAC
{
    public abstract class Input
    {
        abstract public Cell Read();
    }

    class ConsoleInput : FileInput
    {
        public ConsoleInput() : base(Console.In) { }
    }

    class FileInput : Input
    {
        readonly TextReader reader;
        public FileInput(TextReader reader)
        {
            this.reader = reader;
        }

        override public Cell Read()
        {
            return new Cell(Digit(), Digit(), Digit());
        }

        private byte Digit()
        {
            while (true)
            {
                int ch = reader.Read();
                if(ch >= '0' && ch <= '9')
                {
                    return (byte)(ch - '0');
                }
                if (ch == ' ' || ch == '\r' || ch == '\t' || ch == '\n') continue;
                throw new InvalidDataException("Invalid character " + (char)ch);
            }
        }
    }
}
