using System.IO;

namespace NameSorter.IO;

public sealed class NameFileWriter : INameFileWriter
{
    public void WriteLines(
        string filePath,
        IEnumerable<string> lines)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(filePath);
        ArgumentNullException.ThrowIfNull(lines);

        File.WriteAllLines(filePath, lines);
    }
}
