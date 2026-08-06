using SmartInventory.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Dtos
{
    public class UserDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
        public DateTime EnteredDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public UserActiveStatus ActiveStatus { get; set; }
        public DateTime? LastLogin { get; set; } = null;
        public DateTime? LastPasswordChange { get; set; } = null;
        public int FailedLoginAttempts { get; set; } = 0;
    }
}
