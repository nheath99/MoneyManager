using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Data
{
    public class Stock
    {
        public int StockId { get; set; }
        public string Name { get; set; }
        public decimal UnitCost_Purchase { get; set; }
        public decimal Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
