using Banking.Application.Users.Assemblers;
using Banking.Application.Users.Constants;
using Banking.Application.Users.Contracts;
using Banking.Application.Users.Dtos;
using Banking.Domain.Auth.Contracts;
using Banking.Domain.Auth.Entities;
using Banking.Infrastructure.Auth.Hashing;
using Microsoft.AspNetCore.Http;
using Common;
using System;
using Banking.Domain.Customers.Entities;
using Banking.Domain.Customers.Contracts;

namespace Banking.Application.Users.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly NewUserAssembler _newUserAssembler;
        private readonly ICustomerRepository _newCustomerRepository;
        private readonly Hasher _hasher;

        public UserApplicationService(
            IUnitOfWork unitOfWork,
            IUserRepository userRepository,
            ICustomerRepository customerRepository,
            NewUserAssembler newUserAssembler,
            Hasher hasher)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _newUserAssembler = newUserAssembler;
            _newCustomerRepository = customerRepository;
            _hasher = hasher;
        }

        public NewUserResponseDto Register(NewUserDto newUserDto)
        {
            try
            {
                string hashedPassword = _hasher.HashPassword(newUserDto.Password);
                newUserDto.Password = hashedPassword;
                User user = _newUserAssembler.ToEntity(newUserDto);
                _userRepository.SaveOrUpdate(user);
                Customer customer = new Customer();
                customer.FirstName = newUserDto.FirstName;
                customer.LastName = newUserDto.LastName;
                customer.CreatedAt = DateTime.UtcNow;
                customer.IdentityDocument = newUserDto.Document;
                customer.User = user.Id;
                customer.Active = true;

                _newCustomerRepository.SaveOrUpdate(customer);

                return new NewUserResponseDto
                {
                    HttpStatusCode = StatusCodes.Status201Created,
                    Response = new ApiStringResponse(UserAppConstants.UserCreated)
                };
            }
            catch (Exception ex)
            {
                //TODO: Log exception async, for now write exception in the console
                Console.WriteLine(ex.Message);
                return new NewUserResponseDto
                {
                    HttpStatusCode = StatusCodes.Status500InternalServerError,
                    Response = new ApiStringResponse(ApiConstants.InternalServerError)
                };
            }
        }
    }
}
