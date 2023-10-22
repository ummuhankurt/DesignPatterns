﻿Customer customer = new Customer { Id = 1 , FirstName = "Engin", LastName = "Demiroğ", City = "Ankara"};
var customer2 = (Customer)customer.Clone();
customer2.FirstName = "Salih";
Console.WriteLine(customer.FirstName);
Console.WriteLine(customer2.FirstName);


public abstract class Person
{
    public abstract Person Clone();

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

public class Customer : Person
{
    public string City { get; set; }

    public override Person Clone()
    {
        return (Person) MemberwiseClone();
    }
}

public class Employee : Person
{
    public decimal Salary { get; set; }

    public override Person Clone()
    {
        return (Person) MemberwiseClone();
    }
}