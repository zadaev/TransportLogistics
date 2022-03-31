using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLogistika.BL
{
    [Serializable]
    public class User
    {
        public uint Id { get; set; } 
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public string? Data { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;

        public List<User> Users { get; set; } = new();
        public List<Service> Services { get; set; } = new();
        public List<Customer> Customers { get; set; } = new();
    }
}
