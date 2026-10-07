using NameSorter.IO;
using NameSorter.Services;

if (args.Length != 1)
{
    Console.Error.WriteLine(
        "Usage: name-sorter <input-file>");

    return 1;
}

var application = new NameSorterApplication(
    new NameFileReader(),
    new NameFileWriter(),
    new NameParser(),
    new NameSortingService());

try
{
    return application.Run(
        args[0],
        "sorted-names-list.txt");
}
catch (Exception ex)
{
    Console.Error.WriteLine(
        $"Error: {ex.Message}");

    return 1;
}