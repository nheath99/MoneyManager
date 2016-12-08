using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Data
{
    public class Account
    {
        public enum AccountStatus
        {
            Open = 0,
            Closed
        }

        public int Id { get; set; }
        public string AccountName { get; set; }
        public string AccountNum { get; set; }
        public int StatusId { get; set; }
        public string Notes { get; set; }
        public decimal InitialBalance { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal InterestFreeCreditLimit { get; set; }
        public double CreditInterest { get; set; }
        public double DebitInterest { get; set; }

        public virtual CurrencyFormat CurrencyFormat { get; set; }
        public virtual ICollection<RepeatingTransaction> RepeatingTransactions { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual AccountType AccountType { get; set; }

        public string AccountStatusName
        {
            get
            {
                if (this.StatusId == 0)
                    return "Open";
                else
                    return "Closed";
            }
        }
    }
}
