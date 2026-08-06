using MediatR;
using SmartInventory.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.User.Commands.UserRegister
{
    public class UserRegisterCommand : IRequest<UserDto>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public DateTime StartDate { get; set; }
    }
}
