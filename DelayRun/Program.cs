using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace DelayRun
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.Error.WriteLine("Usage: DelayRun delay executable [arguments]");
                return;
            }
            var delay = int.Parse(args[0]);
            var executable = args[1];
            var arguments = string.Join(" ", args.Skip(2).Select(arg => arg.Contains(' ') ? "\"" + arg + "\"" : arg).ToArray());
            var psi = new ProcessStartInfo(executable, arguments);
            Thread.Sleep(delay * 1000);
            var process = Process.Start(psi);
        }
    }
}
