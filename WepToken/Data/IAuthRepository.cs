using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WepToken.Models;
using WepToken.Services;

namespace WepToken.Data
{
    public interface IAuthRepository
    {

        Task<ServiceResponse<int>> Register(User user, string password);
        Task<ServiceResponse<string>> Login(string userName, string password);

        Task<bool> UserExists(string userName);
    }
}
