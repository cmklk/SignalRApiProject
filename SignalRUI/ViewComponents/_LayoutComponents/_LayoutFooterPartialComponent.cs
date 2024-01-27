using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.ViewComponents._LayoutComponents
{
	public class _LayoutFooterPartialComponent:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
