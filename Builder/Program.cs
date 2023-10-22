using System.Reflection;
{
    ProductDirector productDirector = new ProductDirector();
    var builder = new NewCustomerProductBuilder();
    productDirector.GenerateProduct(builder);

    var result = productDirector.GetProduct(builder);

    Console.WriteLine(result.Id);
    Console.WriteLine(result.ProductName);
    Console.WriteLine(result.CategoryName);
    Console.WriteLine(result.DiscountApplied);
    Console.WriteLine("discounted price : " + result.DiscountedPrice);
    Console.WriteLine("unit price : " + result.UnitPrice);
    //var model = builder.GetModel();
    //Console.WriteLine(model.Id);
    //Console.WriteLine(model.ProductName);
    //Console.WriteLine(model.CategoryName);
    //Console.WriteLine(model.DiscountApplied);
    //Console.WriteLine("discounted price : " + model.DiscountedPrice);
    //Console.WriteLine("unit price : " + model.UnitPrice);

}


public class ProductViewModel
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal DiscountedPrice { get; set; }
    public bool DiscountApplied { get; set; }
}

public abstract class ProductBuilder
{
    public abstract void GetProductData();
    public abstract void ApplyDiscount();
    public abstract ProductViewModel GetModel();
}

public class NewCustomerProductBuilder : ProductBuilder
{
    ProductViewModel model = new ProductViewModel();

    public override void ApplyDiscount()
    {
        model.DiscountApplied = true;
        model.DiscountedPrice = model.UnitPrice*(decimal)0.90;
    }

    public override ProductViewModel GetModel()
    {
        return model;
    }

    public override void GetProductData()
    {

        model.Id = 1;
        model.CategoryName = "Beverages";
        model.ProductName = "Chai";
        model.UnitPrice = 20;

    }
}

public class OldCustomerProductBuilder : ProductBuilder
{
    ProductViewModel model = new ProductViewModel();

    public override void ApplyDiscount()
    {
        model.DiscountedPrice = model.UnitPrice;
        model.DiscountApplied = false;
    }

    public override ProductViewModel GetModel()
    {
        return model;
    }

    public override void GetProductData()
    {

        model.Id = 1;
        model.CategoryName = "Beverages";
        model.ProductName = "Chai";
        model.UnitPrice = 20;

    }
}

public class ProductDirector
{
    public void GenerateProduct(ProductBuilder builder)
    {
        builder.GetProductData();
        builder.ApplyDiscount();

    }

    public ProductViewModel GetProduct(ProductBuilder builder)
    {
        return builder.GetModel();

    }
}