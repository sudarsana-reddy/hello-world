using System;
using System.Collections.Generic;
using System.Reflection;

namespace Utilities
{
    public class Utilities
    {
        public static void ShowDesktop()
        {
            Type typeShell = Type.GetTypeFromProgID("Shell.Application");
            object objectShell = Activator.CreateInstance(typeShell);
            typeShell.InvokeMember("MinimizeAll", BindingFlags.InvokeMethod, null, objectShell, null);
        }

        public static void Verify(string actual, List<string> expectedValues=null)
        {
            if (expectedValues == null)
                Console.WriteLine(string.Format("{0} is not empty?: {1}",actual,!string.IsNullOrEmpty(actual)));
            else
            {
                Console.WriteLine(string.Format("{0} is allowed value?: {1}", actual, expectedValues.Contains(actual)));
            }
        }

        public static void PrintValues(Dictionary<string, string> Details)
        {
            foreach (string key in Details.Keys)
                Console.WriteLine(string.Format("Key : {0} , Value : {1}", key, Details[key]));
        }

        public static bool DateFormatValidation(string actualDate, string expectedFormat)
        {
            bool validFormat = true;
            try
            {
                DateTime dateTime = DateTime.Parse(actualDate);
                string formattedDate = dateTime.ToString(expectedFormat);
                validFormat = actualDate.Equals(formattedDate);
            }
            catch(Exception e)
            {
                validFormat = false;
            }

            return validFormat;
        }
    }
}
