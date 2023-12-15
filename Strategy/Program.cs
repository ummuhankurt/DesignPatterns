
CustomerManager customerManager = new CustomerManager();
customerManager.CreditManagerBase = new After2010CalculateCredit();
customerManager.SaveCredit();
customerManager.CreditManagerBase = new Before2012CalculateCredit();
customerManager.SaveCredit();


abstract class CreditManagerBase
{
    public abstract void CalculateCredit();
}


class Before2012CalculateCredit : CreditManagerBase
{
    public override void CalculateCredit()
    {
        Console.WriteLine("Credit calculated using before2010.");
    }

}


class After2010CalculateCredit : CreditManagerBase
{
    public override void CalculateCredit()
    {
        Console.WriteLine("Credit calculated using after2010.");
    }
}


class CustomerManager
{
    public CreditManagerBase CreditManagerBase { get; set; }
    public void SaveCredit()
    {
        Console.WriteLine("Customer manager bussiness");

        CreditManagerBase.CalculateCredit();

    }
}