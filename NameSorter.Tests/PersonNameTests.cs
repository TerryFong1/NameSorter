using NameSorter.Models;

namespace NameSorter.Tests
{
    public class PersonNameTests
    {
        [Fact]
        public void FullName_ReturnsGivenNamesFollowedByLastName()
        {
            var person = new PersonName(
                ["Hunter", "Uriah", "Mathew"],
                "Clarke");

            Assert.Equal(
                "Hunter Uriah Mathew Clarke",
                person.FullName);
        }
    }
}
