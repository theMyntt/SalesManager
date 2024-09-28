using System;
using Microsoft.EntityFrameworkCore;
using SalesManager.Domain.Entities;
using SalesManager.Infra.Data.Context;
using SalesManager.Infra.Data.Interfaces;

namespace SalesManager.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context) => _context = context;

        public async Task<User> Login(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password) ?? throw new InvalidDataException("No User Found");

            return user;
        }
    }
}

