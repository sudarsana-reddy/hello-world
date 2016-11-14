using HP.LFT.Report;
using HP.LFT.SDK;
using HP.LFT.SDK.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFTTest
{
    public class LoginApp : ActionBase
    {
        string username = "";
        string password = "";
        public LoginApp(Object testData) : base(testData)
        {           
            Console.WriteLine("LoginApp : Inisde LoginApp");
        }

       public override bool Setup()
       {           
           Console.WriteLine("LoginApp : Inisde Setup");
           Reporter.StartReportingContext("Login to Flight App");
           var testData = tdParser.GetTestObject("FlightLogin");
           username = tdParser.GetParamValue(testData, "Username");
           password = tdParser.GetParamValue(testData, "password");
           Console.WriteLine("LoginApp :  Setup: Usename - " + username);
           Console.WriteLine("LoginApp :  Setup: Password - " + password); 

          // Utilities.Utilities.PrintValues(Client.GetClient().Details);
           return true;
       }

       public override bool ExecuteAction()
       {
           Console.WriteLine("LoginApp : Inisde ExecuteAction");
                     
           flightModel.HPMyFlightSampleApplicationWindow.Highlight();

           this.Login();
            
           return true;
       }

       private bool Login()
       {
           flightModel.HPMyFlightSampleApplicationWindow.AgentNameEditField.SetText(username);
           flightModel.HPMyFlightSampleApplicationWindow.PasswordEditField.SetSecure(password);
           flightModel.HPMyFlightSampleApplicationWindow.OKButton.Click();

           return true;
           
       }

       public override bool Cleanup()
       {
           Reporter.EndReportingContext();
           Console.WriteLine("LoginApp : Inisde Cleanup");
           return true;
       }
    }
}
