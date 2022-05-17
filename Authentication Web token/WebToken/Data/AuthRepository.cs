using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebToken.Model;
using WebToken.Services;

namespace WebToken.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(AppDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<ServiceResponse<string>> Login(string userName, string password)
        {
            ServiceResponse<string> response = new();

            //Get the user
            User user = await _context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower().Equals(userName.ToLower()));

            if(user == null)
            {
                response.Success = false;
                response.Message = "User Not Found";
            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success = false;
                response.Message = "Incorrect Password";
            }
            else
            {
                response.Data = CreateToken(user); //Create token if user creadentials are correct
            }
            return response;    
        }

        public async Task<ServiceResponse<int>> Register(User user, string password)
        {
            ServiceResponse<int> response = new();

            //Check if the user alredy exixst
            if (await UserExists(user.UserName))
            {
                response.Success = false;
                response.Message = "User already exists";
                return response;
            }

            //Create hash password and salt
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
            //Create the password hash and salt
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        //Verify password hash

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                //Create hash for entered password
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                //Compare it with the saved one
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if(computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        //Create Token
        private string CreateToken(User user)
        {
            // add the claims
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
            };

            //Get the security key
            SymmetricSecurityKey key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetting:Token").Value)
                );

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            //Object to get info used to create token
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
