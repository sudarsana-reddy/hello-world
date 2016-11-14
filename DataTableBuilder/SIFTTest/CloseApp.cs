using HP.LFT.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace SIFTTest
{
    public class CloseApp : ActionBase
    {
       public CloseApp(Object data) : base(data)
        {
            Console.WriteLine("CloseApp: Constructor");
        }

       public override bool Setup()
       {
           string client = "";
           Reporter.StartReportingContext("Close Flight App");
           Console.WriteLine("Verifying Client: " + client);
           Utilities.Client IClient = ClientFactory.GetClient(client);
           IClient.Verify();
           Console.WriteLine("CloseApp : Setup");
           return true;
       }

       public override bool ExecuteAction()
       {
           Console.WriteLine("CloseApp: ExecuteAction");
           flightModel.HPMyFlightSampleApplicationWindow.Close();
           return true;
       }

       public override bool Cleanup()
       {
           Console.WriteLine("CloseApp: Cleanup");
           Reporter.EndReportingContext();
           return true;
       }

    }
}
