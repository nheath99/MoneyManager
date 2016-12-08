using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Data
{
    public class Flag
    {
        public int Id { get; set; }
        public string FlagName { get; set; }
        public bool Active { get; set; }
        public string FlagColorString { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
