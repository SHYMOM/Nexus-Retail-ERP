using System;
using System.Collections.Generic;
using System.Text;

namespace Nexus_Retail_ERP.Models
{
    public class AuditLog
    {
        public int LogID { get; set; }
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
        public string TableName { get; set; }
        public int? RecordID { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime LogDate { get; set; }
    }
}
