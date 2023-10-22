
ProductManager productManager = new ProductManager(new Log4NetAdapter());

ProductManager productManager2 = new ProductManager(new EdLogger());

productManager.Save();
productManager2.Save();


public class ProductManager
{
    ILogger _logger;
    public ProductManager(ILogger logger)
    {
        _logger = logger;
    }
    public void Save()
    {
        _logger.Log("User Data");
        Console.WriteLine("Saved !");
    }
}


public interface ILogger
{
    void Log(string message);
}

public class EdLogger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine("Logged {0} with EdLogger." , message);
    }
}


public class Log4Net 
{
    public void LogMessage(string message)
    {
        Console.WriteLine("Logged {0} with Log4Net.", message);
    }
}

public class Log4NetAdapter : ILogger
{
    public void Log(string message)
    {
        Log4Net log4Net = new Log4Net();
        log4Net.LogMessage(message);
    }
}