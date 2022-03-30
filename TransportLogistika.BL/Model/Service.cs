using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TransportLogistika.BL
{
    public class Service
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Category { get; set; } = "";
        public string PhoneNumber_1 { get; set; } = "";
        public string? PhoneNumber_2 { get; set; }
        public string? Website { get; set; }
        public string WhichRegion { get; set; } = "";
        public string HourPay { get; set; } = "";

        public List<Truck> Trucks { get; set; } = new();

    }
}
