using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Domain.DTOs.Identity
{
    public class ParamasSignUpRequest
    {
        public string Username { get; set; } = null!;

        public string Password { get; set; } = null!;

        public Guid RoleGroupId { get; set; }
    }
}
