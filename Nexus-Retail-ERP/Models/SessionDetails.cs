using System;
using System.Collections.Generic;
using System.Text;

namespace Nexus_Retail_ERP.Models
{
    public class SessionDetails
    {
        // User session data
        public static int CurrentUserID { get; set; }
        public static string CurrentUserRole { get; set; }
        public static string CurrentUserName { get; set; }
        public static int CurrentBranchID { get; set; }
        public static string CurrentBranchName { get; set; }
    }
}