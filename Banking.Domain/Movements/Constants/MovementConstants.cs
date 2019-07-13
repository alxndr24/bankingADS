namespace Banking.Domain.Movements.Constants
{
    public static class MovementConstants
    {
        public const string AmountMustBeGreaterThanZero = "The amount must be greater than zero";
        public const string AccountHasNoIdentity = "The account has no identity";
        public const string AccountIsLocked = "The account is locked";
        public const string CannotWithdrawAmountIsGreaterThanBalance = "Cannot withdraw in the account, amount is greater than Balance";
    }
}
