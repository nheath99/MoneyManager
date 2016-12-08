using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using static MoneyManager.Data.RepeatingTransaction;

namespace MoneyManager.Data
{
    public class DataRepository : IDataRepository
    {
        public IEnumerable<Account> GetAccounts()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Account> GetAccount(int id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Account> GetAccountsByAccountType(int accountTypeId)
        {
            throw new NotImplementedException();
        }

        public void InsertAccount(Account account)
        {
            throw new NotImplementedException();
        }
        public void UpdateAccount(Account account)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactions(int accountId)
        {
            throw new NotImplementedException();
        }
        public decimal GetAccountBalance(int accountId)
        {
            throw new NotImplementedException();
        }
        public decimal GetAccountBalanceUnreconciled(int accountId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pension> GetPensions()
        {
            throw new NotImplementedException();
        }
        public decimal CurrentPensionValue(int pensionId)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Stock> GetStocks()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<RepeatingTransaction> GetRepeatingTransactions(bool onlyActive)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Asset> GetAssets()
        {
            throw new NotImplementedException();
        }

        public void ProcessRepeatingTransaction(int repeatingTransactionId)
        {
            throw new NotImplementedException();
        }
        public void InsertRepeatingTransaction(RepeatingTransaction r)
        {
            throw new NotImplementedException();
        }
        public void DeleteRepeatingTransaction(int id)
        {
            throw new NotImplementedException();
        }
        public void UpdateRepeatingTransaction(RepeatingTransaction r)
        {
            throw new NotImplementedException();
        }
        public void ProcessAllRepeatingTransactions(bool nextPrompt)
        {
            throw new NotImplementedException();
        }

        public DateTime? GetNextOccurance(RepeatingTransaction r)
        {
            if (r.TimesRepeated == 0)
                return null;

            switch (r.Repeat)
            {
                case RepeatType.Weekly:
                    return r.NextOccurence.AddDays(7);
                case RepeatType.BiWeekly:
                    return r.NextOccurence.AddDays(3.5);
                case RepeatType.Monthly:
                    return r.NextOccurence.AddMonths(1);
                case RepeatType.BiMonthly:
                    return r.NextOccurence.AddDays(14);
                case RepeatType.Quarterly:
                    return r.NextOccurence.AddMonths(3);
                case RepeatType.HalfYearly:
                    return r.NextOccurence.AddMonths(6);
                case RepeatType.Yearly:
                    return r.NextOccurence.AddYears(1);
                case RepeatType.FourMonths:
                    return r.NextOccurence.AddMonths(4);
                case RepeatType.FourWeeks:
                    return r.NextOccurence.AddDays(28);
                case RepeatType.Daily:
                    return r.NextOccurence.AddDays(1);
                case RepeatType.LastDayOfMonth:
                    DateTime newDate = r.NextOccurence.AddMonths(2);
                    return newDate.AddDays(0 - newDate.Day);
                case RepeatType.LastWeekdayOfMonth:
                    DateTime newDate1 = r.NextOccurence.AddMonths(2);
                    newDate1 = newDate1.AddDays(0 - newDate1.Day);

                    if (newDate1.DayOfWeek == DayOfWeek.Saturday)
                        newDate1 = newDate1.AddDays(-1);
                    if (newDate1.DayOfWeek == DayOfWeek.Sunday)
                        newDate1 = newDate1.AddDays(-1);
                    return newDate1;
                case RepeatType.LastWeekdayBeforeNthDayOfMonth:
                    DateTime newDate2 = r.NextOccurence.AddMonths(1);
                    if (r.DayOfMonth != 0)
                        newDate2 = newDate2.AddDays(0 - newDate2.Day + r.DayOfMonth);
                    if (newDate2.DayOfWeek == DayOfWeek.Saturday)
                        newDate2 = newDate2.AddDays(-1);
                    if (newDate2.DayOfWeek == DayOfWeek.Sunday)
                        newDate2 = newDate2.AddDays(-1);

                    return newDate2;
                case RepeatType.None:
                default:
                    return null;
            }
        }
    }
}
