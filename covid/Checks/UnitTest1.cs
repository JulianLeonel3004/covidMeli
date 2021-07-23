using Checks.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Checks
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var context = AplicationDbContextInMemory.Get();


        }
    }
}
