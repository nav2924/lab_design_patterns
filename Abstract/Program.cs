using System;

// Abstract classes
public abstract class UserRegistration
{
    public abstract void RegisterUser(string username, string password);
}

public abstract class UserAuthentication
{
    public abstract bool Login(string username, string password);
    public abstract void Logout(string username);
}

public abstract class CourseManagement
{
    public abstract void AddCourse(string courseName);
    public abstract void RemoveCourse(string courseName);
    public abstract void ListCourses();
}

public abstract class CourseEnrollment
{
    public abstract void EnrollInCourse(string username, string courseName);
}

public abstract class ProgressTracking
{
    public abstract void TrackProgress(string username, string courseName, double progress);
}

public abstract class CourseAssessment
{
    public abstract void TakeQuiz(string username, string courseName, double score);
}

public abstract class CertificateGeneration
{
    public abstract void GenerateCertificate(string username, string courseName);
}

public abstract class UserProfile
{
    public abstract void ViewProfile(string username);
    public abstract void UpdateProfile(string username, string newInfo);
}

public abstract class AdminManagement
{
    public abstract void RemoveUser(string username);
    public abstract void AddAdmin(string username);
}

public abstract class AnalyticsReporting
{
    public abstract void GenerateReport(string reportType);
}

// Derived classes
public class UserRegistrationImpl : UserRegistration
{
    public override void RegisterUser(string username, string password)
    {
        Console.WriteLine($"User {username} registered successfully.");
    }
}

public class UserAuthenticationImpl : UserAuthentication
{
    public override bool Login(string username, string password)
    {
        Console.WriteLine($"User {username} logged in successfully.");
        return true;
    }

    public override void Logout(string username)
    {
        Console.WriteLine($"User {username} logged out successfully.");
    }
}

public class CourseManagementImpl : CourseManagement
{
    public override void AddCourse(string courseName)
    {
        Console.WriteLine($"Course '{courseName}' added successfully.");
    }

    public override void RemoveCourse(string courseName)
    {
        Console.WriteLine($"Course '{courseName}' removed.");
    }

    public override void ListCourses()
    {
        Console.WriteLine("Listing all available courses:");
        Console.WriteLine("1. C# for Beginners");
        Console.WriteLine("2. Introduction to Machine Learning");
    }
}

public class CourseEnrollmentImpl : CourseEnrollment
{
    public override void EnrollInCourse(string username, string courseName)
    {
        Console.WriteLine($"User {username} enrolled in course '{courseName}'.");
    }
}

public class ProgressTrackingImpl : ProgressTracking
{
    public override void TrackProgress(string username, string courseName, double progress)
    {
        Console.WriteLine($"User {username} is {progress}% complete in course '{courseName}'.");
    }
}

public class CourseAssessmentImpl : CourseAssessment
{
    public override void TakeQuiz(string username, string courseName, double score)
    {
        Console.WriteLine($"User {username} took the quiz for '{courseName}' and scored {score}.");
    }
}

public class CertificateGenerationImpl : CertificateGeneration
{
    public override void GenerateCertificate(string username, string courseName)
    {
        Console.WriteLine($"Certificate generated for {username} for completing '{courseName}'.");
    }
}

public class UserProfileImpl : UserProfile
{
    public override void ViewProfile(string username)
    {
        Console.WriteLine($"Displaying profile for {username}.");
    }

    public override void UpdateProfile(string username, string newInfo)
    {
        Console.WriteLine($"Profile updated for {username} with new info: {newInfo}.");
    }
}

public class AdminManagementImpl : AdminManagement
{
    public override void RemoveUser(string username)
    {
        Console.WriteLine($"User {username} has been removed.");
    }

    public override void AddAdmin(string username)
    {
        Console.WriteLine($"User {username} has been granted admin privileges.");
    }
}

public class AnalyticsReportingImpl : AnalyticsReporting
{
    public override void GenerateReport(string reportType)
    {
        Console.WriteLine($"Generating {reportType} report...");
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create objects for derived classes
        UserRegistration userRegistration = new UserRegistrationImpl();
        UserAuthentication userAuthentication = new UserAuthenticationImpl();
        CourseManagement courseManagement = new CourseManagementImpl();
        CourseEnrollment courseEnrollment = new CourseEnrollmentImpl();
        ProgressTracking progressTracking = new ProgressTrackingImpl();
        CourseAssessment courseAssessment = new CourseAssessmentImpl();
        CertificateGeneration certificateGeneration = new CertificateGenerationImpl();
        UserProfile userProfile = new UserProfileImpl();
        AdminManagement adminManagement = new AdminManagementImpl();
        AnalyticsReporting analyticsReporting = new AnalyticsReportingImpl();

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
