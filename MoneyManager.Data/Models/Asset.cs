using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Data
{
    public class Asset
    {
        public enum ValueChangeType
        {
            None = 0,
            Depreciation,
            Appreciation
        }

        public enum AssetType
        {
            RealEstate,
            Automobile,
            HouseholdObject,
            Art,
            Jewellery,
            Cash,
            Other,
        }

        public int AssetId { get; set; }
        public string AssetName { get; set; }
        public DateTime PurchaseDate { get; set; }
        public decimal PurchaseValue { get; set; }
        public decimal ValueChangeRate { get; set; }
        public int ValueChange { get; set; }
        public string Notes { get; set; }
        public int Type { get; set; }
        
        public string AssetTypeName
        {
            get
            {
                switch (Type)
                {
                    case 3:
                        return "Art";
                    case 1:
                        return "Automobile";
                    case 5:
                        return "Cash";
                    case 2:
                        return "Household Object";
                    case 4:
                        return "Jewellery";
                    case 6:
                        return "Other";
                    case 0:
                        return "Real Estate";
                    default:
                        return "Unknown";
                }
            }
        }
                
        public decimal ValueChangeRatePercent
        {
            get { return ValueChangeRate * 100; }
        }

        public decimal CurrentValue
        {
            get { return ValueAt(DateTime.Now); }
        }

        public decimal ValueAt(DateTime ValuationDate)
        {
            if (this.ValueChange == 0)
            {
                return this.PurchaseValue;
            }
            else
            {
                TimeSpan ts = ValuationDate - this.PurchaseDate;
                int numberOfDays = ts.Days;
                double valueChangePerYear = (double)this.ValueChangeRate;

                if (this.ValueChange == 1)
                {
                    valueChangePerYear = -valueChangePerYear;
                }

                double y = numberOfDays / 365;

                return PurchaseValue * (decimal)(Math.Pow((1 + valueChangePerYear), y));

            }

        }
    }
}
