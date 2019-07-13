using Banking.Domain.Accounts.Entities;
using Banking.Domain.Movements.Entities;
using Banking.Domain.Transactions.Constants;
using Banking.Domain.Transactions.Contracts;
using Common;

namespace Banking.Domain.Transactions.Services
{
    public class TransferDomainService : Service, ITransferDomainService
    {
        public void PerformTransfer(Account originAccount, Account destinationAccount, decimal amount)
        {
            Notification notification = CanPerformTransfer(originAccount, destinationAccount, amount);
            ThrowExceptionIfAny(notification);
            originAccount.WithdrawMoney(amount);
            destinationAccount.DepositMoney(amount);
        }
        public void PerformDeposit(Account originAccount, decimal amount, string Movement)
        {
            Notification notification = CanPerformDeposit(originAccount);
            ThrowExceptionIfAny(notification);
            if (Movement == "1")
            {
                originAccount.DepositMoney(amount);
            }
            else if(Movement == "2")
            {
                originAccount.WithdrawMoney(amount);
            }            
        }

        public Notification CanPerformTransfer(Account originAccount, Account destinationAccount, decimal amount)
        {
            Notification notification = new Notification();
            if (amount <= 0)
            {
                notification.AddError(TransactionConstants.AmountMustBeGreaterThanZero);
            }
            if (originAccount == null)
            {
                notification.AddError(TransactionConstants.OriginAccountInvalid);
            }
            if (destinationAccount == null)
            {
                notification.AddError(TransactionConstants.DestinationAccountInvalid);
            }
            if (originAccount != null &&
                destinationAccount != null &&
                originAccount.Number.Equals(destinationAccount.Number))
            {
                notification.AddError(TransactionConstants.CannotTransferSameAccounts);
            }
            return notification;
        }
        public Notification CanPerformDeposit(Account originAccount)
        {
            Notification notification = new Notification();
            
            if (originAccount == null)
            {
                notification.AddError(TransactionConstants.OriginAccountInvalid);
            }           
            return notification;
        }
    }
}
