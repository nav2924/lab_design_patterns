using System;

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

    public abstract void Register(string username, string password); // Abstract method

    public virtual void Login(string username, string password) // Virtual method
    {
        Console.WriteLine($"{username} logged in.");
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

    public override void Login(string username, string password) // Override virtual method
    {
        base.Login(username, password); // Use base class logic
        Console.WriteLine("Welcome to the platform!");
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

    public override void Login(string username, string password)
    {
        Console.WriteLine($"Admin {username} has logged in with special privileges.");
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
        // Create regular user and register
        RegularUser regularUser = new RegularUser();
        regularUser.Register("JohnDoe", "password123");
        regularUser.Login("JohnDoe", "password123");

        // Create admin user and register
        AdminUser adminUser = new AdminUser();
        adminUser.Register("AdminJane", "adminPass456");
        adminUser.Login("AdminJane", "adminPass456");

        // Manage courses
        CourseManagement courseManagement = new CourseManagement();
        courseManagement.AddCourse("C# for Beginners");
        courseManagement.ListCourses();
    }
}

z