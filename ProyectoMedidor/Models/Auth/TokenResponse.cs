using System.Text.Json.Serialization;

namespace ProyectoMedidor.Models.Auth
{
    public class TokenResponse
    {
        [JsonPropertyName("accessToken")]
        public AccessToken AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public RefreshToken RefreshToken { get; set; }
    }
}
