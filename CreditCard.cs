using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditCard
{
    public class CreditCard
    {
       
        private string cardNumber;
        private string cardholderName;
        private DateTime expirationDate;
        private string pin;
        private decimal creditLimit;
        private decimal balance;

        
        public event EventHandler<decimal> AccountReplenishment;      // Пополнение счета
        public event EventHandler<decimal> MoneySpending;             // Расход денег
        public event EventHandler CreditMoneyUsageStarted;            // Старт использования кредитных денег
        public event EventHandler<decimal> TargetBalanceReached;      // Достижение заданной суммы денег
        public event EventHandler PinChanged;                         // Смена PIN

      
        public CreditCard(string cardNumber, string cardholderName, DateTime expirationDate, string pin, decimal creditLimit)
        {
            this.cardNumber = cardNumber;
            this.cardholderName = cardholderName;
            this.expirationDate = expirationDate;
            this.pin = pin;
            this.creditLimit = creditLimit;
            this.balance = 0;
        }

      
        public void ReplenishAccount(decimal amount)
        {
            balance += amount;
            AccountReplenishment?.Invoke(this, amount);
        }

        
        public void SpendMoney(decimal amount)
        {
            balance -= amount;
            MoneySpending?.Invoke(this, amount);
        }

      
        public void StartUsingCreditMoney()
        {
            CreditMoneyUsageStarted?.Invoke(this, EventArgs.Empty);
        }

        
        public void CheckTargetBalance(decimal targetAmount)
        {
            if (balance >= targetAmount)
            {
                TargetBalanceReached?.Invoke(this, targetAmount);
            }
        }

        public void ChangePin(string newPin)
        {
            pin = newPin;
            PinChanged?.Invoke(this, EventArgs.Empty);
        }
    }

}
