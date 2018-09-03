using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Deserialization.Classes
{
    public class SystemCommand
    {
        public string _cmd = "calc.exe";

        public SystemCommand()
        {
            if (_cmd != "calc.exe")
                Console.WriteLine("Invalid command");
        }

        public void Run()
        {
            Process.Start(_cmd);
        }
    }
}

