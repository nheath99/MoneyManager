using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Data
{
    public class Payee
    {
        public int Id { get; set; }
        public string PayeeName { get; set; }
        public bool? IsActive { get; set; }

        public virtual Category LastCategory { get; set; }
        public virtual IEnumerable<Transaction> Transactions { get; set; }
    }
}
