namespace NameSorter.IO;

public interface INameFileWriter
{
    void WriteLines(
        string filePath,
        IEnumerable<string> lines);
}
