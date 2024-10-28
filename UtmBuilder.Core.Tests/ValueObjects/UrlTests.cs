using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtmBuilder.Core.ValueObjects;
using UtmBuilder.Core.ValueObjects.Exceptions;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    [TestClass]
    public class UrlTests
    {
        private const string InvalidUrl = "invalidurl";
        private const string ValidUrl = "https://www.google.com";

        [TestMethod]
        [ExpectedException(typeof(InvalidUrlException))]
        public void ShouldReturnExceptionWhenUrlIsInvalid()
        {
            new Url(InvalidUrl);
        }

        [TestMethod]
        public void ShouldNotReturnExceptionWhenUrlIsInvalid()
        {
            new Url(ValidUrl);
            Assert.IsTrue(true);
        }

        [TestMethod]
        [DataRow(" ", true)]
        [DataRow("banana", true)]
        [DataRow("http", true)]
        [DataRow(ValidUrl, false)]
        public void TestUrl(string link, bool expectException)
        {
            if (expectException)
            {
                try
                {
                    new Url(link);
                    Assert.Fail();
                }
                catch (InvalidUrlException)
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                new Url(link);
                Assert.IsTrue(true);
            }
        }
    }
}
