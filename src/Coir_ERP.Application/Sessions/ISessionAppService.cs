using System.Threading.Tasks;
using Abp.Application.Services;
using Coir_ERP.Sessions.Dto;

namespace Coir_ERP.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
