using AutoMapper;
using MediatR;
using SmartInventory.Domain.Dtos;
using SmartInventory.Domain.Enums;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.User.Commands.UserRegister
{
    public class UserRegisterCommandHandler : IRequestHandler<UserRegisterCommand, UserDto>
    {
        private readonly IAuthRepository _authRepository;
        private readonly IMapper _mapper;
        public async Task<UserDto> Handle(UserRegisterCommand request, CancellationToken cancellationToken)
        {
            UserRegisterDto newUser = new UserRegisterDto
            {
                Name = request.Name,
                Email = request.Email,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                Role = request.Role,
                Password = request.Password,
                EnteredDate = DateTime.UtcNow,
                StartDate = request.StartDate,
                ActiveStatus = UserActiveStatus.Active
            };

            return await _authRepository.RegisterUser(newUser);
        }
    }
}
