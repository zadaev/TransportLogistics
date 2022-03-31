using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
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

        public uint UserId { get; set; }
        public User? User { get; set; }

        public override string ToString()
        {
            return $"Имя - {FistName}" +
                $" \nФамилия - {LastName}" +
                $" \nНомер Телефона - {PhoneNumber_1}" +
                $" \nEmail - {Email}" +
                $" \nКатегория - {Category}" +
                $" \nСтрана - {Address}";
        }

    }
}
