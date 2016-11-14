using SIFTTest.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFTTest
{
    public class Client
    {
        
        Profile Profile { get; set; }
        AccountList AccountList { get; set; }
        Activation Activation { get; set; }
        TransferNow TransferNow { get; set; }
        TransferMemorized TransferMemorized { get; set; }

        public void Launch()
        {
            Console.WriteLine("Launch App");
        }
        
        public void Enroll(ClientDetails clientDetails)
        {            
            Profile = Profile.CreateProfile(clientDetails);
        }

        public void SearchClientByCCN()
        {
            Console.WriteLine("Searching Client By CCN");
        }

        public void SearchClientBySRF()
        {
            Console.WriteLine("Searching Client By SRF");
        }

        private void LoadProfile()
        {
            Profile = new Profile();
            Console.WriteLine("Profile Loaded");
        }

        public void Verify()
        {
            Console.WriteLine("Verifying Client");
            this.LoadProfile();
            //this.Profile.VerifyProfile();            
        }

        public void Verify(ClientDetails clientDetails)
        {

        }


    }
        
}
