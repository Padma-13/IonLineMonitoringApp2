namespace IonLineMonitoringApp.Models
{
    public class Line
    {
        public int LineId { get; set; }
        public string LineName { get; set; }
        public List<LineProduct> LineProducts { get; set; }
        public List<ShiftData> ShiftDatas { get; set; }
    }
}
