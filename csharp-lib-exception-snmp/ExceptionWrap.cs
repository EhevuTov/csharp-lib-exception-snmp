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
        public void verify<t>(t temp)
        {
            var props = typeof(t).GetProperties();
            foreach (var prop in props)
            {
                if (prop == null) throw new System.ArgumentNullException("value");
            }
        }
    }
    public class ExceptionWrapConfig : Verification
    {
        public IPEndPoint hostEntry;
        public string passphrase;
        public int protocolVersion;

        // default constructor
        public ExceptionWrapConfig()
        {
            // default initializations
            hostEntry.Address = Dns.GetHostAddresses("localhost")[0];
            hostEntry.Port = 162;
            passphrase = "public";
            protocolVersion = 1;
        }

        public ExceptionWrapConfig(string pp, int pr)
        {
            hostEntry.Address = Dns.GetHostAddresses("localhost")[0];
            hostEntry.Port = 162;
            passphrase = pp;
            protocolVersion = pr;
        }
        public ExceptionWrapConfig(IPEndPoint he, string pp, int pr)
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
