using System;

namespace Banking.Application.Transactions.Dtos
{
    public class NewDepositDto
    {
        public string AccountNumber { get; set; }
        public decimal Amount { get; set; }
        public string Movement { get; set; }

        public NewDepositDto()
        {
        }
    }
}
