using System;
using System.Collections.Generic;
using System.Text;

namespace Nexus_Retail_ERP.Data
{
    public static class ValidationHelper
    {
        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone)) return false;
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^01\d{9}$");
        }
    }
}
