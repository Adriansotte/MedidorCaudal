using Microsoft.AspNetCore.Mvc;
using ProyectoMedidor.Models;
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

        public async Task<IActionResult> Index()
        {
            // Parámetros de ejemplo, puedes hacer que estos valores se configuren dinámicamente
            int type = 1; // Ejemplo: 1 para Caudal, 2 para Acumulado
            long startTime = 1630805467000; // Ejemplo: Timestamp de inicio
            long endTime = 1730805467000;   // Ejemplo: Timestamp de fin

            // Obtén el token
            var token = await _apiService.GetToken("federico.front.test@spherag.com", "d1KKaI6*1LCTF(=]£y?u");

            if (string.IsNullOrEmpty(token))
            {
                return Content("Error obteniendo el token.");
            }

            // Obtén los datos del contador
            var counterData = await _apiService.GetCounterData(token, type, startTime, endTime);

            if (counterData == null)
            {
                return Content("Error obteniendo los datos del contador.");
            }

            // Procesa los datos para enviarlos a la vista
            var flowRateData = counterData.FlowRateData.Select(d => new FlowData
            {
                Time = DateTimeOffset.FromUnixTimeMilliseconds(d.DateTS).DateTime,
                Value = d.Data.Value
            }).ToList();

            var accumulatedFlowData = counterData.AccumulatedFlowData.Select(d => new FlowData
            {
                Time = DateTimeOffset.FromUnixTimeMilliseconds(d.DateTS).DateTime,
                Value = d.Data.Value
            }).ToList();

            // Crea el ViewModel con los datos procesados
            var viewModel = new CounterDataViewModel
            {
                FlowRateData = flowRateData,
                AccumulatedFlowData = accumulatedFlowData
            };

            // Devuelve la vista con el ViewModel
            return View(viewModel);
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
            // Obtén el token
            var token = await _apiService.GetToken("federico.front.test@spherag.com", "d1KKaI6*1LCTF(=]£y?u");

            if (string.IsNullOrEmpty(token))
            {
                return Content("Error obteniendo el token.");
            }

            // Obtén los datos del contador
            var counterData = await _apiService.GetCounterData(token, type, startTime, endTime);

            if (counterData == null)
            {
                return Content("Error obteniendo los datos del contador.");
            }

            // Procesa los datos para enviarlos a la vista
            var flowRateData = counterData.FlowRateData.Select(d => new
            {
                Time = DateTimeOffset.FromUnixTimeMilliseconds(d.DateTS).DateTime,
                Value = d.Data.Value
            }).ToList();

            var accumulatedFlowData = counterData.AccumulatedFlowData.Select(d => new
            {
                Time = DateTimeOffset.FromUnixTimeMilliseconds(d.DateTS).DateTime,
                Value = d.Data.Value
            }).ToList();

            // Devolvemos los datos como modelo a la vista
            return View(new { FlowRateData = flowRateData, AccumulatedFlowData = accumulatedFlowData });
        }


    }
}
