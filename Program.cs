using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public string Name { get; set; }
    public int Age { get; set; }
    public char Grade { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Grade: {Grade}";
    }
}

class Program
{
    static List<Student> students = new List<Student>()
    {
        new Student { Name = "Alice", Age = 20, Grade = 'A' },
        new Student { Name = "Bob", Age = 22, Grade = 'B' },
        new Student { Name = "Charlie", Age = 23, Grade = 'A' },
        new Student { Name = "David", Age = 21, Grade = 'C' },
        new Student { Name = "Eve", Age = 22, Grade = 'B' }
    };

    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\n--- LINQ Query Options ---");
            Console.WriteLine("1. Find all students with a specific grade");
            Console.WriteLine("2. Sort students by age");
            Console.WriteLine("3. Group students by grade");
            Console.WriteLine("4. Select only student names");
            Console.WriteLine("5. Convert LINQ results to array");
            Console.WriteLine("6. Convert LINQ results to list");
            Console.WriteLine("7. Query syntax vs Method syntax comparison");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    FindStudentsByGrade();
                    break;
                case 2:
                    SortStudentsByAge();
                    break;
                case 3:
                    GroupStudentsByGrade();
                    break;
                case 4:
                    SelectStudentNames();
                    break;
                case 5:
                    ConvertResultsToArray();
                    break;
                case 6:
                    ConvertResultsToList();
                    break;
                case 7:
                    CompareQueryAndMethodSyntax();
                    break;
                case 8:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }

    // LINQ Query: Find students by specific grade
    static void FindStudentsByGrade()
    {
        Console.Write("Enter grade to search (A, B, C): ");
        char grade = char.Parse(Console.ReadLine());

        // Using Method Syntax
        var result = students.Where(s => s.Grade == grade).ToList();

        Console.WriteLine("\nStudents with grade " + grade + ":");
        result.ForEach(Console.WriteLine);
    }

    // LINQ Query: Sort students by age
    static void SortStudentsByAge()
    {
        // Using Method Syntax
        var sortedStudents = students.OrderBy(s => s.Age).ToList();

        Console.WriteLine("\nStudents sorted by age:");
        sortedStudents.ForEach(Console.WriteLine);
    }

    // LINQ Query: Group students by grade
    static void GroupStudentsByGrade()
    {
        // Using Method Syntax
        var groupedByGrade = students.GroupBy(s => s.Grade);

        Console.WriteLine("\nStudents grouped by grade:");
        foreach (var group in groupedByGrade)
        {
            Console.WriteLine($"Grade: {group.Key}");
            foreach (var student in group)
            {
                Console.WriteLine(student);
            }
        }
    }

    // LINQ Query: Select only student names
    static void SelectStudentNames()
    {
        // Using Method Syntax
        var studentNames = students.Select(s => s.Name).ToList();

        Console.WriteLine("\nStudent Names:");
        studentNames.ForEach(Console.WriteLine);
    }

    // LINQ Query: Convert result to array
    static void ConvertResultsToArray()
    {
        // Using Method Syntax
        var resultArray = students.Where(s => s.Grade == 'A').ToArray();

        Console.WriteLine("\nStudents with Grade A (Array):");
        foreach (var student in resultArray)
        {
            Console.WriteLine(student);
        }
    }

    // LINQ Query: Convert result to list
    static void ConvertResultsToList()
    {
        // Using Method Syntax
        var resultList = students.Where(s => s.Grade == 'B').ToList();

        Console.WriteLine("\nStudents with Grade B (List):");
        resultList.ForEach(Console.WriteLine);
    }

    // Compare LINQ Query Syntax and Method Syntax
    static void CompareQueryAndMethodSyntax()
    {
        Console.WriteLine("\n--- Query Syntax vs Method Syntax ---");

        // Query Syntax: Find students with Grade 'A'
        var querySyntax = from s in students
                          where s.Grade == 'A'
                          select s;

        // Method Syntax: Find students with Grade 'A'
        var methodSyntax = students.Where(s => s.Grade == 'A');

        Console.WriteLine("\nQuery Syntax Result:");
        foreach (var student in querySyntax)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine("\nMethod Syntax Result:");
        foreach (var student in methodSyntax)
        {
            Console.WriteLine(student);
        }

        Console.WriteLine("\nBoth syntaxes yield the same result, but query syntax looks more SQL-like, while method syntax is more C#-like and is often preferred for complex queries.");
    }
}
