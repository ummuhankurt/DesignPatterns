
CustomerManager customerManager = new CustomerManager();
customerManager.Save();

public interface ILogging
{
    void Log();
}


public interface ICaching
{
    void Cache();
}

public interface IAuthorize
{
    void CheckUser();
}

public class Logging : ILogging
{
    public void Log()
    {
        Console.WriteLine("Logged");
    }
}


public class Caching : ICaching
{
    public void Cache()
    {
        Console.WriteLine("Cache");
    }
}

public interface IValidation
{
    void Validate();
}

public class Authorize : IAuthorize
{
    public void CheckUser()
    {
        Console.WriteLine("User Checked");
    }
}

public class Validadion : IValidation
{
    public void Validate()
    {
        Console.WriteLine("User validate !");
    }
}

public class CrossCuttingConcernsFacade
{
    public ILogging Logging;
    public ICaching Caching;
    public IAuthorize Authorize;
    public IValidation Validation;
    public CrossCuttingConcernsFacade() //Burada IOC kullanılabilirdi.
    {
        Logging = new Logging();
        Caching = new Caching();
        Authorize = new Authorize();
        Validation = new Validadion();
    }
}

public class CustomerManager
{
    private CrossCuttingConcernsFacade _concerns;
    public CustomerManager()
    {
        _concerns = new CrossCuttingConcernsFacade();
    }

    public void Save()
    {
        _concerns.Logging.Log();
        _concerns.Caching.Cache();
        _concerns.Authorize.CheckUser();
        _concerns.Validation.Validate();
        Console.WriteLine("Saved !");
    }
}