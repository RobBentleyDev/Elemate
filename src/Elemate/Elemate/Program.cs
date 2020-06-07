using System;
using System.IO;
using System.Linq;

namespace Elemate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Elemate 1.0.0-Beta" + Environment.NewLine);

            if (!args.Any())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No directory supplied. Usage is: \"Elemate directory\"");
                return;
            }

            var rootDirectory = args[0];

            if (!Directory.Exists(rootDirectory))
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(
                    "Directory \""
                    + rootDirectory
                    + "\" does not exist. Check command arguments and try again.");
                return;
            }

            new Elemator().AddName(rootDirectory);
        }
    }
}
