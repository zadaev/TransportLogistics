using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TransportLogistika.BL
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string PhoneNumber_1 { get; set; } = "";
        public string? PhoneNumber_2 { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public string Country { get; set; } = "";
        public string Region { get; set; } = "";
        public string Addrress { get; set; } = "";

    }
}
