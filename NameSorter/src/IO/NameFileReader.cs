using System.IO;

namespace NameSorter.IO;

public sealed class NameFileReader : INameFileReader
{
    public IEnumerable<string> ReadLines(string filePath)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);

        return File.ReadLines(filePath);
    }
}
