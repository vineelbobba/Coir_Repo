using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Coir_ERP.MultiTenancy;

namespace Coir_ERP.Sessions.Dto
{
    [AutoMapFrom(typeof(Tenant))]
    public class TenantLoginInfoDto : EntityDto
    {
        public string TenancyName { get; set; }

        public string Name { get; set; }
    }
}