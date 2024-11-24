namespace ProyectoMedidor.Models
{
    public class LogData
    {
        public long DateTS { get; set; }  // Timestamp
        public int Origin { get; set; }
        public int ResultAction { get; set; }
        public LogDataDetails Data { get; set; }
    }
}
