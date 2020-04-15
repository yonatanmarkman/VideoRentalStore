using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace Vidly.Controllers
{
	[AllowAnonymous]
	public class HomeController : Controller
	{
        // OutputCache is for caching the rendered HTML, not the data.
        // The duration parameter is in seconds. If duration > 0,
        // the first visit will save the page to the cache,
        // then the next visits will see the cached version.
        // VaryByParam - specifies parameters, s.t. for each parameter value
        // there will be a different version in the cache.
        // * - for every parameter combination, there will be a different version.
        [OutputCache(Duration = 0, VaryByParam = "*", NoStore = true)]
		public ActionResult Index()
		{
           
			return View();
		}

		public ActionResult About()
		{
            throw new Exception();

			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}