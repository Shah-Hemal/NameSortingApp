# Name Sorter .NET Application

A simple .NET console application that reads a list of unsorted names from a text file, sorts them alphabetically by last name then first name, prints the sorted list to the console, and optionally writes the sorted list to another text file.

## Prerequisites

* **[.NET SDK](https://dotnet.microsoft.com/download):** Ensure you have the .NET SDK (Software Development Kit) installed on your system to build and run the application.

## Input

The application expects an input text file named `unsorted-names-list.txt` to be located in the same working directory as the executable. Each name in the file should be on a new line. The format of each name should be a sequence of one or more first names followed by a last name, separated by spaces (e.g., "John Smith", "Mary Anne Jones").

**Example `unsorted-names-list.txt`:**
```
    Marin Alvarez
    Adonis Julius Archer
    Beau Tristan Bentley 
    Hunter Uriah Mathew Clarke
    Leo Gardner
    Vaughn Lewis
    London Lindsey
    Mikayla Lopez
    Janet Parsons
    Frankie Conner Ritter
    Shelby Nathan Yoder
```

## Output

The application produces the following output:

**Console Output:** The sorted list of names will be printed to the console after processing the input file.

**Example Console Output:**

    ```
        Sorted Names:
        Marin Alvarez
        Adonis Julius Archer
        Beau Tristan Bentley
        Hunter Uriah Mathew Clarke
        Leo Gardner
        Vaughn Lewis
        London Lindsey
        Mikayla Lopez
        Janet Parsons
        Frankie Conner Ritter
        Shelby Nathan Yoder
        Sorted names written to: sorted-names-list.txt
    ```

 It will also create a file named `sorted-names-list.txt` in the same working directory. This file will contain the same sorted list of names, with one name per line.

 ## How to Run the Application

1.  **Clone the Repository:** If you haven't already, clone the GitHub repository to your local machine.

> **Note:** In order to build and run app consider taking out the folder *NameSorter.Tests* from main app workspace.

2.  **Navigate to the Project Directory:** Open your terminal or command prompt and navigate to the root directory of the project (the one containing the `NameSorter.csproj` file).

3.  **Build the Application:** Use the .NET CLI (Command Line Interface) to build the application:

    ```bash
      dotnet build
    ```

    This command will compile the C# code.

4.  **Run the Application:** Navigate to the project folder where the .csproj file located:

    ```bash
       dotnet run
    ```

    Make sure the `unsorted-names-list.txt` file is present in the same directory where you execute this command (which is the project's root directory after building).

## General Notes:

* The application sorts names primarily by the last name and then by the first name for names with the same last name.
* The application assumes that the last word in each line of the input file is the last name.
