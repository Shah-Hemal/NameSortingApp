using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NameSorter;

namespace NameSorter.Tests
{
    [TestFixture]
    public class PersonNameTests
    {
        [Test]
        public void PersonName_NullOrWhitespaceFullName_ThrowsArgumentNullException()
        {
            // By putting Pragma ignoring the overcautious compiler check-warning on passing null 
            #nullable disable
            Assert.Throws<ArgumentNullException>(() => new PersonName(null));
            #nullable restore
            Assert.Throws<ArgumentNullException>(() => new PersonName(" "));
        }

        [Test]
        public void PersonName_ValidFullName_SetsPropertiesCorrectly()
        {
            var name = new PersonName("Hemal Shah");
            Assert.That(name.GivenNames, Is.EqualTo(new List<string> { "Hemal" }));
            Assert.That(name.LastName, Is.EqualTo("Shah"));

            name = new PersonName("Hemal Girishkumar Shah");
            Assert.That(name.GivenNames, Is.EqualTo(new List<string> { "Hemal", "Girishkumar" }));
            Assert.That(name.LastName, Is.EqualTo("Shah"));
        }

        [Test]
        public void PersonName_UpTo_Three_GivenNames_Accepted()
        {
            Assert.DoesNotThrow(() => new PersonName("Given1 Given2 Given3 LastName"));

            Assert.Throws<ArgumentException>(() => new PersonName("Given1 Given2 Given3 Given4 LastName"));
            Assert.Throws<ArgumentException>(() => new PersonName(" Given1 Given2 Given3 Given4 LastName")); // Leading space
            Assert.Throws<ArgumentException>(() => new PersonName("Given1 Given2 Given3 Given4  LastName")); // Multiple spaces
            Assert.Throws<ArgumentException>(() => new PersonName("Given1 Given2 Given3 Given4 LastName ")); // Trailing space
        }

        [Test]
        public void PersonName_FullNameWithLeadingOrTrailingSpaces_HandlesCorrectly()
        {
            var name = new PersonName("  Hemal Shah ");
            Assert.That(name.GivenNames, Is.EqualTo(new List<string> { "Hemal" }));
            Assert.That(name.LastName, Is.EqualTo("Shah"));
        }

        [Test]
        public void PersonName_SingleName_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => new PersonName("Hemal"));
        }

        [Test]
        public void PersonName_CompareTo_SortsByLastNameThenGivenNames()
        {
            var name1 = new PersonName("Janet Parsons");
            var name2 = new PersonName("Vaughn Lewis");
            var name3 = new PersonName("Marin Alvarez");
            var name4 = new PersonName("Marin Beatty");
            var name5 = new PersonName("Marin Alvarez Bravo");

            Assert.Less(name3.CompareTo(name1), 0); // Alvarez < Parsons
            Assert.Greater(name2.CompareTo(name3), 0); // Lewis > Alvarez
            Assert.Less(name3.CompareTo(name4), 0); // Alvarez < Beatty
            Assert.Less(name3.CompareTo(name5), 0); // Alvarez < Alvarez Bravo
            Assert.Greater(name5.CompareTo(name3), 0); // Alvarez Bravo > Alvarez
        }
    }
}