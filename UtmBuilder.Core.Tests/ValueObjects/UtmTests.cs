using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtmBuilder.Core.ValueObjects;

namespace UtmBuilder.Core.Tests.ValueObjects
{
    [TestClass]
    public class UtmTests
    {
        private const string result = "https://google.com/" +
                "?utm_source=src" +
                "&utm_medium=med" +
                "&utm_campaign=nme" +
                "&utm_id=id" +
                "&utm_term=ter" +
                "&utm_content=ctn";
        private readonly Url _url = new("https://google.com/");
        private readonly Campaign _campaign = new("src", "med", "nme", "id", "ter", "ctn");

        [TestMethod]
        public void ShoulReturnUrlFromUtm()
        {    
            var utm = new Utm(_url, _campaign);            

            Assert.AreEqual(result, utm.ToString());
            Assert.AreEqual(result, (string)utm);
        }

        [TestMethod]
        public void ShoulReturnUtmFromUrl()
        {
            Utm utm = result;
            Assert.AreEqual("https://google.com/", utm.Url.Address);
            Assert.AreEqual("src", _campaign.Source);
            Assert.AreEqual("med", _campaign.Medium);
            Assert.AreEqual("nme", _campaign.Name);
            Assert.AreEqual("id", _campaign.Id);
            Assert.AreEqual("ter", _campaign.Term);
            Assert.AreEqual("ctn", _campaign.Content);
        }
    }
}
