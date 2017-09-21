using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinancialTypes;

namespace FinancialTypesTest
{
    [TestClass]
    public class CurrencyInfoTest
    {
        [TestMethod]
        public void CurrencyInfo_ConstructorTest()
        {
            // Arrange
            CurrencyInfo ci = new CurrencyInfo("TestCurr","TCO", 3,"T$", "tc" );


            // Act


            // Assert
            Assert.AreEqual(ci.ISO , "TCO");
            Assert.AreNotEqual(ci.ISO, "tco");
            Assert.AreNotEqual(ci.ISO, "xxx");


            Assert.AreEqual(ci.MajorSymbol, "T$");
            Assert.AreEqual(ci.MinorSymbol, "tc");
            Assert.AreEqual(ci.DecimalPlaces, 3);


        }
    }
}
