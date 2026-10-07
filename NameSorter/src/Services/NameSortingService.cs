using NameSorter.Models;

namespace NameSorter.Services;

public sealed class NameSortingService
{
    private static readonly StringComparer Comparer =
        StringComparer.OrdinalIgnoreCase;

    public IReadOnlyList<PersonName> Sort(IEnumerable<PersonName> names)
    {
        ArgumentNullException.ThrowIfNull(names);

        return names
            .OrderBy(name => name.LastName, Comparer)
            .ThenBy(name => name.GivenNames[0], Comparer)
            .ThenBy(name => name.GivenNames.Count > 1
                ? name.GivenNames[1]
                : string.Empty, Comparer)
            .ThenBy(name => name.GivenNames.Count > 2
                ? name.GivenNames[2]
                : string.Empty, Comparer)
            .ToList();
    }
}
