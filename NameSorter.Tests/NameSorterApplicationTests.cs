using NameSorter.IO;
using NameSorter.Services;

namespace NameSorter.Tests;

public class NameSorterApplicationTests
{
    [Fact]
    public void Run_ReadsSortsAndWritesNames()
    {
        var reader = new FakeNameFileReader(
        [
            "Janet Parsons",
            "Marin Alvarez",
            "Adonis Julius Archer"
        ]);

        var writer = new FakeNameFileWriter();

        var application = new NameSorterApplication(
            reader,
            writer,
            new NameParser(),
            new NameSortingService());

        var result = application.Run(
            "input.txt",
            "output.txt");

        Assert.Equal(0, result);

        Assert.Equal(
            [
                "Marin Alvarez",
                "Adonis Julius Archer",
                "Janet Parsons"
            ],
            writer.WrittenLines);
    }

    private sealed class FakeNameFileReader : INameFileReader
    {
        private readonly IEnumerable<string> _lines;

        public FakeNameFileReader(
            IEnumerable<string> lines)
        {
            _lines = lines;
        }

        public IEnumerable<string> ReadLines(
            string filePath)
        {
            return _lines;
        }
    }

    private sealed class FakeNameFileWriter : INameFileWriter
    {
        public IReadOnlyList<string> WrittenLines { get; private set; }
            = [];

        public void WriteLines(
            string filePath,
            IEnumerable<string> lines)
        {
            WrittenLines = lines.ToList();
        }
    }
}