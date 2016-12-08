using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Data
{
    public class Transaction : BaseTransaction
    {
        public Transaction()
        {

        }

        public Transaction(RepeatingTransaction r)
        {
            this.TransactionDate = r.NextOccurence;
            this.TransactionTypeId = r.TransactionTypeId;
            this.TransAmount = r.TransAmount;
            this.StatusId = r.StatusId;
            this.Notes = r.Notes;
            this.Account = r.Account;
            this.Payee = r.Payee;
            this.Category = r.Category;
            this.ToAccount = r.ToAccount;
            this.RepeatingTransactionId = r.Id;
        }

        public System.DateTime TransactionDate { get; set; }
        public Nullable<int> RepeatingTransactionId { get; set; }

        public virtual ICollection<Flag> Flags { get; set; }

        public string StatusShort
        {
            get
            {
                switch (this.StatusId)
                {
                    case 0:
                        return "";
                    case 1:
                        return "R";
                    case 2:
                        return "V";
                    case 3:
                        return "F";
                    case 4:
                        return "D";
                    default:
                        return "";
                }
            }
        }

    }
}
