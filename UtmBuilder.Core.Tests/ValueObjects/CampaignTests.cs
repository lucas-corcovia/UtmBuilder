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
    public class CampaignTests
    {
        [TestMethod]
        [DataRow("", "", "", true)]
        [DataRow("src", "", "", true)]
        [DataRow("src", "med", "", true)]
        [DataRow("src", "med", "name", false)]
        public void TestCampaign(string source, string medium, string name, bool expectException)
        {
            if (expectException)
            {
                try
                {
                    new Campaign(source, medium, name);
                    Assert.Fail();
                }
                catch (InvalidCampaignException e)
                when (e.Message == "Source is invalid")
                {
                    Assert.IsTrue(true);
                }
                catch (InvalidCampaignException e)
                when (e.Message == "Medium is invalid")
                {
                    Assert.IsTrue(true);
                }
                catch (InvalidCampaignException e)
                when (e.Message == "Name is invalid")
                {
                    Assert.IsTrue(true);
                }
            }
            else
            {
                new Campaign(source, medium, name);
                Assert.IsTrue(true);
            }
        }
    }
}
