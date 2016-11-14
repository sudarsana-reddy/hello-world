using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class ServiceUpdate
    {
        public static void HandleInternetDialogs(string from, string to)
        {
            switch(from)
            {
                case "NoService":
                    switch(to)
                    {
                        case "HasService":
                            Console.WriteLine("New Password");
                            break;
                        /*
                        case "DeleteByBank":
                        case "DeleteByClient":
                            Console.WriteLine("Not a supported Scenario");
                            break;
                         */
                    }
                    break;
                case "HasService":
                    switch(to)
                    {
                            /*
                        case "NoService":
                            Console.WriteLine("Not a supported Scenario");
                            break;
                             */
                        case "DeleteByBank":
                        case "DeleteByClient":
                            Console.WriteLine("Alert: Electronic is not supported");
                            break;
                    }
                    break;
            }
        }
    }
}
