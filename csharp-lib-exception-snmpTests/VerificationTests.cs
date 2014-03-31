using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csharp_lib_exception_snmp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace csharp_lib_exception_snmp.Tests
{
    // arrange
    public class TestVerify
    {
        public int property1;
        public double property2;
        public string property3;
    }
    [TestClass()]
    public class VerificationTests
    {

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException),
         "A property of null was inappropriately allowed.")]
        public void verifyTest()
        {
            // arrange

            // act
            TestVerify testClass = new TestVerify();
            Verification v       = new Verification();
            v.verify(testClass);
            // assert

        }
    }
}
