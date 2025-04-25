using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NameSorter;
using Moq;

namespace NameSorter.Tests
{
    [TestFixture]
    public class NameSorterTests
    {

        [Test]
        public void SortNamesFromFile_FileNotFound_ThrowsFileNotFoundException()
        {
            var sorter = new NameSortingService();
            Assert.Throws<FileNotFoundException>(() => sorter.SortNamesFromFile("non-existent-file.txt"));
        }

        [Test]
        public void SortNamesFromFile_ValidFile_ReturnsSortedNames()
        {
            var unsortedNames = new[] { "John Smith", "Jane Smith", "Peter Smith" };
            File.WriteAllLines("test-unsorted-names.txt", unsortedNames);
            var sorter = new NameSortingService();

            var sortedNames = sorter.SortNamesFromFile("test-unsorted-names.txt");
            File.Delete("test-unsorted-names.txt");

            Assert.That(sortedNames, Is.EqualTo(new List<string> { "Jane Smith", "John Smith", "Peter Smith" }));
        }

        [Test]
        public void SortNamesFromFile_InvalidNameFormat_ThrowsArgumentException()
        {
            var invalidNames = new[] { "SingleName" };
            File.WriteAllLines("test-invalid-names.txt", invalidNames);
            var sorter = new NameSortingService();
            Assert.Throws<ArgumentException>(() => sorter.SortNamesFromFile("test-invalid-names.txt"));
            File.Delete("test-invalid-names.txt");
        }

        [Test]
        public void PrintNamesToConsole_ValidList_PrintsEveryName()
        {
            var namesToPrint = new List<string> { "Demo Name1", "Demo Name2" };
            var mockConsole = new Mock<IConsoleWrapper>();
            var sorter = new NameSortingService();
            sorter.ConsoleWrapper = mockConsole.Object; // Directly setting property

            sorter.PrintNamesToConsole(namesToPrint);

            mockConsole.Verify(c => c.WriteLine("Demo Name1"), Times.Once);
            mockConsole.Verify(c => c.WriteLine("Demo Name2"), Times.Once);
        }

        [Test]
        public void WriteSortedNamesListToFile_ValidList_WritesToFile()
        {
            var sortedNames = new List<string> { "Justin Trudeau", "Donald Trump" };
            var sorter = new NameSortingService();
            string outputFilePath = "sorted-names-list.txt"; // Provide the output file path

            sorter.WriteSortedNamesToFile(sortedNames, outputFilePath); // Pass the outputFilePath
          
            Assert.IsTrue(File.Exists(outputFilePath));
            var fileContent = File.ReadAllLines(outputFilePath);
            Assert.That(fileContent, Is.EqualTo(sortedNames));

            File.Delete(outputFilePath);
        }
    }
}