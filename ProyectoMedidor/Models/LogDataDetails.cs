namespace ProyectoMedidor.Models
{
    public class LogDataDetails
    {
        public double Value { get; set; }
        public long DateTS { get; set; }  // Timestamp
        public int UnitTypeId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public int UnitTypeGroupId { get; set; }
    }
}
