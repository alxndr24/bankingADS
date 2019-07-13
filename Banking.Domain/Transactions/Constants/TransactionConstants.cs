namespace Banking.Domain.Transactions.Constants
{
    public static class TransactionConstants
    {
        public const string AmountMustBeGreaterThanZero = "The amount must be greater than zero";
        public const string OriginAccountInvalid = "Invalid origin account";
        public const string DestinationAccountInvalid = "Invalid destination account";
        public const string CannotTransferSameAccounts = "Cannot transfer money to the same account";
    }
}
