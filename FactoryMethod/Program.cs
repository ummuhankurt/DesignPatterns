class Program
{
    static void Main(string[] args)
    {
        // Bu fabrika sonucunda hangi logger üretilecekse o logger üretilecek.
        CustomerManager customerManager = new CustomerManager(new LoggerFactory2());
        customerManager.Save();
    }
}

public class LoggerFactory : ILogerFactory
{
    // Asıl iş burada gerçekleşir. Örn webconfiğe bakılıp nasıl loglanıyorsa o döndürülür.
    // Factory to decide on business
    public ILogger CreateLogger()
    {
        return new EdLogger();
    }
}

public class LoggerFactory2 : ILogerFactory
{
    public ILogger CreateLogger()
    {
        return new Log4NetLogger();
    }
}

public interface ILogger
{
    void Log();
}

public interface ILogerFactory
{
    public ILogger CreateLogger();
}

public class EdLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Logged with EdLogger");
    }
}

public class Log4NetLogger : ILogger
{
    public void Log()
    {
        Console.WriteLine("Logged with Log4NetLogger.");
    }
}


public class CustomerManager
{
    private ILogerFactory _loggerFactory;
    public CustomerManager(ILogerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }
    public void Save()
    {
        Console.WriteLine("Saved.");
        //ILogger logger = new EdLogger(); Böyle yapmyoruz.Böyle yaparsak bağımlı oluruz.
        _loggerFactory.CreateLogger().Log();
    }
}