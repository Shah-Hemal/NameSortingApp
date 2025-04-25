using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    // Creating an interface for Console to allow mocking.
    public interface IConsoleWrapper
    {
        void WriteLine(string message);
    }
}
