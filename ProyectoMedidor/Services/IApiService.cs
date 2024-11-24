using ProyectoMedidor.Models;

namespace ProyectoMedidor.Services
{
    public interface IApiService
    {
        Task<string> GetToken(string username, string password);
        Task<CounterDataResponse> GetCounterData(string token, int type, long startTime, long endTime);
    }
}
