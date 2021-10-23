using CoreWebAppMVC.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAppMVC.Models
{
    public class OrderView
    {
        public string CompanyName { get; set; }
        public int OrderId { get; set; }
        public string OrderDescription { get; set; }

        public decimal OrderTotal { get; set; }

        public ICollection<Orderproduct> OrderProducts { get; set; }
    }
}
