using Microsoft.AspNetCore.Mvc;

namespace PJATK_APBD_Cw5_s32101.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservationsController : Controller
{
    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Index()
    {
        throw new NotImplementedException();
    }
}