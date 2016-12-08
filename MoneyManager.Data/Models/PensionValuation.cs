using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Data
{
    public class PensionValuation
    {
        public int Id { get; set; }
        public System.DateTime ValuationDate { get; set; }
        public decimal PersonalContributions { get; set; }
        public decimal EmployerContributions { get; set; }
        public decimal Valuation { get; set; }

        public virtual Pension Pension { get; set; }
        
        public decimal TotalContributions
        {
            get { return this.PersonalContributions + this.EmployerContributions; }
        }

        public decimal Difference
        {
            get { return this.Valuation - this.TotalContributions; }
        }

        public decimal DifferencePercent
        {
            get { return this.Difference / this.Valuation; }
        }
    }
}
