using System;
using System.Collections.Generic;

namespace NameSorter
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "unsorted-names-list.txt";
            string outputFilePath = "sorted-names-list.txt";
            var nameSorter = new NameSortingService();

            try
            {
                List<string> sortedNames = nameSorter.SortNamesFromFile(inputFilePath);

                Console.WriteLine("Sorted Names:");
                nameSorter.PrintNamesToConsole(sortedNames);

                nameSorter.WriteSortedNamesToFile(sortedNames, outputFilePath);
                Console.WriteLine($"Sorted names written to: {outputFilePath}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}