using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Data
{
    public class RepeatingTransaction : BaseTransaction
    {
        public RepeatType Repeat { get; set; }
        public int TimesRepeated { get; set; }
        public bool AutoExecute { get; set; }
        public System.DateTime NextPrompt { get; set; }
        public int DayOfMonth { get; set; }
        public bool Deleted { get; set; }

        private System.DateTime _nextoccurence { get; set; }
        public System.DateTime NextOccurence
        {
            get { return _nextoccurence; }
            set
            {
                _nextoccurence = value;
                NextPrompt = value;
            }
        }

        public enum RepeatType
        {
            None = 0,
            Weekly,
            BiWeekly,
            Monthly,
            BiMonthly,
            Quarterly,
            HalfYearly,
            Yearly,
            FourMonths,
            FourWeeks,
            Daily,
            LastDayOfMonth,
            LastWeekdayOfMonth,
            LastWeekdayBeforeNthDayOfMonth
        }
        
        public decimal MonthlyAmount
        {
            get
            {
                switch (Repeat)
                {
                    case RepeatType.Weekly:
                        return TransAmount * (31 / 7);
                    case RepeatType.BiWeekly:
                        return TransAmount * (31 / 14);
                    case RepeatType.BiMonthly:
                        return TransAmount / 2;
                    case RepeatType.Quarterly:
                        return TransAmount / 3;
                    case RepeatType.HalfYearly:
                        return TransAmount / 6;
                    case RepeatType.Yearly:
                        return TransAmount / 12;
                    case RepeatType.FourMonths:
                        return TransAmount / 4;
                    case RepeatType.FourWeeks:
                        return TransAmount * (31 / 28);
                    case RepeatType.Daily:
                        return TransAmount * 31;
                    case RepeatType.None:
                    case RepeatType.Monthly:
                    case RepeatType.LastDayOfMonth:
                    case RepeatType.LastWeekdayOfMonth:
                    case RepeatType.LastWeekdayBeforeNthDayOfMonth:
                    default:
                        return TransAmount;

                }                
            }
        }

        public int RemainingDays
        {
            get
            {
                return (NextOccurence.Date - DateTime.Now.Date).Days;
            }
        }        
    }
}
