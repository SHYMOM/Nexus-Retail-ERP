using System;
using System.Collections.Generic;
using System.Text;

namespace Nexus_Retail_ERP.Models
{
    public class Variant
    {
        public int VariantID { get; set; }
        public string VariantName { get; set; }
        public string UOM { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SalesPrice { get; set; }
        public string SKU { get; set; }
        public string VariantImagePath { get; set; }
        public int ProductID { get; set; }
        public int TotalStock { get; set; }
    }
}
