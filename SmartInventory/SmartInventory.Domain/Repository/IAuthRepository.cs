using SmartInventory.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Repository
{
    public interface IAuthRepository
    {
        Task<UserDto> RegisterUser(UserRegisterDto registerUser);
    }
}
