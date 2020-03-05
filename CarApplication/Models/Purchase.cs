using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarApplication.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime Date { get; set; }
    }
}