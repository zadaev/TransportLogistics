using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TransportLogistika.BL
{
    public class WWTL
    {
        public static void CreateUser()
        {
            using (TLContext context = new TLContext())
            {
                
                User tom = new User() { Login = "ozi", Password = "12345" };
                context.Add(tom);
                context.SaveChanges();
            }
        }
    }
}
