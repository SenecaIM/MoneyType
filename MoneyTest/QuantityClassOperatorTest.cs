using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FinancialTypes;

namespace MoneyTest
{
    [TestClass]
    public class QuantityTest
    {
        [TestMethod]
        public void Quantity_OperatorOverloadTests()
        {
            // Quantity +, -, ==, !=, <, >, <=, >=
            
            // Arrange
            Quantity q1 = new Quantity(2.5m);
            Quantity q2 = new Quantity(4m);

            // Act
            Quantity q3 = q1 + q2;
            Quantity q4 = q1 - q2;
            Quantity q5 = new Quantity(6.5m);
            Quantity q6 = q1 - q2;
            bool b1 = q1 == q2;
            bool b2 = q1 != q2;
            bool b3 = q1 < q2;
            bool b4 = q1 > q2;
            bool b5 = q1 >= q2;
            bool b6 = q1 <= q2;

            // Assert
            Assert.IsTrue(q5 == q3);
            Assert.IsTrue(q6 == q4);
            Assert.IsFalse(b1);
            Assert.IsTrue(b2);
            Assert.IsTrue(b3);
            Assert.IsFalse(b4);
            Assert.IsFalse(b5);
            Assert.IsTrue(b6);
        }
    }
}
