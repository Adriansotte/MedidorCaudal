using System.Text.Json.Serialization;

namespace ProyectoMedidor.Models.Auth
{
    public class RefreshToken
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("expiration")]
        public DateTime Expiration { get; set; }
    }
}
