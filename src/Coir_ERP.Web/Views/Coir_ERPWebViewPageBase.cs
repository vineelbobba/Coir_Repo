using Abp.Web.Mvc.Views;

namespace Coir_ERP.Web.Views
{
    public abstract class Coir_ERPWebViewPageBase : Coir_ERPWebViewPageBase<dynamic>
    {

    }

    public abstract class Coir_ERPWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected Coir_ERPWebViewPageBase()
        {
            LocalizationSourceName = Coir_ERPConsts.LocalizationSourceName;
        }
    }
}