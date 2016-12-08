using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Data
{
    public interface IDataRepository
    {
        IEnumerable<Account> GetAccounts();
        IEnumerable<Account> GetAccount(int id);
        IEnumerable<Account> GetAccountsByAccountType(int accountTypeId);

        void InsertAccount(Account account);
        void UpdateAccount(Account account);

        IEnumerable<Transaction> GetTransactions(int accountId);
        decimal GetAccountBalance(int accountId);
        decimal GetAccountBalanceUnreconciled(int accountId);

        IEnumerable<Pension> GetPensions();
        decimal CurrentPensionValue(int pensionId);
        IEnumerable<Stock> GetStocks();
        IEnumerable<RepeatingTransaction> GetRepeatingTransactions(bool onlyActive);
        IEnumerable<Asset> GetAssets();

        void ProcessRepeatingTransaction(int repeatingTransactionId);
        void InsertRepeatingTransaction(RepeatingTransaction r);
        void DeleteRepeatingTransaction(int id);
        void UpdateRepeatingTransaction(RepeatingTransaction r);
        void ProcessAllRepeatingTransactions(bool nextPrompt);

        DateTime? GetNextOccurance(RepeatingTransaction r);
    }
}
