namespace IonLineMonitoringApp.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public List<LineProduct> LineProducts { get; set; }
        public List<ShiftData> ShiftDatas { get; set; }
    }
}
