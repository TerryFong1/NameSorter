using NameSorter.Services;

namespace NameSorter.Tests
{
    public class NameParserTests
    {
        private readonly NameParser _parser = new();

        [Fact]
        public void Parse_TwoPartName_ReturnsGivenNameAndLastName()
        {
            var result = _parser.Parse("Marin Alvarez");

            Assert.Equal("Alvarez", result.LastName);
            Assert.Single(result.GivenNames);
            Assert.Equal("Marin", result.GivenNames[0]);
        }

        [Fact]
        public void Parse_ThreePartName_ReturnsTwoGivenNamesAndLastName()
        {
            var result = _parser.Parse("Adonis Julius Archer");

            Assert.Equal("Archer", result.LastName);
            Assert.Equal(
                ["Adonis", "Julius"],
                result.GivenNames);
        }

        [Fact]
        public void Parse_FourPartName_ReturnsThreeGivenNamesAndLastName()
        {
            var result = _parser.Parse(
                "Hunter Uriah Mathew Clarke");

            Assert.Equal("Clarke", result.LastName);
            Assert.Equal(
                ["Hunter", "Uriah", "Mathew"],
                result.GivenNames);
        }

        [Fact]
        public void Parse_ExtraWhitespace_IgnoresWhitespace()
        {
            var result = _parser.Parse(
                "  Hunter   Uriah  Mathew   Clarke  ");

            Assert.Equal("Clarke", result.LastName);
            Assert.Equal(
                ["Hunter", "Uriah", "Mathew"],
                result.GivenNames);
        }

        [Theory]
        [InlineData("")]
        [InlineData("   ")]
        public void Parse_EmptyName_ThrowsArgumentException(
            string input)
        {
            Assert.Throws<ArgumentException>(
                () => _parser.Parse(input));
        }

        [Fact]
        public void Parse_NameWithOnlyLastName_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(
                () => _parser.Parse("Clarke"));
        }

        [Fact]
        public void Parse_NameWithMoreThanThreeGivenNames_ThrowsFormatException()
        {
            Assert.Throws<FormatException>(
                () => _parser.Parse(
                    "John Robert Michael David Clarke"));
        }
    }
}
