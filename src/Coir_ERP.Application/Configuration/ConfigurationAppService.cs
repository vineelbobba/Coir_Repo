using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using Coir_ERP.Configuration.Dto;

namespace Coir_ERP.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : Coir_ERPAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
