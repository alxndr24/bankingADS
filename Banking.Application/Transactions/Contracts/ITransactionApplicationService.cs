using Banking.Application.Transactions.Dtos;

namespace Banking.Application.Transactions.Contracts
{
    public interface ITransactionApplicationService
    {
        NewTransferResponseDto PerformTransfer(NewTransferDto newTransferDto);
        NewTransferResponseDto PerformDeposit(NewDepositDto newDepositDto);
    }
}
