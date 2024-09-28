using System;
using SalesManager.Domain.Entities;

namespace SalesManager.Infra.Data.Interfaces
{
	public interface IUserRepository
	{
        Task<User> Login(string userName, string password);
    }
}

