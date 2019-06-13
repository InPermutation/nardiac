using System;
using System.Diagnostics;
using System.IO;

namespace NARDIAC
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Main_Impl(args);
            }
            catch (Exception e) when (!Debugger.IsAttached)
            {
                Console.Error.WriteLine(e.GetType().Name);
                Console.Error.WriteLine("-------");
                Console.Error.WriteLine(e.Message);
                Console.Error.WriteLine(e.StackTrace);
                Environment.Exit(1);
            }
        }

        static void Main_Impl(string[] args)
        {
            Computer c;
            if (args.Length == 0)
            {
                c = new Computer(new ConsoleInput(), new ConsoleOutput());
            }
            else if (args.Length == 1)
            {
                c = new Computer(new FileInput(File.OpenText(args[0])), new ConsoleOutput());
            }
            else
            {
                Usage();
                Environment.Exit(1);
                return;
            }

            c.Run();
        }

        private static void Usage()
        {
            Console.Error.WriteLine("NARDIAC [inputFile]");
        }
    }
}
