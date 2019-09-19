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
            Assert.AreEqual(-1, CheckoutSolution.Checkout("123"));
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

        [Test]
        public void SimpleBasketE()
        {
            Assert.AreEqual(40, CheckoutSolution.Checkout("E"));
        }

        [Test]
        public void MultipleBasketENoB()
        {
            Assert.AreEqual(80, CheckoutSolution.Checkout("EE"));
        }

        [Test]
        public void FreeBBasketEvenE()
        {
            Assert.AreEqual(80, CheckoutSolution.Checkout("EEB"));
        }

        [Test]
        public void FreeBBasketOddE()
        {
            Assert.AreEqual(150, CheckoutSolution.Checkout("EEEBB"));
        }

        [Test]
        public void FreeBBasketOddB()
        {
            Assert.AreEqual(165, CheckoutSolution.Checkout("EEEBBB"));
        }

        [Test]
        public void SingleFBasket()
        {
            Assert.AreEqual(10, CheckoutSolution.Checkout("F"));
        }

        [Test]
        public void MultipleFBasket2()
        {
            Assert.AreEqual(20, CheckoutSolution.Checkout("FF"));
        }

        [Test]
        public void MultipleFBasket3()
        {
            Assert.AreEqual(20, CheckoutSolution.Checkout("FFF"));
        }

        [Test]
        public void MultipleFBasketLots()
        {
            Assert.AreEqual(50, CheckoutSolution.Checkout("FFFFFFF"));
        }

        [Test]
        public void BigBasketSelection()
        {
            Assert.AreEqual(1165, CheckoutSolution.Checkout("HHIIJJKLLMMMNNOPPQRRSTTUVWXYZ"));
        }

        [Test]
        public void HDeal1()
        {
            Assert.AreEqual(40, CheckoutSolution.Checkout("HHHH"));
        }

        [Test]
        public void HDeal2()
        {
            Assert.AreEqual(55, CheckoutSolution.Checkout("HHHHHH"));
        }

        [Test]
        public void HDeal3()
        {
            Assert.AreEqual(135, CheckoutSolution.Checkout("HHHHHHHHHHHHHHHH"));
        }

        [Test]
        public void NMDeal1()
        {
            Assert.AreEqual(120, CheckoutSolution.Checkout("NNN"));
        }

        [Test]
        public void NMDeal2()
        {
            Assert.AreEqual(175, CheckoutSolution.Checkout("NNNNMM"));
        }

        [Test]
        public void PDeal()
        {
            Assert.AreEqual(250, CheckoutSolution.Checkout("PPPPPP"));
        }

        [Test]
        public void QDeal()
        {
            Assert.AreEqual(110, CheckoutSolution.Checkout("QQQQ"));
        }

        [Test]
        public void RQDeal1()
        {
            Assert.AreEqual(200, CheckoutSolution.Checkout("RRRR"));
        }

        [Test]
        public void RQDeal2()
        {
            Assert.AreEqual(260, CheckoutSolution.Checkout("QQQRRRR"));
        }

        [Test]
        public void UDeal()
        {
            Assert.AreEqual(120, CheckoutSolution.Checkout("UUUU"));
        }

        [Test]
        public void VDeal1()
        {
            Assert.AreEqual(180, CheckoutSolution.Checkout("VVVV"));
        }

        [Test]
        public void VDeal2()
        {
            Assert.AreEqual(220, CheckoutSolution.Checkout("VVVVV"));
        }
    }
}