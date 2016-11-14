using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HP.LFT.SDK;
using HP.LFT.Verifications;
using LeanFtAppModelProject1;
using HP.LFT.SDK.StdWin;
using System.Drawing;
using SIFTTest;
using System.Diagnostics;


namespace LeanFtTestProject1
{
    [TestClass]
    public class LeanFtTest : UnitTestClassBase<LeanFtTest>
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            GlobalSetup(context);
        }

        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod]
        public void TestMethod1()
        {
            ApplicationModel1 appModel = new ApplicationModel1();

            var obj = appModel.Form1YourChoiceWindow.Form2EnglishLanguageWindow.MSFlexGridWndClassUiObject;
               
            obj.Highlight();
            Rectangle[] size = obj.GetTextLocations("Berlin");
            //string text = obj[0].GetVisibleText(new Rectangle{ X = locs[0].X+1, Y = locs[0].Y + locs[0].Height + 2} );
            
        }

        [TestMethod]
        public void Experiment()
        {
            string year = "2016";
            string month = "11";
            string day = "31";
            string d = string.Format("{0}-{1}-{2}", year, month, day);
            if(!this.IsValidFutureDate(d))
            {
                Console.WriteLine(string.Format("{0} is not a valid/future date", d));
            }

            Process.Start(new ProcessStartInfo { FileName = @"C:\Learning\WPF Flights Application\FlightsGUI.exe" });

            
            FlightModel model = new FlightModel();
            model.HPMyFlightSampleApplicationWindow.Activate();
            try
            {
                model.HPMyFlightSampleApplicationWindow.CancelButton.Click();
            }
            catch(HP.LFT.SDK.GeneralReplayException ex)
            {
                Console.WriteLine(ex.Message);

                throw new GeneralReplayException(model.HPMyFlightSampleApplicationWindow.OKButton, "Unable to click ÓK'button", ex);
                
                IDialog d1 = ex.TestObject.Parent.Describe<IDialog>(new DialogDescription {});
                if (d1.Exists(0))
                {
                    string s = d1.Describe<IStatic>(new StaticDescription { }).Text;
                    Console.WriteLine(s);
                    d1.Describe<IButton>(new ButtonDescription { Text = "OK" }).Click();
                }

            }
             
          // bool exists = model.HPMyFlightSampleApplicationWindow.Exists(1);
           // model.HPMyFlightSampleApplicationWindow.ClassComboBox.Select(1);
            System.Threading.Thread.Sleep(5000);
            
            VerifyActionExtensions.PressKey(System.Windows.Forms.Keys.Down, false);
            VerifyActionExtensions.PressKey(System.Windows.Forms.Keys.Down ,true);
            VerifyActionExtensions.PressKey(System.Windows.Forms.Keys.Down, false);
            VerifyActionExtensions.PressKey(System.Windows.Forms.Keys.Down, true);
             

            System.Windows.Forms.SendKeys.SendWait(Keys.Down);
            System.Windows.Forms.SendKeys.SendWait(Keys.Down);
            
            /*Client client = new Client();
            client.Launch();
            client.SearchClientByCCN();            
            client.Verify();]
             */ 
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            GlobalTearDown();
        }

        private bool IsValidFutureDate(string dateFormat)
        {
            DateTime today = DateTime.Now;
            DateTime date;
            if (DateTime.TryParse(dateFormat, out date))
            {
                if (date.CompareTo(today) <= 0)
                {
                    Console.WriteLine("Not a future Date");
                    return false;
                }
                else
                    return true;
            }
            else
            {
                Console.WriteLine("Invalid Date : " + dateFormat);
                return false;
            }            
        }
    }
}
