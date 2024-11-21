using Microsoft.Extensions.Logging.Abstractions;

namespace ProyectoMedidor.Models
{
    public class FlowData
    {
        public List<LogEntry> Logs { get; set; }
        public List<DataPoint> Data { get; set; }
    }
}
