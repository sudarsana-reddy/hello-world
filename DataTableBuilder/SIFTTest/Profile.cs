using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFTTest
{

    public class Profile
    {
        public string TeleBanking { get; set; }
        public string InternetService { get; set; }

        public Profile() { }

        public Profile(string teleBanking, string internetService)
        {
            this.TeleBanking = teleBanking;
            this.InternetService = internetService;
        }

        public Profile CreateProfile(ClientDetails clientDetails)
        {
            Profile profile = new Profile(clientDetails.TeleBanking, clientDetails.InternetService);           
            Console.WriteLine("Created Profile");
            return profile;
        }

        
       
    }
}
