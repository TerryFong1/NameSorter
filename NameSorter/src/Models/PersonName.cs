namespace NameSorter.Models
{
    public sealed record PersonName(IReadOnlyList<string> GivenNames, string LastName)
    {
        public string FullName => string.Join(' ', GivenNames.Append(LastName));
    }
}
