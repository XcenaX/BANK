using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BankLibrary
{
    public abstract class Account : IAccount
    {
        //Событие, возникающее при выводе денег
        protected internal event AccountStateHandler Withdrawed;
        // Событие возникающее при добавление на счет
        protected internal event AccountStateHandler Added;
        // Событие возникающее при открытии счета
        protected internal event AccountStateHandler Opened;
        // Событие возникающее при закрытии счета
        protected internal event AccountStateHandler Closed;
        // Событие возникающее при начислении процентов
        protected internal event AccountStateHandler Calculated;

        public int id { get; set; }
        static int counter = 0;

        protected decimal sum; //  суммa
        protected int percentage; //  процент

        protected int days = 0; // время с момента открытия счета

        public Account(decimal sum, int percentage)
        {
            this.sum = sum;
            this.percentage = percentage;
            id = ++counter;
        }

        // Текущая сумма на счету
        public decimal CurrentSum
        {
            get { return sum; }
        }

        public int Percentage
        {
            get { return percentage; }
        }

        public int Id
        {
            get { return id; }
        }
        // вызов событий
        private void CallEvent(AccountEventArgs e, AccountStateHandler handler)
        {
            if (handler != null && e != null)
                handler(this, e);
        }
        // вызов отдельных событий. Для каждого события определяется свой витуальный метод
        protected virtual void OnOpened(AccountEventArgs e)
        {
            CallEvent(e, Opened);
        }
        protected virtual void OnWithdrawed(AccountEventArgs e)
        {
            CallEvent(e, Withdrawed);
        }
        protected virtual void OnAdded(AccountEventArgs e)
        {
            CallEvent(e, Added);
        }
        protected virtual void OnClosed(AccountEventArgs e)
        {
            CallEvent(e, Closed);
        }
        protected virtual void OnCalculated(AccountEventArgs e)
        {
            CallEvent(e, Calculated);
        }

        public virtual void Put(decimal sum)
        {
            this.sum += sum;
            Clear();
            OnAdded(new AccountEventArgs("На вашем счету теперь:  " + this.sum, sum));
        }
        public virtual decimal Withdraw(decimal sum)
        {
            decimal result = 0;
            if (this.sum <= sum)
            {
                this.sum -= sum;
                result = sum;
                Clear();
                OnWithdrawed(new AccountEventArgs("Сумма " + this.sum + " снята со счета " + id, sum));
            }
            else
            {
                Clear();
                OnWithdrawed(new AccountEventArgs("Недостаточно денег на счете " + id + ")", 0));
            }
            return result;
        }
        // открытие счета
        protected internal virtual void Open()
        {
            Clear();
            OnOpened(new AccountEventArgs("Открыт новый депозитный счет!Id счета: " + this.id, this.sum));
        }
        // закрытие счета
        protected internal virtual void Close()
        {
            Clear();
            OnClosed(new AccountEventArgs("Счет " + id + " закрыт.  Итоговая сумма: " + CurrentSum, CurrentSum));
        }

        protected internal void IncrementDays()
        {
            days++;
        }
        // начисление процентов
        protected internal virtual void Calculate()
        {
            decimal increment = sum * percentage / 100;
            sum = sum + increment;
            OnCalculated(new AccountEventArgs("Начислены проценты в размере: " + increment,increment));
        }
    }
}
