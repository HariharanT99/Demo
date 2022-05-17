using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepToken.Models;
using WepToken.Services;

namespace WepToken.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;

        public AuthRepository(AppDbContext context)
        {
            _context = context;
        }
        public Task<ServiceResponse<string>> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> response = new();

            if(await UserExists(user.UserName))
            {
                response.Success = false;
                response.Message = "User already exists";
                return response;
            }

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            response.Data = user.Id;

            return response;
        }

        public async Task<bool> UserExists(string userName)
        {
            if(await _context.Users.AnyAsync(x => x.UserName.ToLower() == userName.ToLower()))
            {
                return true;
            }
            return false;
        }


        //Create Password Hash

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
