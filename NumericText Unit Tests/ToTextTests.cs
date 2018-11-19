using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumericText;

namespace NumericText_Unit_Tests
{
    [TestClass]
    public class NumericTextUnitTests
    {
        [TestMethod]
        public void SimpleNumbers()
        {
            string lsTest = "";

            lsTest = "1000";
            Assert.AreEqual("one thousand", lsTest.ToText(), true, "Test #1 falied.");




        }
    }
}
