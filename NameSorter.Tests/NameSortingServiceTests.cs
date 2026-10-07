using NameSorter.Models;
using NameSorter.Services;

namespace NameSorter.Tests;

public class NameSortingServiceTests
{
    private readonly NameSortingService _sorter = new();

    [Fact]
    public void Sort_SortsNamesByLastName()
    {
        var names = new[]
        {
            new PersonName(["John"], "Smith"),
            new PersonName(["Adam"], "Archer"),
            new PersonName(["Marin"], "Alvarez")
        };

        var result = _sorter.Sort(names);

        Assert.Equal(
            ["Alvarez", "Archer", "Smith"],
            result.Select(name => name.LastName));
    }

    [Fact]
    public void Sort_WhenLastNamesMatch_SortsByFirstGivenName()
    {
        var names = new[]
        {
            new PersonName(["John"], "Smith"),
            new PersonName(["Adam"], "Smith"),
            new PersonName(["Brian"], "Smith")
        };

        var result = _sorter.Sort(names);

        Assert.Equal(
            ["Adam", "Brian", "John"],
            result.Select(name => name.GivenNames[0]));
    }

    [Fact]
    public void Sort_WhenFirstGivenNamesMatch_SortsBySecondGivenName()
    {
        var names = new[]
        {
            new PersonName(["John", "Michael"], "Smith"),
            new PersonName(["John"], "Smith"),
            new PersonName(["John", "Andrew"], "Smith")
        };

        var result = _sorter.Sort(names);

        Assert.Equal(
            [
                "John Smith",
                "John Andrew Smith",
                "John Michael Smith"
            ],
            result.Select(name => name.FullName));
    }

    [Fact]
    public void Sort_WhenFirstAndSecondGivenNamesMatch_SortsByThirdGivenName()
    {
        var names = new[]
        {
            new PersonName(
                ["John", "Andrew", "Michael"],
                "Smith"),

            new PersonName(
                ["John", "Andrew", "Adam"],
                "Smith"),

            new PersonName(
                ["John", "Andrew", "Robert"],
                "Smith")
        };

        var result = _sorter.Sort(names);

        Assert.Equal(
            [
                "John Andrew Adam Smith",
                "John Andrew Michael Smith",
                "John Andrew Robert Smith"
            ],
            result.Select(name => name.FullName));
    }

    [Fact]
    public void Sort_IsCaseInsensitive()
    {
        var names = new[]
        {
            new PersonName(["john"], "smith"),
            new PersonName(["Adam"], "Smith"),
            new PersonName(["Brian"], "SMITH")
        };

        var result = _sorter.Sort(names);

        Assert.Equal(
            [
                "Adam Smith",
                "Brian SMITH",
                "john smith"
            ],
            result.Select(name => name.FullName));
    }

    [Fact]
    public void Sort_NullInput_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(
            () => _sorter.Sort(null!));
    }
}