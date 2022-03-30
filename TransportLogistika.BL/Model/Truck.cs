using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLogistika.BL
{
    public class Truck
    {
        public Guid Id { get; set; } = new Guid();
        public string CarModel { get; set; } = "";
        public string CarNumber { get; set; } = "";
        public string MType { get; set; } = "";
        public string Category { get; set; } = "";
        public int GrossWeigh { get; set; }
        public string Year { get; set; } = "";
        public bool Status { get; set; }
        public string CurrentRegion { get; set; } = "";

    }
}
