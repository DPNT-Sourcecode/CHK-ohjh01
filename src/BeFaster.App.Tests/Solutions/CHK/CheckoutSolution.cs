using BeFaster.App.Solutions.CHK;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public class CheckoutSolutionTest
    {
        [Test]
        public void CheckoutIsInvalid()   
        {
            Assert.AreEqual(-1, CheckoutSolution.Checkout("XYZ"));
        }

        [Test]
        public void CheckoutIsValid()
        {
            Assert.AreNotEqual(-1, CheckoutSolution.Checkout("ABCD"));
        }

        [Test]
        public void CheckoutEmptyBasket()
        {
            Assert.AreEqual(0, CheckoutSolution.Checkout(""));
        }

        [Test]
        public void SimpleBasket()
        {
            Assert.AreEqual(115, CheckoutSolution.Checkout("ABCD"));
        }

        [Test]
        public void MultipleSkuBasketA()
        {
            Assert.AreEqual(100, CheckoutSolution.Checkout("AA"));
        }

        [Test]
        public void SpecialOfferBasketA()
        {
            Assert.AreEqual(180, CheckoutSolution.Checkout("AAAA"));
        }

        [Test]
        public void SpecialOfferBasketB()
        {
            Assert.AreEqual(45, CheckoutSolution.Checkout("BB"));
        }

        [Test]
        public void MultipleSkuBasketC()
        {
            Assert.AreEqual(80, CheckoutSolution.Checkout("CCCC"));
        }

        [Test]
        public void MultipleSkuBasketD()
        {
            Assert.AreEqual(60, CheckoutSolution.Checkout("DDDD"));
        }

        [Test]
        public void UnorderedBasket()
        {
            Assert.AreEqual(245, CheckoutSolution.Checkout("DACDBCADA"));
        }

        [Test]
        public void LowerCaseNotAllowed()
        {
            Assert.AreEqual(-1, CheckoutSolution.Checkout("a"));
        }
    }
}

