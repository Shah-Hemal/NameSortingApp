using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    /// <summary>
    /// Provides the functionality to sort a list of names from a file.
    /// </summary>
    public class NameSortingService
    {
        // Public Setter.
        public IConsoleWrapper ConsoleWrapper { get; set; }

        // Default implementation.
        public NameSortingService()
        {
            ConsoleWrapper = new ConsoleWrapper();
        }

        /// <summary>
        /// Reads names from a file, sorts them, and returns the sorted list.
        /// </summary>
        /// <param name="filePath">The path to the file containing the unsorted names.</param>
        /// <returns>A list of sorted full names.</returns>
        /// <exception cref="FileNotFoundException">Thrown if the file path is invalid or the file does not exist.</exception>

        public List<string> SortNamesFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file does not exist.", filePath);
            }

            var names = File.ReadAllLines(filePath)
                            .Select(name => new PersonName(name))
                            .OrderBy(person => person)
                            .Select(person => person.ToString())
                            .ToList();

            return names;
        }

        /// <summary>
        /// Prints the list of names to the console.
        /// </summary>
        /// <param name="names">The list of names to print.</param>
        public void PrintNamesToConsole(List<string> names)
        {
            foreach (var name in names)
            {
                ConsoleWrapper.WriteLine(name);
            }
        }

        /// <summary>
        /// Writes the list of names to a file named "sorted-names-list.txt" in the working directory, overwriting if it exists.
        /// </summary>
        /// <param name="sortedNames">The list of sorted names to write to the file.</param>
        public void WriteSortedNamesToFile(List<string> sortedNames, string outputFilePath)
        {
            File.WriteAllLines(outputFilePath, sortedNames);
        }
    }
}