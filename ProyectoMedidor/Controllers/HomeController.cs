using Microsoft.AspNetCore.Mvc;
using ProyectoMedidor.Services;

namespace ProyectoMedidor.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;

        public HomeController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetToken()
        {
            // Obtiene el token
            var token = await _apiService.GetToken("federico.front.test@spherag.com", "d1KKaI6*1LCTF(=]£y?u");

            if (string.IsNullOrEmpty(token))
            {
                return Content("Error obteniendo el token.");
            }

            return Content($"Token obtenido: {token}");
        }

        public async Task<IActionResult> GetCounterData(int type, long startTime, long endTime)
        {
            var token = await _apiService.GetToken("federico.front.test@spherag.com", "d1KKaI6*1LCTF(=]£y?u");

            if (string.IsNullOrEmpty(token))
            {
                return Content("Error obteniendo el token.");
            }

            var counterData = await _apiService.GetCounterData(token, type, startTime, endTime);

            if (counterData == null)
            {
                return Content("Error obteniendo los datos del contador.");
            }

            return Json(counterData);
        }
    }
}
