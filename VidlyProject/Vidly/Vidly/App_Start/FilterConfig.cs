using System.Web;
using System.Web.Mvc;

namespace Vidly
{
	public class FilterConfig
	{
		public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        { 
            /*
            This filter is applied to all controllers and to all actions.
            Action filters can be executed before and/or after an Action,
            This filter is executed after an action, and if there is an
            unhandleded exception in that action, the filter will catch it,
            and then render the error custom view.
            This is how error pages are displayed when there is an exception
            in the application.
            */
            filters.Add(new HandleErrorAttribute());

			filters.Add(new AuthorizeAttribute());
			filters.Add(new RequireHttpsAttribute());
		}
	}
}
