using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleEFCore
{
    public sealed class SupplyHistory
    {
        public int SupplyHistoryId { get; set; }
        
        public int ProductId { get; set; } // FK Table Product


        public Product Product { get; set; } // Ref Table Product
    
        public int CompanyId { get; set; }
        
        public Company Company { get; set; }
     
        public DateTime ShipmentDate { get; set; }
     
        public double Price { get; set; }
    }
}
