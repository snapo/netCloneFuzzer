using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCloneFuzzer.Tests
{
    [TestFixture]
    public class DummyTest
    {
        [Test]
        public void TestDummy()
        {
            Assert.AreEqual("dummy", "dummy");
        }
    }
}
