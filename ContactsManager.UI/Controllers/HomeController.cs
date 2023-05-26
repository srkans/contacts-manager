using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CRUDExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {//IExceptionHandlerPathFeature ile meydana gelen herhangi bir exception a ulaşılabilir. tanımlamasak bile her yerden erişilebilir.
            IExceptionHandlerPathFeature? exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            return View();//Views/Home/Error
        }
    }
}
