using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NARDIAC
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Debugger.IsAttached)
            {
                Main_Impl(args);
            }
            else
            {
                try
                {
                    Main_Impl(args);
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e.GetType().Name);
                    Console.Error.WriteLine("-------");
                    Console.Error.WriteLine(e.Message);
                    Console.Error.WriteLine(e.StackTrace);
                    Environment.Exit(1);
                }
            }
        }

        static void Main_Impl(string[] args)
        {
            Computer c = null;
            if (args.Length == 0)
            {
                c = new Computer(new ConsoleInput(), new ConsoleOutput());
            }
            else if (args.Length == 1)
            {
                c = new Computer(new FileInput(File.OpenText(args[0])), new ConsoleOutput());
            }

            if (c == null)
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
