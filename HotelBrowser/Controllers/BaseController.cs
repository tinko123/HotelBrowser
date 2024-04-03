using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelBrowser.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {

    }
}
