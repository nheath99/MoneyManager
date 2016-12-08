using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Data
{
    public class Pension
    {
        public int PensionId { get; set; }
        public string PensionName { get; set; }

        public virtual ICollection<PensionValuation> PensionValuations { get; set; }
    }
}
