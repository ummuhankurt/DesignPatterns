using System.Data;
using System.Security.Cryptography.X509Certificates;


CustomerManager customerManager = new CustomerManager();
customerManager.messageSenderBase = new MailManager();
customerManager.UpdateCustomer();

abstract class MessageSenderBase
{
    public void Save()
    {
        Console.WriteLine("Message saved !");
    }
  
    public abstract void Send(Body body);
}

class Body
{
    public string Title { get; set; }
    public string Text { get; set; }
    public string Subject { get; set; }
}

class MailManager : MessageSenderBase
{    
    public override void Send(Body body)
    {
        Console.WriteLine("{0} was sent via MailSender.",body.Title);
    }
}

class SmsManager : MessageSenderBase
{
    public override void Send(Body body)
    {
        Console.WriteLine("{0} was sent via SmsSender.",body.Title);
    }
}

class CustomerManager
{
    public MessageSenderBase messageSenderBase { get; set; }
    public void UpdateCustomer()
    {
        messageSenderBase.Send(new Body{ Title = "Title "});
        Console.WriteLine("Customer updated !");
    }
}