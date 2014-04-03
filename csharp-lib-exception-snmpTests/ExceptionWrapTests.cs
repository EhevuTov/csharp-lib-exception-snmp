using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using csharp_lib_exception_snmp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Practices.Unity.Utility;

using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Pipeline;
using Lextm.SharpSnmpLib.Security;


namespace csharp_lib_exception_snmp.Tests
{
    [TestClass()]
    public class ExceptionWrapTests
    {
        internal static IUnityContainer Container { get; private set; }
        // arrange
        static int test = 0;
        private static void WatcherTrapV2Received(object sender, TrapV2MessageReceivedEventArgs e)
        {
            test = e.Sender.Port;
            //Console.WriteLine(e.TrapV2Message);
        }

        [TestMethod()]
        public void ExceptionWrapTest()
        {
            // arrange
            Container = new UnityContainer().LoadConfiguration("snmptrapd");
            /*
            var users = ExceptionWrapTests.Container.Resolve<UserRegistry>();
            users.Add(new OctetString("neither"),
                DefaultPrivacyProvider.DefaultPair);
            users.Add(new OctetString("authen"),
                new DefaultPrivacyProvider(new MD5AuthenticationProvider(new OctetString("authentication"))));
            users.Add(new OctetString("privacy"),
                new DESPrivacyProvider(new OctetString("privacyphrase"),
                new MD5AuthenticationProvider(new OctetString("authentication")))); 
             */
            var trapv2 = Container.Resolve<TrapV2MessageHandler>("TrapV2Handler");
            trapv2.MessageReceived += WatcherTrapV2Received;
            using (var engine = Container.Resolve<SnmpEngine>())
            {
                engine.Listener.AddBinding(new IPEndPoint(IPAddress.Any, 162));
                engine.Start();
            }
            // act
            ExceptionWrap e = new ExceptionWrap();
            e.send();
            // assert
            Assert.AreEqual(test, 162);
        }

        [TestMethod()]
        public void sendTest()
        {

        }
    }
}
