using System;
using System.Collections.Generic;
using System.Text;

namespace Nexus_Retail_ERP.Models
{
    public class AuthResult
    {
        public bool IsAuthenticated { get; set; }
        public int UserID { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public int BranchID { get; set; }
        public string BranchName { get; set; }
    }
}
