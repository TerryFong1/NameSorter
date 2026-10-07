# Dye & Durham Name Sorter

A C#/.NET 8 console application that sorts a list of names by last name, followed by each given name.

This project was created as part of the Dye & Durham Software Engineer coding assessment.

## Requirements

- .NET 8 SDK
- Visual Studio 2022, Visual Studio Code, or another .NET-compatible development environment

## Running the Application

The application accepts the path to an input text file as its only command-line argument.

From the repository root:

```bash
dotnet run --project NameSorter -- ./unsorted-names-list.txt
```

The application will:

1. Read the names from the input file.
2. Parse each name into its given names and last name.
3. Sort the names by last name, followed by each given name.
4. Print the sorted names to the console.
5. Create or overwrite `sorted-names-list.txt` in the working directory.

### Example

Input:

```text
Janet Parsons
Vaugh Lewis
Adonis Julius Archer
Shelby Nathan Yoder
Marin Alvarez
London Lindsey
Beau Tristan Bentley
Leo Gardner
Hunter Uriah Mathew Clarke
Mikayla Lopez
Frankie Conner Ritter
```

Output:

```text
Marin Alvarez
Adonis Julius Archer
Beau Tristan Bentley
Hunter Uriah Mathew Clarke
Leo Gardner
Vaugh Lewis
London Lindsey
Mikayla Lopez
Janet Parsons
Frankie Conner Ritter
Shelby Nathan Yoder
```

## Running the Tests

Run all unit tests from the repository root:

```bash
dotnet test
```

The test suite covers:

- Name parsing and validation
- Name representation
- Sorting by last name
- Sorting by multiple given names
- Case-insensitive sorting
- File reading and writing
- Output file overwriting
- Application-level orchestration

## Design

The application separates responsibilities into focused components:

- **`PersonName`** represents a parsed person's name.
- **`NameParser`** validates and converts raw input into `PersonName` objects.
- **`NameSortingService`** contains the name-sorting rules.
- **`NameFileReader`** and **`NameFileWriter`** isolate file-system operations.
- **`NameSorterApplication`** orchestrates the overall workflow.
- **`Program`** handles command-line arguments and application startup.

The design intentionally avoids unnecessary abstraction while keeping the major responsibilities independently testable.

## Name Format

The application expects each name to contain:

- 1 to 3 given names
- 1 last name

Therefore, each input line must contain between 2 and 4 name parts.

The final name part is treated as the last name, and all preceding parts are treated as given names.

Names are sorted case-insensitively while preserving the original spelling and capitalization in the output.
