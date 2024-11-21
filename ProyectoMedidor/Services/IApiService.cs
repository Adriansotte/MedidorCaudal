namespace ProyectoMedidor.Services
{
    public interface IApiService
    {
        Task<string> GetToken(string username, string password);
        Task<object> GetCounterData(string token, int type, long startTime, long endTime);
    }
}
