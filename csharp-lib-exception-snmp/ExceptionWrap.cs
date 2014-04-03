using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Messaging;

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
    public class ExceptionWrapConfigAll : Verification{}
    public class ExceptionWrapConfigSys : Verification { }
    public class ExceptionWrapConfigSNMP : Verification
    {
        private IPEndPoint endPoint;
        private string passphrase;
        private int protocolVersion;
        //private Path configFile;

        // default constructor
        public ExceptionWrapConfigSNMP()
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

        public ExceptionWrapConfigSNMP(string pp, int pr)
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
        public ExceptionWrapConfigSNMP(IPEndPoint he, string pp, int pr)
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
    public class ExceptionWrap
    {
        public ExceptionWrap(){        }

        public ExceptionWrap(ExceptionWrapConfigSNMP config)
        {

        }
        public ExceptionWrap(ExceptionWrapConfigSys config) {}
        public ExceptionWrap(ExceptionWrapConfigAll config) {}

        public void send()
        {
            IPAddress address = IPAddress.Loopback;
            Messenger.SendTrapV2(0, VersionCode.V2, new IPEndPoint(address, 162),
                     new OctetString("public"),
                     new ObjectIdentifier(new uint[] { 1, 3, 6 }),
                     0,
                     new List<Variable>());
        }

        private void queue(string msg)
        {

        }
    }
}
