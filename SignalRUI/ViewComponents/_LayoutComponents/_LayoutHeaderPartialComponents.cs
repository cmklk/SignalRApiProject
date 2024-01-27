using Microsoft.AspNetCore.Mvc;

namespace SignalRUI.ViewComponents._LayoutComponents
{
    public class _LayoutHeaderPartialComponents:ViewComponent
    {
        public IViewComponentResult Invoke() {
            return View();
        }
    }
}
