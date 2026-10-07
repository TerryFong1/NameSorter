using NameSorter.Models;

namespace NameSorter.Services
{
    public sealed class NameParser
    {
        public PersonName Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Name cannot be empty.", nameof(input));
            }

            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2 || parts.Length > 4)
            {
                throw new FormatException($"Name must contain between 2 and 4 parts: '{input}'.");
            }

            var lastName = parts[^1];
            var givenNames = parts[..^1];

            return new PersonName(givenNames, lastName);
        }
    }
}
