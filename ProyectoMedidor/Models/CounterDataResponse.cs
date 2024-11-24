namespace ProyectoMedidor.Models
{
    public class CounterDataResponse
    {
        public int AtlasElementId { get; set; }
        public double? BatteryPercentage { get; set; }
        public int SignalPercentage { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string Gmt { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime AtlasEnd { get; set; }
        public List<LogData> AccumulatedFlowData { get; set; }
        public List<LogData> FlowRateData { get; set; }
    }
}
