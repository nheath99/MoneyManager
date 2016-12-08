using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Data
{
    public class AccountType
    {
        public int Id { get; set; }
        public string AccountTypeName { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
