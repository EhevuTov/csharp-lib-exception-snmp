using System    ;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace csharp_lib_exception_snmp
{
    public class Verification
    {
        public void verify<T>(T temp)
        {
            var props = typeof(T).GetProperties();
            foreach (var prop in props)
            {
                if (prop == null) throw new System.ArgumentNullException("value");
            }
        }
    }
    public class ExceptionWrapConfig : Verification
    {
        private IPEndPoint endPoint;
        private string passphrase;
        private int protocolVersion;

        // default constructor
        public ExceptionWrapConfig()
        {
            // default IPv4 initializations
            try
            {
                endPoint = new IPEndPoint(Dns.GetHostAddresses("localhost")[1], 162);
                passphrase = "public";
                protocolVersion = 1;
            }
            catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("Exception source: {0}", e.Source);
                throw;
            }
        }

        public ExceptionWrapConfig(string pp, int pr)
        {
            try
            {
                endPoint = new IPEndPoint(Dns.GetHostAddresses("localhost")[1], 162);
                passphrase = pp;
                protocolVersion = pr;
            }
            catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("Exception source: {0}", e.Source);
                throw;
            }
        }
        public ExceptionWrapConfig(IPEndPoint he, string pp, int pr)
        {
            try
            {
                endPoint = he;
                passphrase = pp;
                protocolVersion = pr;
            }
            catch (Exception e)
            {
                if (e.Source != null)
                    Console.WriteLine("Exception source: {0}", e.Source);
                throw;
            }
            // insert verification here
        }
    }
    public class ExceptionWrap : ExceptionWrapConfig
    {
        public ExceptionWrap()
        {
        
        }

        public void send()
        {

        }

        private void queue(string msg)
        {

        }
    }
}
