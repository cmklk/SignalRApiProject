using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.ViewComponents._LayoutComponents
{
	public class _LayoutNavbarPartialComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
