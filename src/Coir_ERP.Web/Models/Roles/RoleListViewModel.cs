using System.Collections.Generic;
using Coir_ERP.Roles.Dto;

namespace Coir_ERP.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }

        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}