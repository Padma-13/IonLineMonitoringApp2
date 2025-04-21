namespace IonLineMonitoringApp.Models
{
    public class ShiftData
    {
        public int ShiftDataId { get; set; }

        public int LineId { get; set; }
        public Line Line { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public string Shift { get; set; } // A, B, C
        public DateTime Date { get; set; }
        public double LineSpeed { get; set; }
        public int TotalProduction { get; set; }
        public double TotalEnergy { get; set; } // ✅ Renamed here
    }
}
