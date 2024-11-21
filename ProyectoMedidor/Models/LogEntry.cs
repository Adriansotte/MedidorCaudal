namespace ProyectoMedidor.Models
{
    public class LogEntry
    {
        public long DateTs { get; set; }
        public int Origin { get; set; }
        public int ResultAction { get; set; }
        public double? Value { get; set; }
    }
}
