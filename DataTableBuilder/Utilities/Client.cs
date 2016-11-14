using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public abstract class Client
    {
        public bool Verify()
        {
            return VerifyMenuButtons()
                  && VerifyAccessCodes()
                  && VerifyServiceType()
                  && VerifyAccountList();
        }
        protected abstract  bool VerifyMenuButtons();
        protected abstract bool VerifyAccessCodes();
        protected abstract bool VerifyServiceType();
        protected abstract bool VerifyAccountList();
    }

    public class DefaultClient : Client
    {
        protected override bool VerifyMenuButtons()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }

        protected override bool VerifyAccessCodes()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }

        protected override bool VerifyServiceType()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }

        protected override bool VerifyAccountList()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }
    }



    public class BasicClient : Client
    {
        protected override bool VerifyMenuButtons()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }

        protected override bool VerifyAccessCodes()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }

        protected override bool VerifyServiceType()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }

        protected override bool VerifyAccountList()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }
    }

    public class EnhancedClient : Client
    {
        protected override bool VerifyMenuButtons()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }

        protected override bool VerifyAccessCodes()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }

        protected override bool VerifyServiceType()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }

        protected override bool VerifyAccountList()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }
    }

    public class DeletedClient : Client
    {
        protected override bool VerifyMenuButtons()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }

        protected override bool VerifyAccessCodes()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }

        protected override bool VerifyServiceType()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }

        protected override bool VerifyAccountList()
        {
            Console.WriteLine(string.Format("{0} : {1}", this.GetType().Name, MethodBase.GetCurrentMethod().Name));
            return true;
        }
    }
}
