using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinancialTypes;
using System.Linq;

namespace MoneyTest
{
    [TestClass]
    public class CurrencyInfoCollectionTest
    {
        [TestMethod]
        public void CurrencyInfoCollection_TestConstructor()
        {
            // Arrange

            // Act


            // Assert
            Assert.IsTrue(CurrencyInfoCollection.Items.Any());
        }

        [TestMethod]
        public void CurrencyInfoCollection_TestGetCurrencyInfo()
        {

            // Arrange
            CurrencyInfo ci;

            // Act
            ci = CurrencyInfoCollection.GetCurrencyInfo("USD");


            // Assert
            Assert.IsNotNull(ci);
            Assert.AreEqual(ci.ISO, "USD");
            Assert.IsTrue(ci.DecimalPlaces != 0);

        }
    }
}
