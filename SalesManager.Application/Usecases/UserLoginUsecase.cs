using System;
using SalesManager.Application.DTOs;
using SalesManager.Application.Interfaces;
using SalesManager.Domain.Schemas;
using SalesManager.Infra.Data.Interfaces;

namespace SalesManager.Application.Usecases
{
    public class UserLoginUsecase : GenericUsecase<UserLoginDTO, UserLoginResponse>
    {
        private readonly IUserRepository _repository;

        public UserLoginUsecase(IUserRepository repository) => _repository = repository;

        protected override async Task<UserLoginResponse> ApplyInteralLogic(UserLoginDTO input)
        {
            var user = await _repository.Login(input.Username, input.Password);

            if (user == null)
            {
                return new UserLoginResponse
                {
                    Message = "No user found",
                    StatusCode = 404,
                    User = null
                };
            }

            return new UserLoginResponse
            {
                Message = "User found",
                StatusCode = 200,
                User = new Domain.Entities.User(
                    user.Id,
                    user.Name,
                    user.UserName,
                    user.Email,
                    "",
                    user.IsActive,
                    user.CreatedAt,
                    user.UpdatedAt
                    )
            };
        }
    }
}

