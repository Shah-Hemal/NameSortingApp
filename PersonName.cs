using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter
{
    /// <summary>
    /// Represents a person's full name, with separate properties for given names and last name.
    /// </summary>
    public class PersonName : IComparable<PersonName>
    {
        public List<string> GivenNames { get; private set; }
        public string LastName { get; private set; }
        public string FullName => $"{string.Join(" ", GivenNames)} {LastName}".Trim();

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonName"/> class.
        /// </summary>
        /// <param name="fullName">The full name string (e.g., "Janet Parsons").</param>
        /// <exception cref="ArgumentNullException">Thrown if the full name is null or whitespace.</exception>
        /// <exception cref="ArgumentException">Thrown if the full name does not contain at least one given name or has more than 3 given names.</exception>
        public PersonName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
            {
                throw new ArgumentNullException(nameof(fullName), "Full name cannot be null or whitespace.");
            }

            var nameParts = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (nameParts.Length <= 1)
            {
                throw new ArgumentException("Full name must contain at least one given name.", nameof(fullName));
            }
            // To allow max at least 1 given name and up to 3 given names.
            else if (nameParts.Length - 1 > 3)
            {
                throw new ArgumentException("Full name cannot have more than 3 given names.", nameof(fullName));
            }

            LastName = nameParts.Last();
            GivenNames = nameParts.Take(nameParts.Length - 1).ToList();
        }

        /// <summary>
        /// Compares the current instance with another <see cref="PersonName"/> object for sorting.
        /// Names are sorted first by last name, then by the order of given names.
        /// </summary>
        /// <param name="other">The <see cref="PersonName"/> object to compare with.</param>
        /// <returns>A value indicating the relative order of the names.</returns>
        public int CompareTo(PersonName? other)
        {
            if (other is null)
            {
                return 1;
            }

            int lastNameComparison = LastName.CompareTo(other.LastName);
            if (lastNameComparison != 0)
            {
                return lastNameComparison;
            }


            // Compare given names.
            int minLength = Math.Min(GivenNames.Count, other.GivenNames.Count);
            for (int i = 0; i < minLength; i++)
            {
                int givenNameComparison = GivenNames[i].CompareTo(other.GivenNames[i]);
                if (givenNameComparison != 0)
                {
                    return givenNameComparison;
                }
            }

            // If all common given names are equal, the shorter list comes first.
            return GivenNames.Count.CompareTo(other.GivenNames.Count);
        }

        /// <summary>
        /// Returns the full name as a single string.
        /// </summary>
        /// <returns>The full name.</returns>
        public override string ToString()
        {
            return FullName;
        }
    }
}