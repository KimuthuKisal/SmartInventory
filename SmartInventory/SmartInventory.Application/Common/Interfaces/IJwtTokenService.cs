using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Common.Interfaces
{
    public interface IJwtTokenService
    {
        public string GenerateToken(
            Guid userId,
            string email,
            string role
        );
    }
}
