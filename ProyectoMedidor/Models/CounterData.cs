namespace ProyectoMedidor.Models
{
    public class CounterData
    {
        public int AtlasElementId { get; set; }
        public double BatteryPercentage { get; set; }
        public double SignalPercentage { get; set; }
        public string LastUpdatedDate { get; set; }
        public string Gmt { get; set; }
        public FlowData AccumulatedFlowData { get; set; }
        public FlowData FlowRateData { get; set; }
    }
}
