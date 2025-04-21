namespace IonLineMonitoringApp.Models
{
    public class LineProduct
    {
        public int LineProductId { get; set; }
        public int LineId { get; set; }
        public Line Line { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
