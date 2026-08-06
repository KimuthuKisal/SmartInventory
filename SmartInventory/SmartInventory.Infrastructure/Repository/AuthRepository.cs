using AutoMapper;
using SmartInventory.Domain.Dtos;
using SmartInventory.Domain.Entity;
using SmartInventory.Domain.Repository;
using SmartInventory.Infrastructure.Data;
using BCrypt.Net;

namespace SmartInventory.Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly SmartInventoryDbContext _context;
        private readonly IMapper _mapper;

        public AuthRepository(SmartInventoryDbContext smartInventoryDbContext)
        {
            _context = smartInventoryDbContext;
        }

        public async Task<UserDto> RegisterUser(UserRegisterDto registerUser)
        {
            try
            {
                User newUser = new User
                {
                    Name = registerUser.Name,
                    Email = registerUser.Email,
                    Address = registerUser.Address,
                    PhoneNumber = registerUser.PhoneNumber,
                    Role = registerUser.Role,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(registerUser.Password),
                    EnteredDate = registerUser.EnteredDate,
                    StartDate = registerUser.StartDate,
                    ActiveStatus = registerUser.ActiveStatus
                };

                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();
                UserDto userView = _mapper.Map<UserDto>(newUser);
                return userView;
            }
            catch
            {
                throw;
            }
        }
    }
}
