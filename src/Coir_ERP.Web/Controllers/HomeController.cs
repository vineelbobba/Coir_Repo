using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace Coir_ERP.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : Coir_ERPControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}