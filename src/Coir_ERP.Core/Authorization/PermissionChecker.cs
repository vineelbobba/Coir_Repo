using Abp.Authorization;
using Coir_ERP.Authorization.Roles;
using Coir_ERP.Authorization.Users;

namespace Coir_ERP.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}
