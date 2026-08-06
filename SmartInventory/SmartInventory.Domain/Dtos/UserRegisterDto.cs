using SmartInventory.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Dtos
{
    public class UserRegisterDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime StartDate { get; set; }
        public UserActiveStatus ActiveStatus { get; set; }
    }
}
