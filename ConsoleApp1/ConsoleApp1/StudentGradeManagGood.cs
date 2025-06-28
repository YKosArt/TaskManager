using System;
using System.Collections.Generic;
using System.Linq;
//The main class of the application, which contains the user interaction logic.
//It allows you to add students, add grades, and display information about students.
//Uses a list to store students.
class StudentGradeManager
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
