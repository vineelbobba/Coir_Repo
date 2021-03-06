using System.Threading.Tasks;
using Abp.Application.Services;
using Coir_ERP.Authorization.Accounts.Dto;

namespace Coir_ERP.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
