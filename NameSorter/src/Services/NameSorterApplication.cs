using NameSorter.IO;

namespace NameSorter.Services;

public sealed class NameSorterApplication
{
    private readonly INameFileReader _fileReader;
    private readonly INameFileWriter _fileWriter;
    private readonly NameParser _parser;
    private readonly NameSortingService _sorter;

    public NameSorterApplication(
        INameFileReader fileReader,
        INameFileWriter fileWriter,
        NameParser parser,
        NameSortingService sorter)
    {
        _fileReader = fileReader;
        _fileWriter = fileWriter;
        _parser = parser;
        _sorter = sorter;
    }

    public int Run(
        string inputFilePath,
        string outputFilePath)
    {
        var names = _fileReader
            .ReadLines(inputFilePath)
            .Select(_parser.Parse)
            .ToList();

        var sortedNames = _sorter.Sort(names);

        foreach (var name in sortedNames)
        {
            Console.WriteLine(name.FullName);
        }

        _fileWriter.WriteLines(
            outputFilePath,
            sortedNames.Select(name => name.FullName));

        return 0;
    }
}