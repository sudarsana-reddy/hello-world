using HP.LFT.Report;
using HP.LFT.SDK.Web;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace SIFTTest
{
    public class LaunchApp : ActionBase
    {
       
       public LaunchApp(Object data)  : base(data)
        {
            flightModel = new FlightModel();
            Console.WriteLine("LaunchApp : Inisde LaunchApp");
        }

       public override bool Setup()
       {
           Console.WriteLine("LaunchApp : Inisde Setup");
           Reporter.StartReportingContext("Launching Application");
          // Client.GetClient().Reset();
           Process[] processes = Process.GetProcessesByName("FlightsGUI");
           processes.All(process => { process.Kill(); return true; });
           
           var testData = tdParser.GetTestObject("TBSInitial");
           string param1 = tdParser.GetParamValue(testData, "Param1");
           string param2 = tdParser.GetParamValue(testData, "Param2");             
           Console.WriteLine("LaunchApp :  Setup: Param1 - " + param1 );
           Console.WriteLine("LaunchApp :  Setup: Param2 - " + param2);           

           Dictionary<string, string> details = new Dictionary<string, string>();
           details.Add("Param1", param1);
           details.Add("Param2", param2);

           //Client.GetClient().UpdateClient(details);
           return true; 
       }

       public override bool ExecuteAction()
       {
           Console.WriteLine("LaunchApp : Inisde ExecuteAction");
           
           ProcessStartInfo processInfo = new ProcessStartInfo { FileName = @"C:\Learning\WPF Flights Application\FlightsGUI.exe" };
           processInfo.CreateNoWindow = true;
           processInfo.UseShellExecute = false;
           Process process = Process.Start(processInfo);
           
           return true;
       }

       public override bool Cleanup()
       {
           Reporter.EndReportingContext();
           Console.WriteLine("LaunchApp : Inisde Cleanup");           
           return true;
       }

    }
}
