using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinancialTypes;

namespace MoneyTest
{
    [TestClass]
    public class PriceTestOperator
    {
        [TestMethod]
        public void Price_OperatorOverloadTest()
        {

            //Arrange
            CurrencyInfo cigbp = CurrencyInfoCollection.GetCurrencyInfo("GBP");
            Price p1 = new Price(new decimal(4), cigbp);
            Price p2 = new Price(new decimal(3), cigbp);
            Price p3 = p1 + p2;
            Price p4 = p1 - p2;

            //Act



            //Assert
            Assert.IsTrue(new Price(new decimal(7), cigbp)== p3);
            Assert.IsTrue(new Price(new decimal(1), cigbp) == p4);
            Assert.IsTrue(new Price(new decimal(4), cigbp) == p1);
            Assert.IsTrue(new Price(new decimal(5), cigbp) != p1);
            Assert.IsTrue(new Price(new decimal(6), cigbp) > p1);
            Assert.IsTrue(new Price(new decimal(3), cigbp) < p1);
            Assert.IsTrue(new Price(new decimal(4), cigbp) >= p1);
            Assert.IsTrue(new Price(new decimal(3), cigbp) <= p1);


        }
    }
}
