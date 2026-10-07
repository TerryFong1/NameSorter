namespace NameSorter.IO;

public interface INameFileReader
{
    IEnumerable<string> ReadLines(string filePath);
}
