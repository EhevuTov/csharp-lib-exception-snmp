using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lib_exception_snmp
{
    public class Verification
    {
        static public void verify<t>(t temp)
        {
            var props = typeof(t).GetProperties();
            foreach (var prop in props)
            {
                if (prop == null) throw new System.ArgumentException();
            }
        }
    }
    public class ExceptionWrapConfig : Verification
    {
        public IPHostEntry hostEntry;
        public string passphrase;
        public int protocolVersion;

        public ExceptionWrapConfig()
        {
            // add default initializations here
        }

        public ExceptionWrapConfig(IPHostEntry he, string pp, int pr)
        {
            hostEntry = he;
            passphrase = pp;
            protocolVersion = pr;
            // insert verification here
        }
    }
    public class ExceptionWrap : ExceptionWrapConfig
    {
        public ExceptionWrap()
        {
        
        }

        public void queue(string msg)
        {

        }
    }
}
