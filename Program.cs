namespace CreditCard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreditCard creditCard = new CreditCard("1234567890123456", "John Doe", new DateTime(2025, 12, 31), "1234", 1000);


            creditCard.AccountReplenishment += (sender, amount) =>
                Console.WriteLine("Пополнение счета: +" + amount + "$");
            creditCard.MoneySpending += (sender, amount) =>
                Console.WriteLine("Расход денег: -" + amount + "$");
            creditCard.CreditMoneyUsageStarted += (sender, e) =>
                Console.WriteLine("Начало использования кредитных средств");
            creditCard.TargetBalanceReached += (sender, targetAmount) =>
                Console.WriteLine("Достигнута целевая сумма: " + targetAmount + "$");
            creditCard.PinChanged += (sender, e) =>
                Console.WriteLine("Пин-код изменен");

           
            creditCard.ReplenishAccount(500);  
            creditCard.SpendMoney(200);        
            creditCard.ReplenishAccount(400);
            creditCard.CheckTargetBalance(600);
            creditCard.ChangePin("4321");      
        }
    }
}
