class Program
{
    static void Main(string[] args)
    {
        ProductManager productManager = new ProductManager(new Factory1());
        productManager.GetAll();
    }


    public abstract class Logging
    {
        public abstract void Log(string message);
    }

    public abstract class Caching
    {
        public abstract void Cache(string data);
    }

    public class Log4NetLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with Log4Net");
        }
    }

    public class NLogger : Logging
    {
        public override void Log(string message)
        {
            Console.WriteLine("Logged with NLogger");
        }
    }

   

    public class MemCache : Caching
    {
        public override void Cache(string data) 
        {
            Console.WriteLine("Cach with Memcache");
        }
    }

    public class RedisCache : Caching
    {
        public override void Cache(string data)
        {
            Console.WriteLine("Cach with Rediscache");
        }
    }

    public abstract class CrossCottingConcernsFactory
    {
        public abstract Logging CreateLogger();
        public abstract Caching CreateCaching();
    }

    public class Factory1 : CrossCottingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new MemCache();
        }

        public override Logging CreateLogger()
        {
            return new Log4NetLogger();
        }
    }

    public class Factory2 : CrossCottingConcernsFactory
    {
        public override Caching CreateCaching()
        {
            return new RedisCache();
        }

        public override Logging CreateLogger()
        {
            return new NLogger();
        }
    }

    public class ProductManager
    {
        CrossCottingConcernsFactory _crossCottingConcernsFactory;
        Logging _logging;
        Caching _caching;
        public ProductManager(CrossCottingConcernsFactory crossCottingConcernsFactory)
        {
            _crossCottingConcernsFactory = crossCottingConcernsFactory;
        }
        public void GetAll()
        {
            _caching.Cache("data");
            _logging.Log("Message");
            Console.WriteLine("Product listed.");
        }
    }
}
