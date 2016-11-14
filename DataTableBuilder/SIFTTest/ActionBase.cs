using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIFTTest
{
    public abstract class ActionBase
    {
        protected Dictionary<string, Object> testData = null;
        protected FlightModel flightModel = null;
        protected TestDataParser tdParser = null;
        public ActionBase(Object data)
        { 
            Console.WriteLine("Inisde ActionBase");
            flightModel = new FlightModel();
            tdParser = new TestDataParser(data);
        }
        public abstract bool Setup();

        public abstract bool ExecuteAction();

        public abstract bool Cleanup();

        public bool DoAction()
        {
            return Setup() && ExecuteAction() && Cleanup();
        }
    }
        
}
