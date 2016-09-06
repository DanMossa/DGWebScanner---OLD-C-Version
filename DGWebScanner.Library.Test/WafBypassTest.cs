using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace DGWebScanner.Library.Test
{
    [TestFixture]
    class WafBypassTest
    {
        [Test]
        public void ReturnNormalGivenNormalUrl([Values("http://www.royalprogress.com/about.php?id=5", "http://www.bertas.com.cn/en/about.php?id=3",
            "http://www.ro.com/abod=5","http://www.micro-mechanics.com/about.php?id=3","http://interiorsdecor.in/pages.php?id=95","http://www.gruporosul.com/interior.php?id=197")] string inputUrl)
        {
            string outputUrl = SingleQuoteUrlBypass.GetCorrectBaseUrl(inputUrl);
            Assert.AreEqual(inputUrl + "'", outputUrl);
        }

    }
}
