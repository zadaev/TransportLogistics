
namespace TransportLogistika.BL
{
    public class Truck
    {
        public uint Id { get; set; }
        public string CarModel { get; set; } = "";
        public string CarNumber { get; set; } = "";
        public string MType { get; set; } = "";
        public string Category { get; set; } = "";
        public double GrossWeigh { get; set; }
        public DateTime Year { get; set; }
        public string CurrentRegion { get; set; } = "";
        public string Address { get; set; } = "";

    }
}
