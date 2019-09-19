using BeFaster.App.Solutions.CHK;
using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public class CheckoutSolutionTest
    {
        [Test]
        public void CheckoutInvalid()   
        {
            Assert.AreEqual(0, CheckoutSolution.Checkout("XYZ"));
        }




         
    }
}