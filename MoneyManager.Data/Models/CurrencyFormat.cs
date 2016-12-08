using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Data
{
    public class CurrencyFormat
    {
        public int Id { get; set; }
        public string CurrencyName { get; set; }
        public string pfx_symbol { get; set; }
        public string sfx_symbol { get; set; }
        public char decimal_point { get; set; }
        public char group_separator { get; set; }
        public string UnitName { get; set; }
        public string CentName { get; set; }
        public double Scale { get; set; }
        public decimal BaseConversionRate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Asset> Assets { get; set; }
        
        public string DisplayValue
        {
            get { return string.Format("{0}{1} - {2}", this.pfx_symbol, this.sfx_symbol, this.CurrencyName); }
        }
    }
}
