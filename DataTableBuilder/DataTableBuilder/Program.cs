using SIFTTest;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using HP.LFT.Report;
using HP.LFT.SDK;
using System.Data;
using System.Windows.Forms;

namespace DataTableBuilder
{
    class Program
    {
         static DataTable dt = null;
        static void Main(string[] args)
        {
            //System.IntPtr ptr = IntPtr.
            //Control.FromHandle(722214);

            TransferActions transferActions = new TransferActions();
            transferActions.Transfer("SAL", "CRD", 3);                     

           
            //string json = "{'TestCases':[{'Name':'TC1','Steps':[{'StepName':'launchapp','test_obj_type':'TBSInitial','Parameters':{'Param1':'Value1','Param2':'Value2'}},{'StepName':'loginapp','test_obj_type':'FlightLogin','Parameters':{'Username':'john','password':'hp'}},{'StepName':'closeapp','test_obj_type':'close','Parameters':null}]}]}";
            string json = args[0];
            
            Console.WriteLine("JSON : " + json);

            JObject obj = JObject.Parse(json);           
            JArray testCases = (JArray)obj["TestCases"];

            Dictionary<string,  Object> testCasesList = new Dictionary<string, Object>();

            foreach(JToken tc in testCases)
            {
                testCasesList.Add(tc["Name"].ToString(), tc["Steps"]);
            }            

            string directoryPath = Directory.GetCurrentDirectory() + "\\SIFTTest.dll";
            Assembly testAssembly = Assembly.LoadFrom(directoryPath);            

            SDK.Init(new SdkConfiguration());
            Reporter.Init(new ReportConfiguration());
            foreach (string testCase in testCasesList.Keys)
            {
                Reporter.StartTest(testCase);

                JArray testSteps = (JArray)testCasesList[testCase];                
                foreach (JObject step in testSteps)
                {
                    string x = step["StepName"].ToString();                    

                    var actionType = testAssembly.GetTypes().Where(t => x.Equals(t.Name, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
                    Console.WriteLine("Action Type: " + actionType);
                    if (actionType.IsSubclassOf(typeof(SIFTTest.ActionBase)))
                    {                        
                        SIFTTest.ActionBase action = (SIFTTest.ActionBase)Activator.CreateInstance(actionType, testSteps);
                        Console.WriteLine("Trying to Invoke : " + actionType.ToString());
                        action.DoAction();
                        Console.WriteLine("After Invoke : " + actionType.ToString());
                    }
                    else
                    {
                        Console.WriteLine(string.Format("'{0}' is not a subclass", actionType.ToString()));
                    }
                }

               Reporter.EndTest();               
            }

            Reporter.GenerateReport();
            SDK.Cleanup();
            
        }

        

       
    }
}
