using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using csharp_lib_exception_snmp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace csharp_lib_exception_snmp.Tests
{
    [TestClass()]
    public class ExceptionWrapConfigTests
    {
        // arrange globals
        string hn = "localhost";
        int port = 162;
        string pp = "public";
        int pr = 2;

        [TestMethod()]
        public void ExceptionWrapConfigTestConstructor1()
        {
            // arrange
            IPEndPoint ep = new IPEndPoint(Dns.GetHostAddresses(hn)[1], port);
            // act
            ExceptionWrapConfig config = new ExceptionWrapConfig();
            // assert
        }

        [TestMethod()]
        public void ExceptionWrapConfigTestConstructor2()
        {
            // arrange
            IPEndPoint ep = new IPEndPoint(Dns.GetHostAddresses(hn)[1], port);
            // act
            ExceptionWrapConfig config = new ExceptionWrapConfig(pp,pr);
            // assert
        }
        [TestMethod()]
        public void ExceptionWrapConfigTestConstructor3()
        {
            // arrange
            IPEndPoint ep = new IPEndPoint(Dns.GetHostAddresses(hn)[1], port);
            // act
            ExceptionWrapConfig config = new ExceptionWrapConfig(ep, pp, pr);
            // assert
        }
    }
}
