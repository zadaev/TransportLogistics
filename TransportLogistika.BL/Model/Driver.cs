
namespace TransportLogistika.BL
{
    public class Driver
    {
        public uint Id { get; set; }
        public string FistName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string PhoneNumber_1 { get; set; } = "";
        public string? PhoneNumber_2 { get; set; }
        public string Email { get; set; } = "";
        public string Category { get; set; } = "";
        public string Country { get; set; } = "";
        public string Region { get; set; } = "";
        public string Address { get; set; } = "";

        public List<Truck> Truck { get; set; } = new();

    }
}
