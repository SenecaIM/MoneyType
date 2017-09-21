using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinancialTypes;

namespace MoneyTest
{
    [TestClass]
    public class PriceOperatorConstructorUnitTest
    {
        decimal price1 = 936.5m;
        decimal price2 = 123.456789456m;

        CurrencyInfo ciusd = CurrencyInfoCollection.GetCurrencyInfo("USD");
        CurrencyInfo cigbp = CurrencyInfoCollection.GetCurrencyInfo("GBP");

        [TestMethod]
        public void Price_ConstructorTest1()
        {
            // Arrange
            Price p = new Price(price1, ciusd);

            // Act

            // Assert
            Assert.AreEqual(p.Value, 936.5m);
            Assert.AreEqual(p.CurrencyInfo, ciusd);
            Assert.AreSame(p.CurrencyInfo, ciusd);
        }
        [TestMethod]
        public void Price_ConstructorTest2()
        {
            // Arrange
            Price p = new Price(price1, CurrencyInfoCollection.GetCurrencyInfo("GBP"));

            // Act

            // Assert
            Assert.AreEqual(p.Value, 936.5m);
            Assert.AreEqual(p.CurrencyInfo, cigbp);
            Assert.AreSame(p.CurrencyInfo, cigbp);
        }
        [TestMethod]
        public void Price_ToStringTest()
        {
            // Arrange
            Price p1 = new Price(price1, ciusd);
            Price p2 = new Price(price2, cigbp);

            // Act

            // Assert
            Assert.AreEqual(p1.ToStringMinor(), "936.5");
            Assert.AreNotEqual(p1.ToStringMinor(), "936");
            Assert.AreEqual(p1.ToStringMajorISO(), "9.365 [USD]");
            Assert.AreEqual(p1.ToStringMinorISO(), "936.5 [USD]");
            Assert.AreEqual(p1.ToStringMajor(), "9.365");
            Assert.AreEqual(p1.ToStringMinor(), "936.5");
            Assert.AreEqual(p1.ToStringMajorSymbol(), "$9.365");
            Assert.AreEqual(p1.ToStringMinorSymbol(), "936.5c");

            Assert.AreEqual(p2.ToStringMinorSymbol(), "123.45678946p");
            Assert.AreEqual(p2.ToStringMajorSymbol(), "£1.2345678946");
        }
    }
}
