using Nexus_Retail_ERP.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nexus_Retail_ERP.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ProductImagePath { get; set; }
        public decimal TaxRate { get; set; }
        public bool IsActive { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int VariantCount { get; set; }
        public List<Variant> Variants { get; set; }
    }
}
