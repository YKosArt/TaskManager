using System;
using System.Collections.Generic;
using System.Linq;
//We will use the Student class to store information about the student.
//Initializes a student object with a name and ID, and also creates an empty dictionary for grades.
class Student
{
    public string Name { get; set; }
    public int Id { get; set; }
    public Dictionary<string, int> Grades { get; set; }
//Initializes a student object with a name and ID, and also creates an empty dictionary for grades.
    public Student(string name, int id)
    {
        Name = name;
        Id = id;
        Grades = new Dictionary<string, int>();
    }
//Adds or updates a student's grade for a specific subject.
//If the subject already exists in the dictionary, its grade will be updated.
//If the subject does not exist, it will be added to the dictionary with a new grade.
    public void AddGrade(string subject, int grade)
    {
        Grades[subject] = grade;
    }
//Calculates the student's average grade across all subjects.
//If the student has no grades, returns 0.
//Otherwise, sums all grades and divides by the number of subjects.
    public double CalculateAverage()
    {
        if (Grades.Count == 0) return 0;
        int total = 0;
        var values = Grades.Values.ToList();
        for (int i = 0; i < values.Count; i++)
        {
            total += values[i];
        }
        return (double)total / Grades.Count;
    }
///Displays information about the student, including their ID, name, and grades by subject.
//Also displays the average score of the student.
    public void DisplayStudentInfo()
    {
        Console.WriteLine("ID: " + Id + ", Name: " + Name);
        Console.WriteLine("Grades:");
        var keys = Grades.Keys.ToList();
        var values = Grades.Values.ToList();
        for (int i = 0; i < keys.Count; i++)
        {
            Console.WriteLine("  " + keys[i] + ": " + values[i]);
        }
        Console.WriteLine("Average: " + (int)CalculateAverage());
    }
}
//The main class of the application, which contains the user interaction logic.
//It allows you to add students, add grades, and display information about students.
//Uses a list to store students.
class StudentGradeProgram
{
    static List<Student> students = new List<Student>();
//The main method of the program, which starts the loop for user interaction.
//It offers a menu with various options: add student, add grade, display records, and exit the program.
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Student Grade Management System");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Add Grade");
            Console.WriteLine("3. Display Student Records");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Choose an option: ");
//Processing user selections to perform various operations.
//Depending on the user's selection, one of the following functions is called:
// adding a student, adding a grade, displaying information, or terminating the program.
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    AddGrade();
                    break;
                case "3":
                    DisplayRecords();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
///Method for adding a new student.
//Asks the user for the student's name and ID, checks the correctness of the entered data
    static void AddStudent()
    {
        Console.WriteLine("Enter student name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter student ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            students.Add(new Student(name, id));
            Console.WriteLine("Student added successfully!");
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }
///Method for adding a grade to a student.
//Query the user for the student ID, subject, and grade.
//Checks if a student with that ID exists, and if so, adds a grade to the subject.
//If the student is not found, displays an error message.
    static void AddGrade()
    {
        Console.Write("Enter student ID: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            Student student = students.Find(s => s.Id == id);
            if (student != null)
            {
                Console.WriteLine("Enter subject: ");
                string subject = Console.ReadLine();
                Console.WriteLine("Enter grade: ");
                if (int.TryParse(Console.ReadLine(), out int grade))
                {
                    student.AddGrade(subject, grade);
                    Console.WriteLine("Grade added successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid grade input.");
                }
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }
///Method to display information about all students.
//Checks if there are students in the list, and if so, displays information about each student.
    static void DisplayRecords()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No student records available.");
            return;
        }

        for (int i = 0; i < students.Count; i++)
        {
            students[i].DisplayStudentInfo();
        }
    }
}

