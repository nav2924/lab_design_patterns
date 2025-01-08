using System;
using System.Collections.Generic;

public interface IUser
{
    void Register(string username, string password);
    void Login(string username, string password);
    void EnrollCourse(string courseName);
    void CompleteCourse(string courseName);
}

public abstract class UserBase : IUser
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<string> EnrolledCourses { get; set; } = new List<string>();

    public virtual void Register(string username, string password)
    {
        Username = username;
        Password = password;
        Console.WriteLine($"{username} registered successfully.");
    }

    public virtual void Login(string username, string password)
    {
        if (Username == username && Password == password)
        {
            Console.WriteLine($"{username} logged in successfully.");
        }
        else
        {
            Console.WriteLine("Invalid credentials!");
        }
    }

    public abstract void EnrollCourse(string courseName);

    public virtual void CompleteCourse(string courseName)
    {
        if (EnrolledCourses.Contains(courseName))
        {
            Console.WriteLine($"Course '{courseName}' completed successfully.");
            Certificate.GenerateCertificate(Username, courseName);
        }
        else
        {
            throw new Exception("Course not found in enrolled list.");
        }
    }
}

public class RegularUser : UserBase
{
    private const int MaxCourses = 5;

    public override void EnrollCourse(string courseName)
    {
        if (EnrolledCourses.Count >= MaxCourses)
        {
            throw new Exception("Maximum course limit reached for regular user.");
        }
        EnrolledCourses.Add(courseName);
        Console.WriteLine($"Regular user '{Username}' enrolled in course '{courseName}'.");
    }
}

public class AdminUser : UserBase
{
    public override void EnrollCourse(string courseName)
    {
        EnrolledCourses.Add(courseName);
        Console.WriteLine($"Admin user '{Username}' enrolled in course '{courseName}'.");
    }

    public override void CompleteCourse(string courseName)
    {
        if (EnrolledCourses.Contains(courseName))
        {
            Console.WriteLine($"Admin user '{Username}' completed course '{courseName}', but no certificate is issued.");
        }
        else
        {
            throw new Exception("Course not found in enrolled list.");
        }
    }
}

public interface ICourseManagement
{
    void AddCourse(string courseName);
    void ListCourses();
}

public class CourseManagement : ICourseManagement
{
    public List<string> AvailableCourses { get; set; } = new List<string>();

    public void AddCourse(string courseName)
    {
        AvailableCourses.Add(courseName);
        Console.WriteLine($"Course '{courseName}' added successfully.");
    }

    public void ListCourses()
    {
        Console.WriteLine("Available courses:");
        foreach (var course in AvailableCourses)
        {
            Console.WriteLine($"- {course}");
        }
    }
}

public static class Certificate
{
    public static void GenerateCertificate(string username, string courseName)
    {
        Console.WriteLine($"Certificate generated for user '{username}' for completing course '{courseName}'.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a course management system and add courses
        CourseManagement courseManagement = new CourseManagement();
        courseManagement.AddCourse("C# for Beginners");
        courseManagement.AddCourse("Introduction to Machine Learning");

        // Display available courses
        courseManagement.ListCourses();

        // Create regular user and admin user
        IUser regularUser = new RegularUser();
        IUser adminUser = new AdminUser();

        // Register and login users
        regularUser.Register("JohnDoe", "password123");
        regularUser.Login("JohnDoe", "password123");

        adminUser.Register("AdminJane", "adminPass456");
        adminUser.Login("AdminJane", "adminPass456");

        // Enroll courses and complete them
        try
        {
            // Regular user actions
            regularUser.EnrollCourse("C# for Beginners");
            regularUser.CompleteCourse("C# for Beginners");

            // Admin user actions
            adminUser.EnrollCourse("C# for Beginners");
            adminUser.CompleteCourse("C# for Beginners");

            // Trigger an exception: regular user tries to complete a course not enrolled in
            regularUser.CompleteCourse("Introduction to Machine Learning");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Trigger another exception: regular user exceeds course limit
        try
        {
            for (int i = 0; i < 6; i++)
            {
                regularUser.EnrollCourse($"Extra Course {i + 1}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
