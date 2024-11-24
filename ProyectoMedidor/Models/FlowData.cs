using Microsoft.Extensions.Logging.Abstractions;

namespace ProyectoMedidor.Models
{
    public class FlowData
    {
        public DateTime Time { get; set; }
        public double Value { get; set; }
    }
}
