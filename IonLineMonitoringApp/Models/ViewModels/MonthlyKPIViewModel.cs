namespace IonLineMonitoringApp.Models.ViewModels
{
    public class MonthlyKPIViewModel
    {
        public string LineName { get; set; }
        public string ProductName { get; set; }
        public int TotalProduction { get; set; }
        public double TotalEnergy { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
    }
}
