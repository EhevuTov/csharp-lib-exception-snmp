using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp_lib_exception_snmp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace csharp_lib_exception_snmp.Tests
{
    [TestClass()]
    public class ExceptionWrapConfigTests
    {
        [TestMethod()]
        public void ExceptionWrapConfigTestConstructor1()
        {
            // arrange
            // act
            ExceptionWrapConfig config = new ExceptionWrapConfig();
            // assert
            Assert.AreEqual(config.passphrase, "public");
        }

        [TestMethod()]
        public void ExceptionWrapConfigTestConstructor2()
        {
            Assert.Fail();
        }
    }
}
