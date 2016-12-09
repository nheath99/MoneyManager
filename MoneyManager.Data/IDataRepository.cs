using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Data
{
    public interface IDataRepository
    {
        Task<IEnumerable<Account>> GetAccountsAsync();
        Task<Account> GetAccountAsync(int id);
        Task<IEnumerable<Account>> GetAccountsByAccountTypeAsync(int accountTypeId);

        Task<int> InsertAccountAsync(Account account);
        Task<bool> UpdateAccountAsync(Account account);
        Task DeleteAccountAsync(int id);

        Task<IEnumerable<Transaction>> GetTransactionsAsync(int accountId);
        Task<int> InsertTransactionAsync(Transaction t);
        Task<bool> UpdateTransactionAsync(Transaction t);
        Task DeleteTransactionAsync(int id);
        Task<decimal> GetAccountBalance(int accountId);
        Task<decimal> GetAccountBalanceUnreconciledAsync(int accountId);
        Task<IEnumerable<Transaction>> GetRelatedTransactionsAsync(int repeatingTransactionId);

        Task<IEnumerable<Pension>> GetPensionsAsync();
        Task<decimal> CurrentPensionValueAsync(int pensionId);
        Task<IEnumerable<Stock>> GetStocksAsync();
        Task<IEnumerable<RepeatingTransaction>> GetRepeatingTransactionsAsync(bool onlyActive);

        Task ProcessRepeatingTransactionAsync(int repeatingTransactionId);
        Task<int> InsertRepeatingTransactionAsync(RepeatingTransaction r);
        Task<bool> UpdateRepeatingTransactionAsync(RepeatingTransaction r);
        Task DeleteRepeatingTransactionAsync(int id);        
        Task ProcessAllRepeatingTransactionsAsync(bool nextPrompt);

        Task<DateTime?> GetNextOccuranceAsync(RepeatingTransaction r);

        Task<IEnumerable<Asset>> GetAssetsAsync();
        Task<int> InsertAssetAsync(Asset a);
        Task<bool> UpdateAssetAsync(Asset a);
        Task DeleteAssetAsync(int id);

        Task<int> InsertPensionAsync(Pension p);
        Task<bool> UpdatePensionAsync(Pension p);
        Task DeletePension(int id);
        Task<IEnumerable<PensionValuation>> GetPensionValuations(int id, DateTime startDateTime, DateTime endDateTime);
    }
}
