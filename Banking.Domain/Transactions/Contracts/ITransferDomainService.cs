using Banking.Domain.Accounts.Entities;

namespace Banking.Domain.Transactions.Contracts
{
    public interface ITransferDomainService
    {
        void PerformTransfer(Account originAccount, Account destinationAccount, decimal amount);
        void PerformDeposit(Account originAccount,  decimal amount, string Movement);
        
    }
}
