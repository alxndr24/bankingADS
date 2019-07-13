using System;

namespace Banking.Application.Transactions.Dtos
{
    public class NewTransferDto
    {
        public string FromAccountNumber { get; set; }
        public string ToAccountNumber { get; set; }
        public decimal Amount { get; set; }

        public NewTransferDto()
        {
        }
    }
}
