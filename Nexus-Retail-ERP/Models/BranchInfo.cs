using System;
using System.Collections.Generic;
using System.Text;

namespace Nexus_Retail_ERP.Models
{
    public class BranchInfo
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string Location { get; set; }
        public string Phone { get; set; }
        public bool IsActive { get; set; }

        public override string ToString()
        {
            return $"{BranchName} - {Location}";
        }
    }
}
