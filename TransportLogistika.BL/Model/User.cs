using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportLogistika.BL
{
    public class User
    {
        public Guid Id { get; set; } = new Guid();
        public string Login { get; set; } = "";
        public string Password { get; set; } = "";
        public string? Data { get; set; }
        public bool Status { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
      
        public Service? Services { get; set; }
        public Driver? Driver { get; set; }
        public Customer? Customer { get; set; }

    }
}
