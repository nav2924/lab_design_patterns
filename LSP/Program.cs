using System;
using System.Collections.Generic;

// Custom exception class for handling user-specific errors
public class UserException : Exception
{
    public UserException(string message) : base(message) { }
}

// Define an interface
public interface IUser
{
    void Register(string username, string password);
    void Login(string username, string password);
}

// Abstract base class for shared functionality
public abstract class UserBase : IUser
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<string> EnrolledCourses { get; set; } = new List<string>();

    public abstract void Register(string username, string password); // Abstract method

    public virtual void Login(string username, string password) // Virtual method
    {
        Console.WriteLine($"{username} logged in.");
    }

    public virtual void EnrollCourse(string courseName)
    {
        EnrolledCourses.Add(courseName);
        Console.WriteLine($"{Username} enrolled in {courseName}.");
    }

    public virtual void CompleteCourse(string courseName)
    {
        if (EnrolledCourses.Count == 0)
        {
            throw new UserException($"{Username} must be enrolled in at least one course to complete it.");
        }
        Console.WriteLine($"{Username} completed the course: {courseName}");
    }

    public virtual void GenerateCertificate(string courseName)
    {
        Console.WriteLine($"Certificate generated for {Username} for completing {courseName}.");
    }
}

// Derived class for regular users
public class RegularUser : UserBase
{
    public override void Register(string username, string password) // Implement abstract method
    {
        Username = username;
        Password = password;
        Console.WriteLine($"User {username} registered successfully.");
    }

    public override void EnrollCourse(string courseName)
    {
        if (EnrolledCourses.Count >= 5)
        {
            throw new UserException("Regular users can enroll in a maximum of 5 courses.");
        }
        base.EnrollCourse(courseName); // Use base class logic
    }

    public override void CompleteCourse(string courseName)
    {
        base.CompleteCourse(courseName); // Use base class logic
        GenerateCertificate(courseName); // Regular users receive a certificate after completing the course
    }
}

// Sealed class for admins
public sealed class AdminUser : UserBase
{
    public override void Register(string username, string password)
    {
        Username = username;
        Password = password;
        Console.WriteLine($"Admin {username} registered successfully.");
    }

    public override void CompleteCourse(string courseName)
    {
        if (EnrolledCourses.Count == 0)
        {
            throw new UserException($"{Username} must be enrolled in at least one course to complete it.");
        }
        Console.WriteLine($"Admin {Username} completed the course: {courseName}.");
    }
}

// Interface for course management
public interface ICourseManagement
{
    void AddCourse(string courseName);
    void ListCourses();
}

// Class implementing course management
public class CourseManagement : ICourseManagement
{
    public void AddCourse(string courseName)
    {
        Console.WriteLine($"Course '{courseName}' added successfully.");
    }

    public void ListCourses()
    {
        Console.WriteLine("Available courses:");
        Console.WriteLine("1. C# for Beginners");
        Console.WriteLine("2. Introduction to Machine Learning");
    }
}

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Creating a regular user and attempting to enroll in 6 courses
            RegularUser regularUser = new RegularUser();
            regularUser.Register("JohnDoe", "password123");
            for (int i = 1; i <= 6; i++)  // Attempt to enroll in 6 courses
            {
                regularUser.EnrollCourse($"Course {i}");
            }
        }
        catch (UserException ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }

        try
        {
            // Creating a regular user and attempting to complete a course without enrolling
            RegularUser regularUser = new RegularUser();
            regularUser.Register("JohnDoe", "password123");
            regularUser.CompleteCourse("Course 1");  // Attempt to complete without enrolling
        }
        catch (UserException ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }

        try
        {
            // Creating an admin user and attempting to complete a course without enrolling
            AdminUser adminUser = new AdminUser();
            adminUser.Register("AdminJane", "adminPass456");
            adminUser.CompleteCourse("Course 1");  // Attempt to complete without enrolling
        }
        catch (UserException ex)
        {
            Console.WriteLine($"Exception: {ex.Message}");
        }

        // Manage courses
        CourseManagement courseManagement = new CourseManagement();
        courseManagement.AddCourse("C# for Beginners");
        courseManagement.ListCourses();

        // Regular user completing a course and generating a certificate
        RegularUser userWithCertificate = new RegularUser();
        userWithCertificate.Register("JohnDoe", "password123");
        userWithCertificate.EnrollCourse("C# for Beginners");
        userWithCertificate.CompleteCourse("C# for Beginners");
    }
}
