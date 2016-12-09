using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using static MoneyManager.Data.RepeatingTransaction;
using System.Data.SqlClient;

namespace MoneyManager.Data
{
    public class DataRepository : IDataRepository
    {
        public DataRepository()
        {

        }

        public DataRepository(string connectionString)
        {

        }

        public string ConnectionString { get; private set; }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                return await con.QueryAsync<Account>("select a.* from [Accounts] a");
            }
        }
        public async Task<Account> GetAccountAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                return await con.QuerySingleOrDefaultAsync<Account>("select a.* from [Accounts] a where a.[Id] = @id", new { id });
            }
        }
        public async Task<IEnumerable<Account>> GetAccountsByAccountTypeAsync(int accountTypeId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                return await con.QueryAsync<Account>("select a.* from [Accounts] a where a.[AccountTypeId] = @accountTypeId", new { accountTypeId });
            }
        }

        public async Task<int> InsertAccountAsync(Account account)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateAccountAsync(Account account)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteAccountAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                await con.ExecuteAsync("delete from [Accounts] where [Id] = @id", new { id });
            }
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsAsync(int accountId)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                return await con.QueryAsync<Transaction>("select t.* from [Transactions] t where t.[AccountId] = @accountId", new { @accountId });
            }
        }
        public async Task<int> InsertTransactionAsync(Transaction t)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateTransactionAsync(Transaction t)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteTransactionAsync(int id)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                await con.ExecuteAsync("delete from [Accounts] where [Id] = @id", new { id });
            }
        }
        public async Task<decimal> GetAccountBalance(int accountId)
        {
            throw new NotImplementedException();
        }
        public async Task<decimal> GetAccountBalanceUnreconciledAsync(int accountId)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Transaction>> GetRelatedTransactionsAsync(int repeatingTransactionId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Pension>> GetPensionsAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<decimal> CurrentPensionValueAsync(int pensionId)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Stock>> GetStocksAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<RepeatingTransaction>> GetRepeatingTransactionsAsync(bool onlyActive)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<Asset>> GetAssetsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task ProcessRepeatingTransactionAsync(int repeatingTransactionId)
        {
            throw new NotImplementedException();
        }
        public async Task<int> InsertRepeatingTransactionAsync(RepeatingTransaction r)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateRepeatingTransactionAsync(RepeatingTransaction r)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteRepeatingTransactionAsync(int id)
        {
            throw new NotImplementedException();
        }
        public async Task ProcessAllRepeatingTransactionsAsync(bool nextPrompt)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertAssetAsync(Asset a)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateAssetAsync(Asset a)
        {
            throw new NotImplementedException();
        }
        public async Task DeleteAssetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<int> InsertPensionAsync(Pension p)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdatePensionAsync(Pension p)
        {
            throw new NotImplementedException();
        }
        public async Task DeletePension(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<IEnumerable<PensionValuation>> GetPensionValuations(int id, DateTime startDateTime, DateTime endDateTime)
        {
            throw new NotImplementedException();
        }

        public async Task<DateTime?> GetNextOccuranceAsync(RepeatingTransaction r)
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
