using System;
using System.Windows.Forms;
using Nexus_Retail_ERP;
using Nexus_Retail_ERP.Forms;

namespace Nexus_Retail_ERP
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreen());
        }
    }
}
