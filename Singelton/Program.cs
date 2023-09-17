var customerManager = CustomerManager.CreateAsSingleton();
customerManager.Save();

//Eğer daha önce oluşturulmuş ise onu verir. Oluşturulmamış ise 1 tane oluşturup onu verir.
class CustomerManager
{
    static CustomerManager _customerManager; 
    static object _lockObject = new object();
    private CustomerManager()
    {

    }
    public static CustomerManager CreateAsSingleton()
    {
        #region Thread Safe Singleton
        //Birisi bu nesneyi üretme aşamasına geçer ve isterse ben o nesneyi önce bi kitleyeyim, kullanıcıya cevap vereyim onun işi bittikten sonra işlemi gerçekleştireyim
        //Kısacası nesne üretme işini lock'a bırakmış oluyoruz.

        lock (_lockObject)
        {
            if (_customerManager == null)
            {
                _customerManager = new CustomerManager();
            }
        }
   
        return _customerManager;
        #endregion

    }

    public void Save()
    {
        Console.WriteLine("Saved !");
    }
}