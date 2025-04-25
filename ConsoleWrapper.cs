using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    // Implement the wrapper.
    public class ConsoleWrapper : IConsoleWrapper
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}
