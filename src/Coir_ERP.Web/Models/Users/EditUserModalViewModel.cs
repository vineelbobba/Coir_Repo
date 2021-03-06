using System.Collections.Generic;
using System.Linq;
using Coir_ERP.Roles.Dto;
using Coir_ERP.Users.Dto;

namespace Coir_ERP.Web.Models.Users
{
    public class EditUserModalViewModel
    {
        public UserDto User { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }

        public bool UserIsInRole(RoleDto role)
        {
            return User.Roles != null && User.Roles.Any(r => r == role.Name);
        }
    }
}