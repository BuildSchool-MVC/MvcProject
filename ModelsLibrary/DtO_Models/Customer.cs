using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CusromerName { get; set; }
        public DateTime Birthday { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public decimal ShoppingCash { get; set; }

    }
}
