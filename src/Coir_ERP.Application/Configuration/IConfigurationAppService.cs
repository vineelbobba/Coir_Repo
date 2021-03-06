using System.Threading.Tasks;
using Abp.Application.Services;
using Coir_ERP.Configuration.Dto;

namespace Coir_ERP.Configuration
{
    public interface IConfigurationAppService: IApplicationService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}