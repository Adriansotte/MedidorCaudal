using ProyectoMedidor.Models.Auth;
using System.Text.Json.Serialization;

namespace ProyectoMedidor.Models
{
    public class TokenResponse
    {
        [JsonPropertyName("accessToken")]
        public AccessToken AccessToken { get; set; }

        [JsonPropertyName("refreshToken")]
        public RefreshToken RefreshToken { get; set; }
    }
}
