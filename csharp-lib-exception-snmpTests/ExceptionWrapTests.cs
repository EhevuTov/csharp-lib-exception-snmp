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

using Lextm.SharpSnmpLib;
using Lextm.SharpSnmpLib.Pipeline;
using Lextm.SharpSnmpLib.Security;


namespace csharp_lib_exception_snmp.Tests
{
    [TestClass()]
    public class ExceptionWrapTests
    {
        internal static IUnityContainer Container { get; private set; }

        private static void WatcherTrapV2Received(object sender, TrapV2MessageReceivedEventArgs e)
        {
            Console.WriteLine(e.TrapV2Message);
        }

        [TestMethod()]
        public void ExceptionWrapTest()
        {
            // arrange
            
            Container = new UnityContainer().LoadConfiguration("snmptrapd");
            var trapv2 = Container.Resolve<TrapV2MessageHandler>("TrapV2Handler");
            trapv2.MessageReceived += WatcherTrapV2Received;
            using (var engine = Container.Resolve<SnmpEngine>())
            {
                engine.Listener.AddBinding(new IPEndPoint(IPAddress.Any, 162));
                engine.Start();
                Console.WriteLine("#SNMP is available at http://sharpsnmplib.codeplex.com");
                Console.WriteLine("Press any key to stop . . . ");
                Console.Read();
                engine.Stop();
            }
            // act
            ExceptionWrap e = new ExceptionWrap();
            // assert
        }

        [TestMethod()]
        public void sendTest()
        {

        }
    }
}
