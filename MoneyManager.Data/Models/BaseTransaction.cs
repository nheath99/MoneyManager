using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Data
{
    public abstract class BaseTransaction
    {
        public enum TransactionType
        {
            Withdrawal = 0,
            Deposit,
            Transfer
        }

        public enum TransactionStatus
        {
            None = 0,
            Reconciled,
            Void,
            FollowUp,
            Duplicate
        }

        public int Id { get; set; }
        public string TransCode { get; set; }
        public int TransactionTypeId { get; set; }
        public decimal TransAmount { get; set; }
        public int StatusId { get; set; }
        public int? TransactionNumber { get; set; }
        public string Notes { get; set; }

        public virtual Account Account { get; set; }
        public virtual Account ToAccount { get; set; }
        public virtual Payee Payee { get; set; }
        public virtual Category Category { get; set; }

        public string TransactionTypeName
        {
            get
            {
                switch (this.TransactionTypeId)
                {
                    case 0:
                        return "Withdrawal";
                    case 1:
                        return "Deposit";
                    case 2:
                        return "Transfer";
                    default:
                        return "Invalid";
                }
            }
        }
    }
}
