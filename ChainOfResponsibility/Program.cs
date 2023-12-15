Manager manager = new Manager();
Director director = new Director();
DeputyGeneralManager generalManager = new DeputyGeneralManager();
manager.SetSuccessor(director);
director.SetSuccessor(generalManager);

Expense expense1 = new Expense() { Detail = "Training", Amount = 5554464 };
manager.HandleExpense(expense1);

class Expense
{
    public string Detail { get; set; }
    public decimal Amount { get; set; }
}

abstract class ExpenseHandlerBase // Harcamayı handle edecek kişileri implemente eder.
{
    protected ExpenseHandlerBase Successor;
    public abstract void HandleExpense(Expense expense);
    public void SetSuccessor(ExpenseHandlerBase successor)
    {
        Successor = successor;
    }
}

class Manager : ExpenseHandlerBase
{
    public override void HandleExpense(Expense expense)
    {
        if (expense.Amount <= 100)
        {
            Console.WriteLine("Manager handled the expense!");
        }
        else if(Successor != null )
        {
            Successor.HandleExpense(expense);
        }
    }
}

class Director : ExpenseHandlerBase
{
    public override void HandleExpense(Expense expense)
    {
        if (expense.Amount > 100 && expense.Amount <= 1000)
        {
            Console.WriteLine("Director handled the expense!");
        }
        else if (Successor != null)
        {
            Successor.HandleExpense(expense);
        }
    }
}

class DeputyGeneralManager : ExpenseHandlerBase
{
    public override void HandleExpense(Expense expense)
    {
        if (expense.Amount > 1000)
        {
            Console.WriteLine("Deputy General Manager handled the expense!");
        }
    }
}