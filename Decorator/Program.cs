
var personelCar = new PersonelCar() { Make = "BMW", Model = "3.20", HirePrice = 2500 };
SpecialOffer SpecialOffer = new SpecialOffer(personelCar);
SpecialOffer.DiscountPercentage = 10;
Console.WriteLine("Special Offer : " + SpecialOffer.HirePrice);
Console.WriteLine("Personel Price : " + personelCar.HirePrice);

abstract class CarBase
{
    public abstract string Make { get; set; } // Bu özellikleri ezmek istediğimiz için abstract tanımlıyoruz.
    public abstract string Model { get; set; }
    public abstract decimal HirePrice { get; set; }
}

abstract class CarDecoratorBase : CarBase
{
    private CarBase _carBase;
    protected CarDecoratorBase(CarBase carBase)
    {
        _carBase = carBase;
    }
    
}

class SpecialOffer : CarDecoratorBase
{
    private readonly CarBase _carBase;
    public int DiscountPercentage { get; set; }
    public SpecialOffer(CarBase carBase) : base(carBase)
    {
        _carBase = carBase;
    }

    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice
    { 
        get
        {
            return _carBase.HirePrice - _carBase.HirePrice *DiscountPercentage/100;
        }
        
        set
        {

        }
    }
}
class PersonelCar : CarBase
{
    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice { get; set; }
}

class CommercialCar : CarBase
{
    public override string Make { get; set; }
    public override string Model { get; set; }
    public override decimal HirePrice { get; set; }
}