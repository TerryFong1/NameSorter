using NameSorter.IO;

namespace NameSorter.Tests;

public class NameFileWriterTests
{
    [Fact]
    public void WriteLines_CreatesFileWithProvidedLines()
    {
        var filePath = Path.GetTempFileName();

        try
        {
            var writer = new NameFileWriter();

            writer.WriteLines(
                filePath,
                [
                    "Marin Alvarez",
                    "Leo Gardner"
                ]);

            var result = File.ReadAllLines(filePath);

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
    public void WriteLines_OverwritesExistingFile()
    {
        var filePath = Path.GetTempFileName();

        try
        {
            File.WriteAllLines(
                filePath,
                [
                    "Old Name",
                    "Another Old Name"
                ]);

            var writer = new NameFileWriter();

            writer.WriteLines(
                filePath,
                [
                    "Marin Alvarez"
                ]);

            var result = File.ReadAllLines(filePath);

            Assert.Equal(
                ["Marin Alvarez"],
                result);
        }
        finally
        {
            File.Delete(filePath);
        }
    }

    [Fact]
    public void WriteLines_NullLines_ThrowsArgumentNullException()
    {
        var writer = new NameFileWriter();

        Assert.Throws<ArgumentNullException>(
            () => writer.WriteLines(
                "test.txt",
                null!));
    }
}