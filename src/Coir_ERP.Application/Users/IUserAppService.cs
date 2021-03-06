using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Coir_ERP.Roles.Dto;
using Coir_ERP.Users.Dto;

namespace Coir_ERP.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedResultRequestDto, CreateUserDto, UpdateUserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();
    }
}