using System;

// Interfaces
public interface IUserRegistration
{
    void RegisterUser(string username, string password);
}

public interface IUserAuthentication
{
    bool Login(string username, string password);
    void Logout(string username);
}

public interface ICourseManagement
{
    void AddCourse(string courseName);
    void RemoveCourse(string courseName);
    void ListCourses();
}

public interface ICourseEnrollment
{
    void EnrollInCourse(string username, string courseName);
}

public interface IProgressTracking
{
    void TrackProgress(string username, string courseName, double progress);
}

public interface ICourseAssessment
{
    void TakeQuiz(string username, string courseName, double score);
}

public interface ICertificateGeneration
{
    void GenerateCertificate(string username, string courseName);
}

public interface IUserProfile
{
    void ViewProfile(string username);
    void UpdateProfile(string username, string newInfo);
}

public interface IAdminManagement
{
    void RemoveUser(string username);
    void AddAdmin(string username);
}

public interface IAnalyticsReporting
{
    void GenerateReport(string reportType);
}

// Implementing classes
public class UserRegistration : IUserRegistration
{
    public void RegisterUser(string username, string password)
    {
        Console.WriteLine($"User {username} registered successfully.");
    }
}

public class UserAuthentication : IUserAuthentication
{
    public bool Login(string username, string password)
    {
        Console.WriteLine($"User {username} logged in successfully.");
        return true;
    }

    public void Logout(string username)
    {
        Console.WriteLine($"User {username} logged out successfully.");
    }
}

public class CourseManagement : ICourseManagement
{
    public void AddCourse(string courseName)
    {
        Console.WriteLine($"Course '{courseName}' added successfully.");
    }

    public void RemoveCourse(string courseName)
    {
        Console.WriteLine($"Course '{courseName}' removed.");
    }

    public void ListCourses()
    {
        Console.WriteLine("Listing all available courses:");
        Console.WriteLine("1. C# for Beginners");
        Console.WriteLine("2. Introduction to Machine Learning");
    }
}

public class CourseEnrollment : ICourseEnrollment
{
    public void EnrollInCourse(string username, string courseName)
    {
        Console.WriteLine($"User {username} enrolled in course '{courseName}'.");
    }
}

public class ProgressTracking : IProgressTracking
{
    public void TrackProgress(string username, string courseName, double progress)
    {
        Console.WriteLine($"User {username} is {progress}% complete in course '{courseName}'.");
    }
}

public class CourseAssessment : ICourseAssessment
{
    public void TakeQuiz(string username, string courseName, double score)
    {
        Console.WriteLine($"User {username} took the quiz for '{courseName}' and scored {score}.");
    }
}

public class CertificateGeneration : ICertificateGeneration
{
    public void GenerateCertificate(string username, string courseName)
    {
        Console.WriteLine($"Certificate generated for {username} for completing '{courseName}'.");
    }
}

public class UserProfile : IUserProfile
{
    public void ViewProfile(string username)
    {
        Console.WriteLine($"Displaying profile for {username}.");
    }

    public void UpdateProfile(string username, string newInfo)
    {
        Console.WriteLine($"Profile updated for {username} with new info: {newInfo}.");
    }
}

public class AdminManagement : IAdminManagement
{
    public void RemoveUser(string username)
    {
        Console.WriteLine($"User {username} has been removed.");
    }

    public void AddAdmin(string username)
    {
        Console.WriteLine($"User {username} has been granted admin privileges.");
    }
}

public class AnalyticsReporting : IAnalyticsReporting
{
    public void GenerateReport(string reportType)
    {
        Console.WriteLine($"Generating {reportType} report...");
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create objects for each interface implementation
        IUserRegistration userRegistration = new UserRegistration();
        IUserAuthentication userAuthentication = new UserAuthentication();
        ICourseManagement courseManagement = new CourseManagement();
        ICourseEnrollment courseEnrollment = new CourseEnrollment();
        IProgressTracking progressTracking = new ProgressTracking();
        ICourseAssessment courseAssessment = new CourseAssessment();
        ICertificateGeneration certificateGeneration = new CertificateGeneration();
        IUserProfile userProfile = new UserProfile();
        IAdminManagement adminManagement = new AdminManagement();
        IAnalyticsReporting analyticsReporting = new AnalyticsReporting();

        // Sample workflow
        userRegistration.RegisterUser("JohnDoe", "password123");
        userAuthentication.Login("JohnDoe", "password123");
        courseManagement.AddCourse("C# for Beginners");
        courseEnrollment.EnrollInCourse("JohnDoe", "C# for Beginners");
        progressTracking.TrackProgress("JohnDoe", "C# for Beginners", 40);
        courseAssessment.TakeQuiz("JohnDoe", "C# for Beginners", 85);
        certificateGeneration.GenerateCertificate("JohnDoe", "C# for Beginners");
        userProfile.ViewProfile("JohnDoe");
        userProfile.UpdateProfile("JohnDoe", "New phone number: 1234567890");
        adminManagement.RemoveUser("JohnDoe");
        analyticsReporting.GenerateReport("Course Enrollment");
    }
}
