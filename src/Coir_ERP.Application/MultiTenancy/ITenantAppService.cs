using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Coir_ERP.MultiTenancy.Dto;

namespace Coir_ERP.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
