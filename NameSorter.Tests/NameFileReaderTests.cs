using NameSorter.IO;

namespace NameSorter.Tests;

public class NameFileReaderTests
{
    [Fact]
    public void ReadLines_ReturnsLinesFromFile()
    {
        var filePath = Path.GetTempFileName();

        try
        {
            File.WriteAllLines(
                filePath,
                [
                    "Marin Alvarez",
                    "Leo Gardner"
                ]);

            var reader = new NameFileReader();

            var result = reader.ReadLines(filePath);

            Assert.Equal(
                ["Marin Alvarez", "Leo Gardner"],
                result);
        }
        finally
        {
            File.Delete(filePath);
        }
    }

    [Fact]
    public void ReadLines_NullOrEmptyPath_ThrowsArgumentException()
    {
        var reader = new NameFileReader();

        Assert.Throws<ArgumentException>(
            () => reader.ReadLines(""));
    }
}