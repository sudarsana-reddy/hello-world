using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public enum ClientType
    {
        Default,
        Basic,
        Enhanced,
        DeleteByBank,
        DeletedByClient
    }
    public class ClientFactory
    {
        public static Client GetClient(string typeofClient)
        {
            Client client = null;
            //ClientType clientType = (ClientType)Enum.Parse(typeof(ClientType), typeofClient, true);
            switch (typeofClient.ToUpper())
            {
                case "BASIC" :
                    client = new BasicClient();
                    break;
                case "ENHANCED" :
                    client = new EnhancedClient();
                    break;
                case "DELETEDBYCLIENT":
                case "DELETEDBYBANK":
                    client = new DeletedClient();
                    break;
                default:
                    client = new DefaultClient();
                    break;
            }

            return client;
        }
    }
}
