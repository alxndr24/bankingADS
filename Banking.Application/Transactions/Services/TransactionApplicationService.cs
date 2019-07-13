using Banking.Application.Transactions.Constants;
using Banking.Application.Transactions.Contracts;
using Banking.Application.Transactions.Dtos;
using Banking.Domain.Accounts.Contracts;
using Banking.Domain.Accounts.Entities;
using Banking.Domain.Movements.Contracts;
using Banking.Domain.Movements.Entities;
using Banking.Domain.Transactions.Contracts;
using Microsoft.AspNetCore.Http;
using Common;
using System;

namespace Banking.Application.Transactions.Services
{
    public class TransactionApplicationService : ITransactionApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccountRepository _accountRepository;
        private readonly IMovementRepository _movementRepository;
        private readonly ITransferDomainService _transferDomainService;

        public TransactionApplicationService(
            IUnitOfWork unitOfWork,
            IAccountRepository accountRepository,
            IMovementRepository movementsRepository,
            ITransferDomainService transferDomainService
            )
        {
            _unitOfWork = unitOfWork;
            _accountRepository = accountRepository;
            _transferDomainService = transferDomainService;
           _movementRepository = movementsRepository;
        }

        public NewTransferResponseDto PerformTransfer(NewTransferDto newTransferDto)
        {
            bool uowStatus = false;
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                Account originAccount = _accountRepository.GetByNumberWithUpgradeLock(newTransferDto.FromAccountNumber);
                Account destinationAccount = _accountRepository.GetByNumberWithUpgradeLock(newTransferDto.ToAccountNumber);
                _transferDomainService.PerformTransfer(originAccount, destinationAccount, newTransferDto.Amount);

                Movement originMovement = new Movement();
                originMovement.Balance = newTransferDto.Amount;
                originMovement.Account_id = _accountRepository.GetByNumber(newTransferDto.FromAccountNumber);
                originMovement.Account_destino_id = _accountRepository.GetByNumber(newTransferDto.FromAccountNumber);
                originMovement.Movement_type_id = 4;
                originMovement.CreatedAt = DateTime.UtcNow;


                Movement destinationMovement = new Movement();
                destinationMovement.Balance = newTransferDto.Amount;
                destinationMovement.Account_id = _accountRepository.GetByNumber(newTransferDto.ToAccountNumber);
                destinationMovement.Account_destino_id = _accountRepository.GetByNumber(newTransferDto.ToAccountNumber);
                destinationMovement.Movement_type_id = 3;
                destinationMovement.CreatedAt = DateTime.UtcNow;

                _movementRepository.SaveOrUpdate(originMovement);
                _movementRepository.SaveOrUpdate(destinationMovement);
                _accountRepository.SaveOrUpdate(originAccount);
                _accountRepository.SaveOrUpdate(destinationAccount);
                _unitOfWork.Commit(uowStatus);
                return new NewTransferResponseDto
                {
                    HttpStatusCode = StatusCodes.Status201Created,
                    StringResponse = new ApiStringResponse(TransactionAppConstants.TransferPerformed)
                };
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return new NewTransferResponseDto
                {
                    HttpStatusCode = StatusCodes.Status500InternalServerError,
                    StringResponse = new ApiStringResponse(ApiConstants.InternalServerError)
                };
            }
        }
        public NewTransferResponseDto PerformDeposit(NewDepositDto NewDepositDto)
        {
            bool uowStatus = false;
            int type_movement = 2;
            if (NewDepositDto.Movement == "1") type_movement = 1;
            
            try
            {
                uowStatus = _unitOfWork.BeginTransaction();
                Account originAccount = _accountRepository.GetByNumberWithUpgradeLock(NewDepositDto.AccountNumber);
                _transferDomainService.PerformDeposit(originAccount, NewDepositDto.Amount,NewDepositDto.Movement);
                Movement movement = new Movement();
                movement.Balance = NewDepositDto.Amount;
                movement.Account_id = _accountRepository.GetByNumber(NewDepositDto.AccountNumber);
                movement.Account_destino_id = _accountRepository.GetByNumber(NewDepositDto.AccountNumber);
                movement.Movement_type_id = type_movement;
                movement.CreatedAt = DateTime.UtcNow;

                _movementRepository.SaveOrUpdate(movement);
                _accountRepository.SaveOrUpdate(originAccount);
                _unitOfWork.Commit(uowStatus);
                return new NewTransferResponseDto
                {
                    HttpStatusCode = StatusCodes.Status201Created,
                    StringResponse = new ApiStringResponse(TransactionAppConstants.DepositPerfomed)
                };
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback(uowStatus);
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return new NewTransferResponseDto
                {
                    HttpStatusCode = StatusCodes.Status500InternalServerError,
                    StringResponse = new ApiStringResponse(ApiConstants.InternalServerError)
                };
            }
        }
    }
}
