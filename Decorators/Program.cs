using System;

// Abstract classes remain the same
public abstract class UserRegistration
{
    public abstract void RegisterUser(string username, string password);
}

public abstract class UserAuthentication
{
    public abstract bool Login(string username, string password);
    public abstract void Logout(string username);
}

public class UserRegistrationDecorator : UserRegistration
{
    private readonly UserRegistration _userRegistration;

    public UserRegistrationDecorator(UserRegistration userRegistration)
    {
        _userRegistration = userRegistration;
    }

    public override void RegisterUser(string username, string password)
    {
        Console.WriteLine("[Log] Before RegisterUser");
        _userRegistration.RegisterUser(username, password);
        Console.WriteLine("[Log] After RegisterUser");
    }
}

// Decorator for UserAuthentication
public class UserAuthenticationDecorator : UserAuthentication
{
    private readonly UserAuthentication _userAuthentication;

    public UserAuthenticationDecorator(UserAuthentication userAuthentication)
    {
        _userAuthentication = userAuthentication;
    }

    public override bool Login(string username, string password)
    {
        Console.WriteLine("[Log] Before Login");
        bool result = _userAuthentication.Login(username, password);
        Console.WriteLine("[Log] After Login");
        return result;
    }

    public override void Logout(string username)
    {
        Console.WriteLine("[Log] Before Logout");
        _userAuthentication.Logout(username);
        Console.WriteLine("[Log] After Logout");
    }
}

// Decorators for other components would follow a similar pattern...

// Implementation classes remain the same
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

// Main program
class Program
{
    static void Main(string[] args)
    {
        // Create base objects
        UserRegistration userRegistration = new UserRegistrationImpl();
        UserAuthentication userAuthentication = new UserAuthenticationImpl();

        // Decorate the objects
        UserRegistration decoratedUserRegistration = new UserRegistrationDecorator(userRegistration);
        UserAuthentication decoratedUserAuthentication = new UserAuthenticationDecorator(userAuthentication);

        // Use the decorated objects
        decoratedUserRegistration.RegisterUser("JohnDoe", "password123");
        decoratedUserAuthentication.Login("JohnDoe", "password123");
        decoratedUserAuthentication.Logout("JohnDoe");
    }
}
