using Abp.AutoMapper;
using Coir_ERP.Sessions.Dto;

namespace Coir_ERP.Web.Models.Account
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}