using System.Collections.Generic;
using Coir_ERP.Roles.Dto;
using Coir_ERP.Users.Dto;

namespace Coir_ERP.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<UserDto> Users { get; set; }

        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}