using ProyectoMedidor.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProyectoMedidor.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        // Inyección de dependencias mediante constructor
        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetToken(string username, string password)
        {
            try
            {
                // Realiza la solicitud POST
                var response = await _httpClient.PostAsJsonAsync("https://api.spherag.com/Authentication/Login", new
                {
                    username,
                    password
                });

                if (response.IsSuccessStatusCode)
                {
                    // Deserializa la respuesta completa
                    var result = await response.Content.ReadFromJsonAsync<TokenResponse>();

                    // Verifica si obtuviste un token de acceso
                    if (result?.AccessToken?.Token != null)
                    {
                        return result.AccessToken.Token;
                    }
                    else
                    {
                        Console.WriteLine("No se obtuvo el token de acceso.");
                        return string.Empty;
                    }
                }

                // Log de error en caso de respuesta no exitosa
                var errorContent = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Error en GetToken: {response.StatusCode}, Detalles: {errorContent}");
                return string.Empty;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                Console.WriteLine($"Excepción en GetToken: {ex.Message}");
                return string.Empty;
            }
        }

        public async Task<CounterDataResponse> GetCounterData(string token, int type, long startTime, long endTime)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            // Construcción de la URL con los parámetros especificados
            string url = $"https://apicore.spherag.com/AtlasElement/Monitoring/92/{type}/{startTime}/{endTime}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var responseData = await response.Content.ReadFromJsonAsync<CounterDataResponse>();

                // Aquí podrías procesar la respuesta para extraer los datos que necesitas
                return responseData;
            }

            return null;
        }
    }
}
